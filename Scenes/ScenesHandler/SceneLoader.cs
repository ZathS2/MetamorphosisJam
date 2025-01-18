using Godot;
using System;

public partial class SceneLoader : Node2D
{
	Node currentInstantiatedScene;
	PackedScene currentScene;

	MainSceneHandler sceneHandler;

	[Export] PackedScene mainMenuScene;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		sceneHandler = (MainSceneHandler)GetNode<Node>("/root/MainSceneHandler");

		sceneHandler.ChangeSceneTo(mainMenuScene);

		currentScene = sceneHandler.GetCurrentScene();
		currentInstantiatedScene = currentScene.Instantiate();

		AddChild(currentInstantiatedScene);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if (currentScene != sceneHandler.GetCurrentScene())
		{
			UpdateScene();
		}
	}

	void UpdateScene()
	{
		currentScene = sceneHandler.GetCurrentScene();

		RemoveChild(currentInstantiatedScene);

		currentInstantiatedScene = currentScene.Instantiate();

		AddChild(currentInstantiatedScene);
	}
}
