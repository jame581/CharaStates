using Godot;

public partial class FallState : State
{

	[ExportCategory("State Setup")]
	[Export]
	public string FallAnimation { get; set; } = "fall";

	[Export]
	public State GroundState { get; set; }

	public override void OnEnter()
	{
		base.OnEnter();

		AnimatedSprite.Play(FallAnimation);
	}

	public override void OnExit()
	{
		base.OnExit();
	}

	public override void StatePhysicsProcess(float delta)
	{
		base.StatePhysicsProcess(delta);

		if (Character.IsOnFloor())
		{
			NextState = GroundState;
		}
	}
}
