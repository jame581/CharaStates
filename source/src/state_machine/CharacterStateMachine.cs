using Godot;
using System.Collections.Generic;

public partial class CharacterStateMachine : Node
{
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

	private void ChangeState(State newState)
	{
		if(newState == null)
		{
			GD.PushError("NewState is null.");
			return;
		}

		if(CurrentState != null)
		{
			CurrentState.OnExit();
			CurrentState.NextState = null;
		}

		CurrentState = newState;
		CurrentState.OnEnter();
	}
}
