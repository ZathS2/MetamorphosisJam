using Godot;
using System;

public partial class AnimalWheel : Control
{
	[Export] float creatureAngle;
	[Export] float turtleAngle;

	bool opened = false;


	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if (opened)
		{
			var angleToCenter = (GetViewport().GetMousePosition() - (GetViewport().GetVisibleRect().Size / 2)).Angle();

			Rotation = convertAngle(angleToCenter);
		}
	}

	void toggleMenu()
	{
		opened = !opened;
		
		var parent = (Control)GetParent();

		parent.Visible = opened;
		
	}

	float convertAngle(float angle)
	{
		return (float)Mathf.DegToRad(Mathf.Floor((Mathf.RadToDeg(angle) + 60) / 60.0) * 60);
	}

	void SelectAnimal()
	{
		var GameManager = (GodotObject)GetNode<Node>("/root/GameManager");

		if (Mathf.IsZeroApprox(Mathf.AngleDifference(Mathf.Floor((Mathf.RadToDeg(Rotation) + 60) / 60.0),  Mathf.Floor((creatureAngle) / 60.0))))
		{
			GameManager.Set("current_animal", GameManager.Get("CREATURE"));
			GD.Print("no gamemanager: " + GameManager.Get("current_animal"));
		}

		if (Mathf.IsZeroApprox(Mathf.AngleDifference(Mathf.Floor((Mathf.RadToDeg(Rotation) + 60) / 60.0), Mathf.Floor((turtleAngle) / 60.0))))
		{
			GameManager.Set("current_animal", GameManager.Get("TURTLE"));
			GD.Print("no gamemanager: " + GameManager.Get("current_animal"));
		}
	}

	public override void _Input(InputEvent @event) {

		if (@event is InputEventKey keyEvent)
		{
			if (keyEvent.Keycode == Key.E && keyEvent.Pressed)
			{
				toggleMenu();
			}
		}			

		if (@event is InputEventMouseButton mouseEvent && opened == true)
		{
			if (mouseEvent.ButtonIndex == MouseButton.Left && mouseEvent.Pressed)
			{
				//GD.Print("index: " + Mathf.Floor((Mathf.RadToDeg(Rotation) + 60) / 60.0));
				//GD.Print("creature: " + Mathf.Floor((creatureAngle) / 60.0));
				SelectAnimal();
				toggleMenu();
			}
		}

		base._Input(@event);
	}
}
