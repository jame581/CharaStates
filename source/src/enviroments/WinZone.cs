using Godot;

public partial class WinZone : Area2D
{
	private GameManager gameManager;

	public override void _Ready()
	{
		BodyEntered += OnWinZoneBodyEntered;

		gameManager = GetNode<GameManager>("/root/GameManager");
		if (gameManager == null)
		{
			GD.PrintErr("GameManager node not found.");
		}
	}

	public void OnWinZoneBodyEntered(Node body)
	{
		if (body is Player && gameManager != null)
		{
			gameManager.GameCompleted();
		}
	}
}
