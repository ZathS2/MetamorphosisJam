using Godot;
using System;

public partial class Turtle : CharacterBody2D
{
	public const float groundSpeed = 300.0f;
	public const float waterSpeed = 500.0f;

	float gravity = (float)ProjectSettings.GetSetting("physics/2d/default_gravity"); 

	Vector2 getInput()
	{
		var vector = new Vector2(Input.GetAxis("ui_left", "ui_right"), Input.GetAxis("ui_up", "ui_down"));
		return vector.Normalized();
	}

	public override void _PhysicsProcess(double delta)
	{
		setFloating();

		switch (MotionMode)
		{
			case MotionModeEnum.Grounded:
				groundMovement(delta);
				break;
			
			case MotionModeEnum.Floating:
				waterMovement();
				break;
		}
		
	}

	Vector2 addGravity(Vector2 velocity, double delta)
	{
		if (!IsOnFloor())
			velocity.Y += gravity * (float)delta;
		
		return velocity;
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

	void waterMovement()
	{
		Vector2 velocity = Velocity;

		var input = getInput();

		if (input != Vector2.Zero)
		{
			velocity.X = input.X * waterSpeed;
			velocity.Y = input.Y * waterSpeed;
		} else {
			velocity.X = Mathf.MoveToward(Velocity.X, 0, waterSpeed);
			velocity.Y = Mathf.MoveToward(Velocity.Y, 0, waterSpeed);
		}
		
		Velocity = velocity;
		MoveAndSlide();
	}

	void setGrounded()
	{
		MotionMode = MotionModeEnum.Grounded;
	}

	void setFloating()
	{
		MotionMode = MotionModeEnum.Floating;
	}
}
