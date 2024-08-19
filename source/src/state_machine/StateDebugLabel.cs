using Godot;
using System;

public partial class StateDebugLabel : Label
{
	[Export]
	private CharacterStateMachine characterStateMachine;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		if (characterStateMachine == null)
		{
			GD.PrintErr("CharacterStateMachine node not found.");
			return;
		}

		characterStateMachine.CharacterStateChanged += OnCharacterStateChanged;
	}

	private void OnCharacterStateChanged(string newState)
	{
		Text = $"State: {newState}";
	}
}
