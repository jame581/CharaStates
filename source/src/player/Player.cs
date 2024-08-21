using Godot;

public partial class Player : CharacterBody2D
{
	[Export]
	public State WinnerState { get; set; }

	// Get the gravity from the project settings to be synced with RigidBody nodes.
	public float gravity = ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();

	private AnimatedSprite2D animatedSprite;

	private Label scoreLabel;
	
	private Label stateDebugLabel;

	private CharacterStateMachine stateMachine;

	private int coins = 0;

	public override void _Ready()
	{
		base._Ready();

		animatedSprite = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
		if (animatedSprite == null)
			GD.PrintErr("AnimatedSprite2D node not found.");

		stateMachine = GetNode<CharacterStateMachine>("StateMachine");
		if (stateMachine == null)
			GD.PrintErr("StateMachine node not found.");

		scoreLabel = GetNode<Label>("PlayerUI/ScoreLabel");
		if (scoreLabel == null)
			GD.PrintErr("ScoreLabel node not found.");

		stateDebugLabel = GetNode<Label>("StateDebugLabel");
		if (stateDebugLabel == null)
			GD.PrintErr("DebugLabel node not found.");
	}

	public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;

		// Add the gravity.
		if (!IsOnFloor())
		{
			velocity.Y += gravity * (float)delta;
		}

		Velocity = velocity;
		FlipSpriteByDirection();
		MoveAndSlide();
	}

	public void SetWinnerState()
	{
		stateMachine.ChangeState(WinnerState);
	}

	public void AddCoins(int value)
	{
		coins += value;

		if (scoreLabel != null)
			scoreLabel.Text = $"Coins: {coins}";
	}

	public void ShowDebugLabel(bool show)
	{
		if (stateDebugLabel != null)
			stateDebugLabel.Visible = show;
	}

	private void FlipSpriteByDirection()
	{
		if (Velocity.X < 0)
			animatedSprite.Scale = new Vector2(-1, 1);
		else if (Velocity.X > 0)
			animatedSprite.Scale = new Vector2(1, 1);
	}
}
