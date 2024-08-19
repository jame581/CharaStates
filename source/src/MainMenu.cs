using Godot;
using System;

public partial class MainMenu : Node2D
{
	private Label versionLabel;
	private Button startButton;
	private Button exitButton;

	private string gameVersion = ProjectSettings.GetSetting("application/config/version").AsString();

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		versionLabel = GetNode<Label>("UI/VersionLabel");

		if (versionLabel == null)
		{
			GD.PrintErr("VersionLabel node not found.");
		}
		else
		{
			versionLabel.Text = $"Version: {gameVersion}";
		}

		startButton = GetNode<Button>("UI/StartButton");
		if (startButton == null)
		{
			GD.PrintErr("StartButton node not found.");
		}
		else
		{
			startButton.Pressed += OnStartButtonPressed;
		}

		exitButton = GetNode<Button>("UI/ExitButton");
		if (exitButton == null)
		{
			GD.PrintErr("ExitButton node not found.");
		}
		else
		{
			exitButton.Pressed += OnExitButtonMousePressed;
		}
	}

    private void OnExitButtonMousePressed()
    {
        GetTree().Quit();
    }


	private void OnStartButtonPressed()
	{
		// Load the game scene.
		GetTree().ChangeSceneToFile("res://maps/test_map.tscn");
	}
}
