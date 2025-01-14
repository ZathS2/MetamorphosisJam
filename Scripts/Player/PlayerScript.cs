using Godot;
using System;

public partial class PlayerScript : Node2D
{

	[Export] PackedScene creatureScene;
	[Export] PackedScene turtleScene;
	[Export] PackedScene heronScene;
	[Export] PackedScene macawScene;
	[Export] PackedScene monkeyScene;
	[Export] PackedScene oncaScene;
	[Export] PackedScene garoupaScene;

	PackedScene currentAnimalScene;

	Node2D currentInstantiatedScene;

	GodotObject GameManager;

	int instantiatedAnimal = 999;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		GameManager = (GodotObject)GetNode<Node>("/root/GameManager");
		var AnimalBlock = (HandleAnimalBlock)GetNode<Node>("/root/HandleAnimalBlock");
		AnimalBlock.UnlockAll();
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

		}
		else if (instantiatedAnimal == (int)GameManager.Get("TURTLE"))
		{

			if (currentInstantiatedScene != null)
			{
				GlobalPosition = currentInstantiatedScene.GlobalPosition;
				RemoveChild(currentInstantiatedScene);
			}

			currentInstantiatedScene = (Node2D)turtleScene.Instantiate();

			AddChild(currentInstantiatedScene);
		}
		else if (instantiatedAnimal == (int)GameManager.Get("HERON"))
		{

			if (currentInstantiatedScene != null)
			{
				GlobalPosition = currentInstantiatedScene.GlobalPosition;
				RemoveChild(currentInstantiatedScene);
			}

			currentInstantiatedScene = (Node2D)heronScene.Instantiate();

			AddChild(currentInstantiatedScene);
		}
		else if (instantiatedAnimal == (int)GameManager.Get("MACAW"))
		{

			if (currentInstantiatedScene != null)
			{
				GlobalPosition = currentInstantiatedScene.GlobalPosition;
				RemoveChild(currentInstantiatedScene);
			}

			currentInstantiatedScene = (Node2D)macawScene.Instantiate();

			AddChild(currentInstantiatedScene);
		}
		else if (instantiatedAnimal == (int)GameManager.Get("MONKEY"))
		{

			if (currentInstantiatedScene != null)
			{
				GlobalPosition = currentInstantiatedScene.GlobalPosition;
				RemoveChild(currentInstantiatedScene);
			}

			currentInstantiatedScene = (Node2D)monkeyScene.Instantiate();

			AddChild(currentInstantiatedScene);
		}
		else if (instantiatedAnimal == (int)GameManager.Get("ONCA"))
		{

			if (currentInstantiatedScene != null)
			{
				GlobalPosition = currentInstantiatedScene.GlobalPosition;
				RemoveChild(currentInstantiatedScene);
			}

			currentInstantiatedScene = (Node2D)oncaScene.Instantiate();

			AddChild(currentInstantiatedScene);
		}
		else if (instantiatedAnimal == (int)GameManager.Get("GAROUPA"))
		{

			if (currentInstantiatedScene != null)
			{
				GlobalPosition = currentInstantiatedScene.GlobalPosition;
				RemoveChild(currentInstantiatedScene);
			}

			currentInstantiatedScene = (Node2D)garoupaScene.Instantiate();

			AddChild(currentInstantiatedScene);
		}
	}


}
