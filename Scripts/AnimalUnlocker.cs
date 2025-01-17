using Godot;
using System;

public partial class AnimalUnlocker : Node2D
{
	[Export] int animalIndex;

	[Export] Area2D Area;

	[Export] Color turtleColor;
	[Export] Color heronColor;
	[Export] Color macawColor;
	[Export] Color monkeyColor;
	[Export] Color oncaColor;
	[Export] Color garoupaColor;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		var GameManager = (GodotObject)GetNode<Node>("/root/GameManager");

		if (animalIndex == (int)GameManager.Get("TURTLE"))
		{
			Modulate = turtleColor;
		}
		else if (animalIndex == (int)GameManager.Get("HERON"))
		{
			Modulate = heronColor;
		}
		else if (animalIndex == (int)GameManager.Get("MACAW"))
		{
			Modulate = macawColor;
		}
		else if (animalIndex == (int)GameManager.Get("MONKEY"))
		{
			Modulate = monkeyColor;
		}
		else if (animalIndex == (int)GameManager.Get("ONCA"))
		{
			Modulate = oncaColor;
		}
		else if (animalIndex == (int)GameManager.Get("GAROUPA"))
		{
			Modulate = garoupaColor;
		}

	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if (Visible)
		{
			foreach (Node2D body in Area.GetOverlappingBodies())
			{
				if (body.IsInGroup("Player"))
				{
					GD.Print("desbloqueou animal");
					var AnimalBlocker = (HandleAnimalBlock)GetNode<Node>("/root/HandleAnimalBlock");
					var GameManager = (GodotObject)GetNode<Node>("/root/GameManager");
					
					AnimalBlocker.UnlockAnimal(animalIndex);
					GameManager.Call("collectUnlocker", this);
					Hide();
				}
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
