using System;
using Godot;

public partial class DebugMenu : MenuButton
{
	private Player player;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		player = GetNode<Player>("%Player");
		if (player == null)
		{
			GD.PrintErr("Player node not found.");
		}

		var popup = GetPopup();
		popup.IdPressed += MenuPopupIdPressed;
	}

	private void MenuPopupIdPressed(long id)
	{
		switch	(id)
		{
			case 0:
				// Get popup's check button.
				bool isDebugLabelEnabled = !GetPopup().IsItemChecked(0);
				GetPopup().SetItemChecked(0, isDebugLabelEnabled);
				player.ShowDebugLabel(isDebugLabelEnabled);
				break;
			case 2:
				bool allowAirControl = !GetPopup().IsItemChecked(0);
				GetPopup().SetItemChecked(2, allowAirControl);
				player.StateMachine.DebugAllowAirControl(allowAirControl);
				break;
			default:
				GD.Print("Invalid ID: " + id);
				break;
		}
	}

	private void _on_check_button_toggled(bool buttonPressed)
	{
		GD.Print("_on_check_button_toggled Button pressed: " + buttonPressed);
		player.ShowDebugLabel(buttonPressed);
	}
}
