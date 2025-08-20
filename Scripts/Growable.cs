using Godot;
using System;

public partial class Growable : AnimatedSprite2D
{
	[Export] public int SecondsPerStage;
	[Export] public int AmountOfStages;
	[Export] public int CurrentStage { get; private set; } = 0;

	private double timer = 0;

	public override void _Ready()
	{
		base._Ready();
		UpdateFrame();
	}

	public override void _Process(double delta)
	{
		base._Process(delta);
		ProcessStages(delta);
	}

	private void ProcessStages(double delta)
	{
		// when at final stage, return
		if (CurrentStage == AmountOfStages - 1) return;
		timer += delta;
		GD.Print(timer, delta);

		if (timer < SecondsPerStage) return;
		GD.Print(CurrentStage, timer, delta);
		timer -= SecondsPerStage;
		CurrentStage += 1;
		UpdateFrame();
	}

	private void UpdateFrame()
	{
		this.Frame = CurrentStage;
	}

}
