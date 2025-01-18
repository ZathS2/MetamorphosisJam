using Godot;
using System;

public partial class ButtonHandler : Node
{
	// Called when the node enters the scene tree for the first time.

	[Export] PackedScene initialScene;
	MainSceneHandler sceneHandler;
	public override void _Ready()
	{
		sceneHandler = (MainSceneHandler)GetNode<Node>("/root/MainSceneHandler");
	}
	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void PlayPressed()
	{
		GD.Print("Play");
		sceneHandler.ChangeSceneTo(initialScene);
	}

	public void OptionsPressed()
	{
		GD.Print("Options");
	}

	public void QuitPressed()
	{
		GetTree().Quit();
	}

}
