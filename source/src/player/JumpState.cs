using Godot;

public partial class JumpState : State
{
	public const float JumpVelocity = -400.0f;

	[ExportCategory("State Setup")]
	[Export]
	public string JumpAnimation { get; set; } = "jump";

	[Export]
	public State FallState { get; set; }

	[Export]
	public bool AllowAirControl { get; set; } = false;

	public override void OnEnter()
	{
		base.OnEnter();

		AnimatedSprite.Play(JumpAnimation);
		Character.Velocity = new Vector2(Character.Velocity.X, JumpVelocity);
	}

	public override void OnExit()
	{
		base.OnExit();
	}

	public override void StatePhysicsProcess(float delta)
	{
		base.StatePhysicsProcess(delta);

		if (Character.Velocity.Y > 0)
			NextState = FallState;

		if (AllowAirControl)
		{
			Vector2 velocity = Character.Velocity;
			float direction = Input.GetAxis("left", "right");
			if (direction != 0)
			{
				velocity.X = direction * MovementSpeed;
			}

			Character.Velocity = velocity;
		}
	}
}
