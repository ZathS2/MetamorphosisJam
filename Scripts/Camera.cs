using Godot;
using System;

public partial class Camera : Camera2D
{
	[Export] Node2D follower;

	[Export] Marker2D up_left_marker;
	[Export] Marker2D down_right_marker;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		LimitBottom = (int)Math.Floor(down_right_marker.GlobalPosition.Y);
		LimitTop = (int)Math.Floor(up_left_marker.GlobalPosition.Y);
		LimitLeft = (int)Math.Floor(up_left_marker.GlobalPosition.X);
		LimitRight = (int)Math.Floor(down_right_marker.GlobalPosition.X);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{

		var playerScript = (PlayerScript)follower;
		GlobalPosition = playerScript.scenePos;
	}
}
