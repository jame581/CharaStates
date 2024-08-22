using Godot;

public partial class Coin : Node2D
{
	[Export]
	public AudioStream PickUpSound { get; set; }

	[Export]
	public int Value { get; set; } = 1;

	[Signal]
	public delegate void CoinPickedUpEventHandler(int value);

	private AudioStreamPlayer2D audioStreamPlayer;

	private Timer destroyTimer;

	private CollisionShape2D collisionShape;

	private AnimationPlayer animationPlayer;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		// Get the AudioStreamPlayer2D node
		audioStreamPlayer = GetNode<AudioStreamPlayer2D>("AudioStreamPlayer2D");
		if (audioStreamPlayer == null)
		{
			GD.PrintErr("AudioStreamPlayer2D node not found.");
		}
		else
		{
			audioStreamPlayer.Stream = PickUpSound;
		}

		// Get the Timer node
		destroyTimer = GetNode<Timer>("Timer");
		if (destroyTimer == null)
		{
			GD.PrintErr("Timer node not found.");
		}
		else
		{
			destroyTimer.Timeout += DestroyCoin;
		}

		// Get the CollisionShape2D node
		collisionShape = GetNode<CollisionShape2D>("Area2D/CollisionShape2D");
		if (collisionShape == null)
		{
			GD.PrintErr("CollisionShape2D node not found.");
		}

		// Play the idle animation
		animationPlayer = GetNode<AnimationPlayer>("AnimationPlayer");
		if (animationPlayer == null)
		{
			GD.PrintErr("AnimationPlayer node not found.");
		}
		else
		{
			animationPlayer.Play("idle");
		}
	}

	public void _on_area_2d_body_entered(Node body)
	{
		if (body is Player)
		{
			GD.Print("Coin picked up.");
			animationPlayer.Play("pickup");
			var player = body as Player;
			player.AddCoins(Value);
			audioStreamPlayer.Play();
			EmitSignal(nameof(CoinPickedUp), Value);
			collisionShape.SetDeferred(nameof(CollisionShape2D.PropertyName.Disabled), true);
			destroyTimer.Start();
		}
	}

	private void DestroyCoin()
	{
		QueueFree();
	}
}
