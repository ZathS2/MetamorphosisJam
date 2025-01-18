using Godot;
using System;

public partial class SceneArea : Node
{
	[Export] PackedScene nextScene;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}


	public void GoToNextScene(Node2D body)
	{
		if (!body.IsInGroup("Player"))
			return;
			
		var sceneHandler = (MainSceneHandler)GetNode<Node>("/root/MainSceneHandler");
		sceneHandler.ChangeSceneTo(nextScene);
	}
}
