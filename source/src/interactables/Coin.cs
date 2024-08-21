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

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		audioStreamPlayer = GetNode<AudioStreamPlayer2D>("AudioStreamPlayer2D");

		if (audioStreamPlayer == null)
		{
			GD.PrintErr("AudioStreamPlayer2D node not found.");
		}
		else
		{
			audioStreamPlayer.Stream = PickUpSound;
		}

		destroyTimer = GetNode<Timer>("Timer");
		if (destroyTimer == null)
		{
			GD.PrintErr("Timer node not found.");
		}
		else
		{
			destroyTimer.Timeout += DestroyCoin;
		}

		collisionShape = GetNode<CollisionShape2D>("Area2D/CollisionShape2D");
		if (collisionShape == null)
		{
			GD.PrintErr("CollisionShape2D node not found.");
		}
	}

	public void _on_area_2d_body_entered(Node body)
	{
		if (body is Player)
		{
			GD.Print("Coin picked up.");
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
