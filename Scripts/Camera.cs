using Godot;
using System;

public partial class Camera : Camera2D
{
	[Export] public Player Player;
	public override void _Process(double delta)
	{
		base._Process(delta);
		SetCameraPos();
	}

	private void SetCameraPos()
	{
		this.Position = Player.Position;
	}

}
