using Godot;
using System;

public partial class AnimalUnlocker : Node2D
{
	[Export] int animalIndex;

	[Export] Area2D Area;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		foreach (Node2D body in Area.GetOverlappingBodies())
		{
			if (body.IsInGroup("Player"))
			{
				GD.Print("desbloqueou animal");
				var AnimalBlocker = (HandleAnimalBlock)GetNode<Node>("/root/HandleAnimalBlock");

				AnimalBlocker.UnlockAnimal(animalIndex);

				QueueFree();
			}
		}
	}

	/*public void onBodyEntered(Node2D body)
	{
		if (body.IsInGroup("Player"))
		{
			GD.Print("desbloqueou animal");
			var AnimalBlocker = (HandleAnimalBlock)GetNode<Node>("/root/HandleAnimalBlock");

			AnimalBlocker.UnlockAnimal(animalIndex);

			QueueFree();
		}
	}*/
}
