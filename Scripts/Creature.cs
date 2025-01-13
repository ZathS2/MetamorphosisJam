using Godot;
using System;

public partial class Creature : CharacterBody2D
{

	[Export]
	public float Speed = 300.0f;
	

	public override void _PhysicsProcess(double delta)
	{
		Movement(delta);

		var GameManager = (GodotObject)GetNode<Node>("/root/GameManager");

		if ((bool)GameManager.Get("is_player_in_water"))
		{
			goToCheckPoint();
		}
	}

	void Movement(double delta)
	{
		Vector2 velocity = Velocity;

		// Add the gravity.
		if (!IsOnFloor())
		{
			velocity += GetGravity() * (float)delta;
		}

	
		// Get the input direction and handle the movement/deceleration.
		// As good practice, you should replace UI actions with custom gameplay actions.
		Vector2 direction = Input.GetVector("ui_left", "ui_right", "ui_up", "ui_down");
		if (direction != Vector2.Zero)
		{
			velocity.X = direction.X * Speed;
		}
		else
		{
			velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed);
		}

		Velocity = velocity;
		MoveAndSlide();
	}

	void goToCheckPoint()
	{
		var GameManager = (GodotObject)GetNode<Node>("/root/GameManager");

		GlobalPosition = (Vector2)GameManager.Get("last_checkpoint_pos");
	}
}
