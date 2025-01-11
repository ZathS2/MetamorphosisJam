using Godot;
using System;

public partial class Turtle : CharacterBody2D
{
	public const float groundSpeed = 300.0f;
	public const float waterSpeed = 500.0f;

	float gravity = (float)ProjectSettings.GetSetting("physics/2d/default_gravity"); 

	float currentBreathTime;
	
	[Export] private float maxBreathTime;
	[Export] private float increaseRateBreathTime;

	Timer timer;

	Polygon2D breathBar;

	float maxHealthBarWidth;
	

	Vector2 getInput()
	{
		var vector = new Vector2(Input.GetAxis("ui_left", "ui_right"), Input.GetAxis("ui_up", "ui_down"));
		return vector.Normalized();
	}

	public override void _Ready()
	{
		timer = new Timer();
		timer.SetOneShot(true);
		AddChild(timer);

		currentBreathTime = maxBreathTime;
		resetAndStartBreathTimer();

		breathBar = (Polygon2D) FindChild("BreathBar");

		var vertices = breathBar.GetPolygon();

		var x0Vertice = vertices[0];
		for (int i = 1; i < vertices.Length; i++)
		{
			if (vertices[i].X == x0Vertice.X)
				continue;
			
			maxHealthBarWidth = vertices[i].X - x0Vertice.X;
			break;
		}
		
	}
	
	public override void _Process(double delta)
	{
		currentBreathTime = (float)timer.TimeLeft;
		GD.Print("breath: " + currentBreathTime);

		updateBreathBar();
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

	void resetAndStartBreathTimer()
	{
		timer.WaitTime = currentBreathTime;
		timer.Start();
	}

	void increaseBreathTime()
	{
		if (currentBreathTime < maxBreathTime)
		{
			currentBreathTime += increaseRateBreathTime;
		}
	}

	void updateBreathBar()
	{
		var vertices = breathBar.GetPolygon();

		double ratio = currentBreathTime / maxBreathTime;

		double healthBarWidth = maxHealthBarWidth * ratio;

		Vector2 leftDownVertice = vertices[0]; 
		Vector2 leftUpVertice = vertices[1];

		Vector2 rightUpVertice = leftUpVertice + new Vector2((float)healthBarWidth,0);
		Vector2 rightDownVertice = leftDownVertice + new Vector2((float)healthBarWidth,0);

		breathBar.SetPolygon(new Vector2[]{leftDownVertice, leftUpVertice, rightUpVertice, rightDownVertice});
		
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
