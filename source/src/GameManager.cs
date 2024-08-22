using Godot;

public partial class GameManager : Node
{
	public bool IsInitialized { get => isInitialized; }

	private bool isInitialized = false;

	private Panel winGameMenu;

	private Panel pauseMenu;

	private Player player;

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

		var node = GetTree().GetCurrentScene();
		string pathPrefix = node.GetPath();
		GD.Print("Path prefix: " + pathPrefix);
		// Find and assign the WinGameMenu node
		winGameMenu = GetNode<Panel>($"{pathPrefix}/UI/WinScreen");
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
		pauseMenu = GetNode<Panel>($"{pathPrefix}/UI/PauseMenu");
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
		player = GetNode<Player>($"{pathPrefix}/%Player");
		if (player == null)
		{
			GD.PrintErr("Player node not found.");
			isInitialized = false;
		}
	}
}
