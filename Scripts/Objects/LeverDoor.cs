using Godot;
using System;

public partial class LeverDoor : CharacterBody2D
{
	[Export] bool isDoorClosed = true;
	[Export] float openHeight;

	[Export] Node2D lever;

	Vector2 highPosition;
	Vector2 lowPosition;

	float t = 0;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		if (lever != null)
		{
			LeverScript leverScript = (LeverScript)lever.FindChild("Area2D");
			leverScript.PushedLever += OnLeverPulled;
		}

		lowPosition = GlobalPosition;
		highPosition = GlobalPosition + new Vector2(0, openHeight);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if (t < 1.0)
		{
			t += (float)delta;
		}
		else
		{
			t = 1;
		}

		if (isDoorClosed)
		{
			GlobalPosition = new Vector2(GlobalPosition.X, Mathf.Lerp(highPosition.Y, lowPosition.Y, t));
		}
		else
		{
			GlobalPosition = new Vector2(GlobalPosition.X, Mathf.Lerp(lowPosition.Y, highPosition.Y, t));
		}
	}

	public void OnLeverPulled()
	{
		isDoorClosed = !isDoorClosed;
		t = 0;
	}

}
