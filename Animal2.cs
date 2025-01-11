using Godot;
using System;

public partial class Animal2 : CharacterBody2D
{
	[Export] private float accel;
	[Export] private float maxSpeed;
	[Export] private float dAccel;

	Vector2 getInput()
	{
		return new Vector2(Input.GetAxis("ui_left","ui_right"), 
			Input.GetAxis("ui_up","ui_down")).Normalized();
	}	

	void playerMovement(double delta)
	{
		var input = getInput();

		Velocity = input * maxSpeed;

		Velocity.LimitLength(maxSpeed);

		MoveAndSlide();
	}

	public override void _PhysicsProcess(double delta)
	{
		playerMovement(delta);
	}

	
}


