using Godot;
using System;

public partial class WinGameMenu : Panel
{
	private Button restartButton;

	private Button mainMenuButton;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		// Set the process mode to when paused.
		ProcessMode = ProcessModeEnum.WhenPaused;

		// Get the continue button node.
		restartButton = GetNode<Button>("RestartButton");
		if (restartButton == null)
		{
			GD.PrintErr("RestartButton node not found.");
		}
		else
		{
			restartButton.Pressed += OnRestartButtonPressed;
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
	}

    private void OnMainMenuButtonPressed()
    {
		GetTree().ChangeSceneToFile("res://maps/main_menu.tscn");
    }


    private void OnRestartButtonPressed()
    {
		GetTree().ReloadCurrentScene();
	}
}
