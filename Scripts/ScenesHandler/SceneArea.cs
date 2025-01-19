using Godot;
using System;

public partial class SceneArea : Node
{
	[Export] PackedScene nextScene;

	[Export] AudioStreamPlayer audio;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}


	public async void GoToNextScene(Node2D body)
	{
		if (!body.IsInGroup("Player"))
			return;

		if (audio.Playing == false)
			audio.Play();

		GD.Print("VAI TOMA NO CU " + audio.Playing);

		await ToSignal(audio, "finished");

		var sceneHandler = (MainSceneHandler)GetNode<Node>("/root/MainSceneHandler");
		sceneHandler.ChangeSceneTo(nextScene);

	}
}
