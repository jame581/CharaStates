using Godot;
using System.Collections.Generic;

public partial class CharacterStateMachine : Node
{
	[Signal]
	public delegate void CharacterStateChangedEventHandler(string newState);
	
	[Export]
	public CharacterBody2D Character { get; set; }

	[Export]
	public State CurrentState { get; set; }

    private List<State> states;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		// Get all the states from the children.
		states = new List<State>();
		foreach (Node node in GetChildren())
		{
			if (node is State state)
			{
				state.Character = Character;
				state.AnimatedSprite = Character.GetNode<AnimatedSprite2D>("AnimatedSprite2D");
				states.Add(state);
			}
			else
			{
				GD.PushError("Child node is not a State.");
			}
		}

		
		if(CurrentState == null)
		{
			GD.PushError("CurrentState is not set.");
		}
		else
		{
			CurrentState.OnEnter();
		}
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if(CurrentState == null)
		{
			GD.PushError("CurrentState is not set.");
			return;
		}

		CurrentState.StateProcess((float)delta);
	}

	public override void _PhysicsProcess(double delta)
	{
		if(CurrentState == null)
		{
			GD.PushError("CurrentState is not set.");
			return;
		}

		if (CurrentState.NextState != null)
		{
			GD.Print("Changing state to " + CurrentState.NextState.Name);
			ChangeState(CurrentState.NextState);
		}

		CurrentState.StatePhysicsProcess((float)delta);
	}

	public override void _Input(InputEvent @event)
	{
		if(CurrentState == null)
		{
			GD.PushError("CurrentState is not set.");
			return;
		}

		CurrentState.StateInput(@event);
	}

	public void ChangeState(State newState)
	{
		if(newState == null)
		{
			GD.PushError("NewState is null.");
			return;
		}

		if(CurrentState == newState)
		{
			GD.Print("NewState " + newState.Name + " is the same as CurrentState.");
			return;
		}

		if(CurrentState != null)
		{
			CurrentState.OnExit();
			CurrentState.NextState = null;
		}

		GD.Print("Changing state to " + newState.Name);
		CurrentState = newState;
		CurrentState.OnEnter();

		EmitSignal(SignalName.CharacterStateChanged, CurrentState.Name);
	}

	public void DebugAllowAirControl(bool allowAirControl)
	{
		foreach (State state in states)
		{
			if (state is JumpState jumpState)
			{
				jumpState.AllowAirControl = allowAirControl;
			}
		}
	}
}
