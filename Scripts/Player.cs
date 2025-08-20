using Godot;
using System;

public partial class Player : Area2D
{
	/// <summary>
	/// How fast the player will move (pixels/sec)
	/// </summary>
	[Export]
	public int Speed { get; set; } = 400;

	/// <summary>
	/// Size of the game window
	/// </summary>
	public Vector2 ScreenSize;

	public override void _Ready()
	{
		base._Ready();
		ScreenSize = new Vector2(128*20, 128*20);
	}

	public override void _Process(double delta)
	{
		var velocity = Vector2.Zero; // The player's movement vector.

		if (Input.IsActionPressed("ui_right"))
		{
			velocity.X += 1;
		}

		if (Input.IsActionPressed("ui_left"))
		{
			velocity.X -= 1;
		}

		if (Input.IsActionPressed("ui_down"))
		{
			velocity.Y += 1;
		}

		if (Input.IsActionPressed("ui_up"))
		{
			velocity.Y -= 1;
		}

		var animatedSprite2D = GetNode<AnimatedSprite2D>("AnimatedSprite2D");

		if (velocity.Length() > 0)
		{
			velocity = velocity.Normalized() * Speed;
			animatedSprite2D.Play();
		}
		else
		{
			animatedSprite2D.Stop();
		}

		SetPosition(velocity, (float)delta);
	}

	private void SetPosition(Vector2 velocity, float delta)
	{
		Position += velocity * delta;

		// clamp position to screen size edge
		Position = new Vector2(
			x: Mathf.Clamp(Position.X, -ScreenSize.X/2, ScreenSize.X/2),
			y: Mathf.Clamp(Position.Y, -ScreenSize.Y/2, ScreenSize.Y/2)
		);
	}
}
