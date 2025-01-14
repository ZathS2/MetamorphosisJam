using Godot;
using System;

public partial class Gaivota : CharacterBody2D
{
	[Export] float groundSpeed;
	[Export] float flySpeed;

	bool isFlying = false;

	float gravity = (float)ProjectSettings.GetSetting("physics/2d/default_gravity"); 

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _PhysicsProcess(double delta)
	{

		if (!isFlying)
		{
			setGrounded();
			groundMovement(delta);
			if (Input.IsActionPressed("start_fly"))
			{
				isFlying = true;
				GlobalPosition += UpDirection * 20;
			}
		} else {
			airMovement();

			if (IsOnFloor())
			{
				isFlying = false;
			}
		}
		
		

	}

	Vector2 addGravity(Vector2 velocity, double delta)
	{
		if (!IsOnFloor())
			velocity.Y += gravity * (float)delta;
		
		return velocity;
	}

	Vector2 getInput()
	{
		var vector = new Vector2(Input.GetAxis("ui_left", "ui_right"), Input.GetAxis("ui_up", "ui_down"));
		return vector.Normalized();
	}

	void groundMovement(double delta)
	{
		Vector2 velocity = Velocity;

		velocity = addGravity(velocity, delta);

		var input = getInput();

		if (input != Vector2.Zero)
		{
			velocity.X = input.X * groundSpeed;
		} else {
			velocity.X = Mathf.MoveToward(Velocity.X, 0, groundSpeed);
		}

		Velocity = velocity;
		MoveAndSlide();
	}

	void airMovement()
	{
		Vector2 velocity = Velocity;

		var input = getInput();

		if (input != Vector2.Zero)
		{
			velocity.X = input.X * flySpeed;
			velocity.Y = input.Y * flySpeed;
		} else {
			velocity.X = Mathf.MoveToward(Velocity.X, 0, flySpeed);
			velocity.Y = Mathf.MoveToward(Velocity.Y, 0, flySpeed);
		}
		
		Velocity = velocity;
		MoveAndSlide();
	}

	void setGrounded()
	{
		MotionMode = MotionModeEnum.Grounded;
	}

}
