using Godot;

public partial class WinGameMenu : Panel
{
	private Button restartButton;

	private Button mainMenuButton;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		// Get the continue button node.
		restartButton = GetNode<Button>("RestartButton");
		if (restartButton == null)
		{
			GD.PrintErr("RestartButton node not found.");
		}
		else
		{
			restartButton.Pressed += OnRestartButtonPressed;
			GD.Print("Win Game Menu - Restart button binded");
		}

		// Get the main menu button node.
		mainMenuButton = GetNode<Button>("MainMenuButton");
		if (mainMenuButton == null)
		{
			GD.PrintErr("MainMenuButton node not found.");
		}
		else
		{
			mainMenuButton.Pressed += OnMainMenuButtonPressed;
			GD.Print("Win Game Menu - Main menu button binded");
		}
	}

	private void OnMainMenuButtonPressed()
	{
		GD.Print("Returning to main menu...");
		GetTree().ChangeSceneToFile("res://maps/main_menu.tscn");
	}


	private void OnRestartButtonPressed()
	{
		GD.Print("Restarting game...");
		GetTree().ReloadCurrentScene();
	}
}
