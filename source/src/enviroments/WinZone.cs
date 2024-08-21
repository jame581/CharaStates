using Godot;

public partial class WinZone : Area2D
{
	public override void _Ready()
	{
		BodyEntered += OnWinZoneBodyEntered;
	}

	public void OnWinZoneBodyEntered(Node body)
	{
		if (body is Player)
		{
			var player = body as Player;
			player.SetWinnerState();
		}
	}
}
