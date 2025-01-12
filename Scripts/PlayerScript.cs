using Godot;
using System;

public partial class PlayerScript : Node2D
{

	enum ANIMALS
	{
		ANIMAL1,
		ANIMAL2
	}

	ANIMALS currentAnimal = ANIMALS.ANIMAL1;

	PackedScene scene1;
	PackedScene scene2;

	Node2D currentInstantiatedScene;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		//scene1 = (PackedScene) GD.Load<PackedScene>("res://Scenes//animal1.tscn");
		//scene2 = (PackedScene) GD.Load<PackedScene>("res://Scenes//animal2.tscn");

		//PlayerInWaterEventHandler += OnWaterEnter;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		var GameManager = (GodotObject)GetNode<Node>("/root/GameManager");

		GD.Print(GameManager.Get("is_player_in_water"));
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
	}

	public override void _Input(InputEvent @event)
	{
		if (@event is InputEventKey keyEvent && keyEvent.Pressed)
		{
			if (keyEvent.Keycode == Key.A)
			{
				switchAnimal(ANIMALS.ANIMAL1);

			}

			if (keyEvent.Keycode == Key.S)
			{
				switchAnimal(ANIMALS.ANIMAL2);

			}
		}
		base._Input(@event);
	}

}
