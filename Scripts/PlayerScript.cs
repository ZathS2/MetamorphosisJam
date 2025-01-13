using Godot;
using System;

public partial class PlayerScript : Node2D
{

	[Export] PackedScene creatureScene;
	[Export] PackedScene turtleScene;

	PackedScene currentAnimalScene;

	Node2D currentInstantiatedScene;

	GodotObject GameManager;

	int instantiatedAnimal = 999;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		GameManager = (GodotObject)GetNode<Node>("/root/GameManager");
		updateAnimal();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		updateAnimal();
	}

	void updateAnimal()
	{
		int currentAnimal = (int)GameManager.Get("current_animal");

		if (currentAnimal == instantiatedAnimal)
		{
			return;
		}

		instantiatedAnimal = currentAnimal;

		if (instantiatedAnimal == (int)GameManager.Get("CREATURE"))
		{
			if (currentInstantiatedScene != null)
			{
				GlobalPosition = currentInstantiatedScene.GlobalPosition;
				RemoveChild(currentInstantiatedScene);
			}

			currentInstantiatedScene = (Node2D)creatureScene.Instantiate();

			AddChild(currentInstantiatedScene);

		} else if (instantiatedAnimal == (int)GameManager.Get("TURTLE")) {

			if (currentInstantiatedScene != null)
			{
				GlobalPosition = currentInstantiatedScene.GlobalPosition;
				RemoveChild(currentInstantiatedScene);
			}

			currentInstantiatedScene = (Node2D)turtleScene.Instantiate();

			AddChild(currentInstantiatedScene);
		}
	}

	/*void switchAnimal(ANIMALS animal)
	{
		if (animal == currentAnimal)
			return;

		currentAnimal = animal;

		switch (currentAnimal)
		{
			case (ANIMALS.ANIMAL1):

				if (currentInstantiatedScene != null)
				{
					GlobalPosition = currentInstantiatedScene.GlobalPosition;
					RemoveChild(currentInstantiatedScene);
				}


				currentInstantiatedScene = (Node2D)scene1.Instantiate();

				AddChild(currentInstantiatedScene);



				break;

			case (ANIMALS.ANIMAL2):

				if (currentInstantiatedScene != null)
				{
					GlobalPosition = currentInstantiatedScene.GlobalPosition;
					RemoveChild(currentInstantiatedScene);
				}

				currentInstantiatedScene = (Node2D)scene2.Instantiate();

				AddChild(currentInstantiatedScene);




				break;
		}
	}*/

}
