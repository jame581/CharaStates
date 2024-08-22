using Godot;

public partial class GameManager : Node
{
	public bool IsInitialized { get => isInitialized; }

	private bool isInitialized = false;

	private Panel winGameMenu;

	private Panel pauseMenu;

	private Player player;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		InitializeGameObjects();
	}

	public void GameCompleted()
	{
		GD.Print("Game completed.");
		player.SetWinnerState();
		pauseMenu.Visible = false;
		winGameMenu.Visible = true;
	}

	public void InitializeGameObjects()
	{
		if (isInitialized)
		{
			return;
		}

		isInitialized = true;

		// Find and assign the WinGameMenu node
		winGameMenu = GetNode<Panel>("/root/TestMap/UI/WinScreen");
		if (winGameMenu == null)
		{
			GD.PrintErr("WinGameMenu node not found.");
			isInitialized = false;
		}
		else
		{
			winGameMenu.Visible = false;
		}

		// Find and assign the PauseMenu node
		pauseMenu = GetNode<Panel>("/root/TestMap/UI/PauseMenu");
		if (pauseMenu == null)
		{
			GD.PrintErr("PauseMenu node not found.");
			isInitialized = false;
		}
		else
		{
			pauseMenu.Visible = false;
		}

		// Find and assign the Player node
		player = GetNode<Player>("/root/TestMap/%Player");
		if (player == null)
		{
			GD.PrintErr("Player node not found.");
			isInitialized = false;
		}
	}
}
