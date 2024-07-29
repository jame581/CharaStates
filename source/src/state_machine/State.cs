using Godot;

public partial class State : Node
{
	[Export]
	public bool CanMove { get; set; } = true;
	
	public CharacterBody2D Character { get; set; }
	
	public State NextState { get; set; }
	
	public bool StateIsActive { get; set; } = false;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{

	}

	public void StateProcess(float delta)
	{

	}

	public void StatePhysicsProcess(float delta)
	{

	}

	public void StateInput(InputEvent @event)
	{

	}

	public void OnEnter()
	{
		StateIsActive = true;
	}

	public void OnExit()
	{
		StateIsActive = false;
	}
}
