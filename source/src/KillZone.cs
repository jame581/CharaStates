using Godot;

public partial class KillZone : Area2D
{
	private Timer timer;
	
	GameManager gameManager;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		timer = GetNode<Timer>("Timer");
		if (timer == null)
			GD.PrintErr("Timer node not found.");

		gameManager = GetNode<GameManager>("/root/GameManager");
		if (gameManager == null)
			GD.PrintErr("GameManager node not found.");
	}

	public void _on_body_entered(Node body)
	{
		GD.Print("KillZone._on_body_entered!");
		if (body is Player)
		{
			timer.Start();
		}
	}

	public void _on_timer_timeout()
	{
		GD.Print("KillZone._on_timer_timeout!");
		gameManager.RestartLevel();
	}
}
