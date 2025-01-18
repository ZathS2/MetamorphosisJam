using Godot;
using System;

public partial class MainSceneHandler : Node
{
	PackedScene currentScene;

	// Called when the node enters the scene tree for the first time.
	public void ChangeSceneTo(PackedScene scene)
	{
		currentScene = scene;
	}

	public PackedScene GetCurrentScene()
	{
		return currentScene;
	}
}
