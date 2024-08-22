using Godot;

public partial class LevelInit : Node2D
{
	private GameManager gameManager;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		// Get the GameManager node
		gameManager = GetNode<GameManager>("/root/GameManager");
		if (gameManager == null)
		{
			GD.PrintErr("GameManager node not found.");
		}
		else
		{
			gameManager.InitializeGameObjects();
		}
	}
}
