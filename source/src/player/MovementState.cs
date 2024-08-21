using Godot;

public partial class MovementState : State
{
	public const float Speed = 300.0f;

	[ExportCategory("State Setup")]
	[Export]
	public string IdleAnimation { get; set; } = "idle";
	[Export]
	public string WalkAnimation { get; set; } = "walk";

	[Export]
	public State JumpState { get; set; }

	[Export]
	public State FallState { get; set; }

	[Export]
	public State WinnerState { get; set; }

	public override void OnEnter()
	{
		base.OnEnter();
	}

	public override void OnExit()
	{
		base.OnExit();
	}

	public override void StatePhysicsProcess(float delta)
	{
		base.StatePhysicsProcess(delta);

		Vector2 velocity = Character.Velocity;

		// Get the input direction and handle the movement/deceleration.
		// As good practice, you should replace UI actions with custom gameplay actions.
		float direction = Input.GetAxis("left", "right");
		if (direction != 0)
		{
			velocity.X = direction * Speed;
			AnimatedSprite.Play(WalkAnimation);
		}
		else
		{
			velocity.X = Mathf.MoveToward(velocity.X, 0, Speed);
			AnimatedSprite.Play(IdleAnimation);
		}

		if (!Character.IsOnFloor())
		{
			NextState = FallState;
		}

		Character.Velocity = velocity;
	}

	public override void StateInput(InputEvent @event)
	{
		base.StateInput(@event);

		// Handle Jump.
		if (Input.IsActionJustPressed("jump") && Character.IsOnFloor())
		{
			NextState = JumpState;
			GD.Print("Jump called");
		}
	}
}
