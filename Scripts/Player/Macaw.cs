using Godot;
using System;

public partial class Macaw : CharacterBody2D
{
	[Export] float flySpeed;

	public override void _PhysicsProcess(double delta)
	{
		airMovement();
	}

	Vector2 getInput()
	{
		var vector = new Vector2(Input.GetAxis("ui_left", "ui_right"), Input.GetAxis("ui_up", "ui_down"));
		return vector.Normalized();
	}

	void airMovement()
	{
		Vector2 velocity = Velocity;

		var input = getInput();

		if (input != Vector2.Zero)
		{
			velocity.X = input.X * flySpeed;
			velocity.Y = input.Y * flySpeed;
		}
		else
		{
			velocity.X = Mathf.MoveToward(Velocity.X, 0, flySpeed);
			velocity.Y = Mathf.MoveToward(Velocity.Y, 0, flySpeed);
		}

		Velocity = velocity;
		MoveAndSlide();
	}
}
