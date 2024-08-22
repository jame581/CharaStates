using Godot;
using System;

public partial class LevelInit : Node2D
{
	private GameManager gameManager;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
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

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
