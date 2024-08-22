using Godot;

public partial class PauseMenu : Panel
{
	private bool isPaused = false;

	private Button continueButton;

	private Button mainMenuButton;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		// Set the process mode to when paused.
		ProcessMode = ProcessModeEnum.WhenPaused;

		// Get the continue button node.
		continueButton = GetNode<Button>("ContinueButton");
		if (continueButton == null)
		{
			GD.PrintErr("ContinueButton node not found.");
		}
		else
		{
			continueButton.Pressed += OnContinueButtonPressed;
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
		}

		// Connect to the draw signal to pause the game.
		Draw += OnDraw;
	}

	// Called when the pause menu is drawn to screen.
	private void OnDraw()
	{
		isPaused = true;
		GetTree().Paused = isPaused;
	}


	private void OnMainMenuButtonPressed()
	{
		GetTree().ChangeSceneToFile("res://maps/main_menu.tscn");
	}

	private void OnContinueButtonPressed()
	{
		// Unpause the game.
		isPaused = false;

		// Set the paused property of the scene tree to false.
		GetTree().Paused = isPaused;

		// Hide the pause menu.
		Visible = false;
	}
}
