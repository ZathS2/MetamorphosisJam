using Godot;
using System;

public partial class Mico : CharacterBody2D
{
	[Export] public float Speed = 300.0f;
	public const float JumpVelocity = -400.0f;

	[Export] float jumpOutOfRopeVel;

	Timer timer;

	public override void _Ready() {
		timer = new Timer();
		timer.SetOneShot(true);

		AddChild(timer);
		


		base._Ready();
	}

	float lastAngleOfRope = 9999;
	float dAngle = 0;

	public override void _PhysicsProcess(double delta)
	{
		var GameManager = (GodotObject)GetNode<Node>("/root/GameManager");
		
		float dir = Input.GetAxis("ui_left", "ui_right");


		if ((bool)GameManager.Get("is_on_rope") && timer.TimeLeft == 0)
		{
			GlobalPosition = ((Area2D)GameManager.Get("rope_seg_area")).GlobalPosition;

			if (Input.IsActionJustPressed("ui_accept") && dir != 0)
			{
				Variant variant = true;
				GameManager.Set("jumped_out_of_rope", variant);
				var velocity = new Vector2(jumpOutOfRopeVel * dir,-jumpOutOfRopeVel);
				Velocity = velocity;
				MoveAndSlide();
				timer.WaitTime = 0.5f;
				timer.Start();
			}

		} else if (timer.TimeLeft != 0){
			var velocity = new Vector2(jumpOutOfRopeVel * dir,-jumpOutOfRopeVel);
			Velocity = velocity;
			MoveAndSlide();
		} else {
			movement(delta);
		}
	}

	void movement(double delta)
	{
		Vector2 velocity = Velocity;

		// Add the gravity.
		if (!IsOnFloor())
		{
			velocity += GetGravity() * (float)delta;
		}

		// Handle Jump.
		if (Input.IsActionJustPressed("ui_accept") && IsOnFloor())
		{
			velocity.Y = JumpVelocity;
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
}
