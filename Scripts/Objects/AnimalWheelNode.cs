using Godot;
using System;

public partial class AnimalWheelNode : TextureRect
{
	[Export] int id;

	[Export] Color color;

	Color original;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		original = SelfModulate;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		var AnimalBlocker = (HandleAnimalBlock)GetNode<Node>("/root/HandleAnimalBlock");

		if (AnimalBlocker.isAnimalUnlocked(id))
		{
			SelfModulate = original;
		}
		else
		{
			SelfModulate = new Color(0, 0, 0, 1f);
		}
	}
}
