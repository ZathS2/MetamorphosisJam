using Godot;
using System;

public partial class LeverScript : Area2D
{
	AnimationPlayer anim;

	[Signal]
	public delegate void PushedLeverEventHandler();

	bool isLeverDown = false;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		anim = (AnimationPlayer)GetParent().FindChild("AnimationPlayer");

	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		var GameManager = (GodotObject)GetNode<Node>("/root/GameManager");

		foreach (Node2D body in GetOverlappingBodies())
		{
			if (body.GetGroups().Contains("Player") && ((int)GameManager.Get("current_animal") == (int)GameManager.Get("MACAW") ||
				(int)GameManager.Get("current_animal") == (int)GameManager.Get("CREATURE") ||
				(int)GameManager.Get("current_animal") == (int)GameManager.Get("MONKEY")))
			{
				if (Input.IsActionJustPressed("interact"))
				{
					isLeverDown = !isLeverDown;

					EmitSignal(SignalName.PushedLever);

					if (isLeverDown)
					{
						anim.Play("push_lever_anim");
					}
					else
					{
						anim.PlayBackwards("push_lever_anim");
					}
				}
			}
		}
	}



}
