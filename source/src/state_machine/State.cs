using Godot;

public partial class State : Node
{
	[Export]
	public bool CanMove { get; set; } = true;
	
	public const float MovementSpeed = 300.0f;

	public CharacterBody2D Character { get; set; }

	public AnimatedSprite2D AnimatedSprite { get; set; }
	
	public State NextState { get; set; }
	
	public bool StateIsActive { get; set; } = false;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{

	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public virtual void StateProcess(float delta)
	{

	}

	// Called every physics frame. 'delta' is the elapsed time since the previous frame.
	public virtual void StatePhysicsProcess(float delta)
	{

	}

	// Called when the input event is received.
	public virtual void StateInput(InputEvent @event)
	{

	}

	// Called when the state is entered.
	public virtual void OnEnter()
	{
		StateIsActive = true;
		GD.Print("State Entered " + this.Name);
	}

	// Called when the state is exited.
	public virtual void OnExit()
	{
		StateIsActive = false;
	}
}
