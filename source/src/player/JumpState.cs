using Godot;

public partial class JumpState : State
{
	public const float JumpVelocity = -400.0f;

	[ExportCategory("State Setup")]
	[Export]
	public string JumpAnimation { get; set; } = "jump";

	[Export]
	public State FallState { get; set; }

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
	}
}
