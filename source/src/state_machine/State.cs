using Godot;

public partial class State : Node
{
	[Export]
	public bool CanMove { get; set; } = true;
	
	public CharacterBody2D Character { get; set; }

	public AnimatedSprite2D AnimatedSprite { get; set; }
	
	public State NextState { get; set; }
	
	public bool StateIsActive { get; set; } = false;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{

	}

	public virtual void StateProcess(float delta)
	{

	}

	public virtual void StatePhysicsProcess(float delta)
	{

	}

	public virtual void StateInput(InputEvent @event)
	{

	}

	public virtual void OnEnter()
	{
		StateIsActive = true;
		GD.Print("State Entered " + this.Name);
	}

	public virtual void OnExit()
	{
		StateIsActive = false;
	}
}
