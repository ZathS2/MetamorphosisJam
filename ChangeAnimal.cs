using Godot;
using System;

public partial class ChangeAnimal : Node2D
{

	enum ANIMALS
	{
		ANIMAL1,
		ANIMAL2
	}

	ANIMALS currentAnimal = ANIMALS.ANIMAL1;

	PackedScene scene1;
	PackedScene scene2;

	Node currentInstantiatedScene;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		scene1 = (PackedScene) GD.Load<PackedScene>("res://animal1.tscn");
		scene2 = (PackedScene) GD.Load<PackedScene>("res://animal2.tscn");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{	

		
		

	}

	void switchAnimal(ANIMALS animal)
	{
		if (animal == currentAnimal)
			return;

		currentAnimal = animal;
		
		switch (currentAnimal)
		{
			case (ANIMALS.ANIMAL1):
				if (currentInstantiatedScene != null)
					currentInstantiatedScene.QueueFree();
				currentInstantiatedScene = scene1.Instantiate();
				AddChild(currentInstantiatedScene);
				break;

			case (ANIMALS.ANIMAL2):
				if (currentInstantiatedScene != null)
					currentInstantiatedScene.QueueFree();
				currentInstantiatedScene = scene2.Instantiate();
				AddChild(currentInstantiatedScene);
				break;
		}
	}

	public override void _Input(InputEvent @event) {
		if (@event is InputEventKey keyEvent && keyEvent.Pressed)
		{
			if (keyEvent.Keycode == Key.A)
			{
				switchAnimal(ANIMALS.ANIMAL1);
				GD.Print("ANIMAL 1");
			}

			if (keyEvent.Keycode == Key.S)
			{
				switchAnimal(ANIMALS.ANIMAL2);
				GD.Print("ANIMAL 2");
			}
		}
		base._Input(@event);
	}
}
