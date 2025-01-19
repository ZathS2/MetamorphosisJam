using Godot;
using System;

public partial class MicoHole : Node2D
{
	public Area2D enterArea;

	[Export] MicoHole exitHole;


	GodotObject GameManager;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		GameManager = (GodotObject)GetNode<Node>("/root/GameManager");

		enterArea = (Area2D)FindChild("Area2D");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		foreach (Node body in enterArea.GetOverlappingBodies())
		{
			if (body.IsInGroup("Player") && (int)GameManager.Get("current_animal") == (int)GameManager.Get("MONKEY") && Input.IsActionJustPressed("interact"))
			{
				((Node2D)body).GlobalPosition = exitHole.enterArea.GlobalPosition;
			}
		}

	}
}
