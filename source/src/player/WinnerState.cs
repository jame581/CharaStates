using Godot;

public partial class WinnerState : State
{
	[ExportCategory("State Setup")]
	[Export]
	public string CheerAnimation { get; set; } = "fall";

	public override void OnEnter()
	{
		base.OnEnter();
		AnimatedSprite.Play(CheerAnimation);
		Character.Velocity = Godot.Vector2.Zero;
	}

	public override void OnExit()
	{
		base.OnExit();
	}
}
