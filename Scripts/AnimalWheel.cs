using Godot;
using System;

public partial class AnimalWheel : Control
{
	[Export] float turtleAngle;
	[Export] float heronAngle;
	[Export] float macawAngle;
	[Export] float monkeyAngle;
	[Export] float oncaAngle;
	[Export] float garoupaAngle;

	bool opened = false;

	[Export] Control centerCircle;


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

			GD.Print("length: " + (GetViewport().GetMousePosition() - (GetViewport().GetVisibleRect().Size / 2)).Length());
			if ((GetViewport().GetMousePosition() - (GetViewport().GetVisibleRect().Size / 2)).Length() < 60)
			{
				centerCircle.Visible = true;
				Visible = false;
			} else {
				centerCircle.Visible = false;
				Visible = true;
			}

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

		if (Mathf.IsZeroApprox(Mathf.AngleDifference(Mathf.Floor((Mathf.RadToDeg(Rotation) + 60) / 60.0), Mathf.Floor((turtleAngle) / 60.0))))
		{
			GameManager.Set("current_animal", GameManager.Get("TURTLE"));
			GD.Print("no gamemanager: " + GameManager.Get("current_animal"));
		}

		if (Mathf.IsZeroApprox(Mathf.AngleDifference(Mathf.Floor((Mathf.RadToDeg(Rotation) + 60) / 60.0), Mathf.Floor((heronAngle) / 60.0))))
		{
			GameManager.Set("current_animal", GameManager.Get("HERON"));
			GD.Print("no gamemanager: " + GameManager.Get("current_animal"));
		}

		if (Mathf.IsZeroApprox(Mathf.AngleDifference(Mathf.Floor((Mathf.RadToDeg(Rotation) + 60) / 60.0), Mathf.Floor((macawAngle) / 60.0))))
		{
			GameManager.Set("current_animal", GameManager.Get("MACAW"));
			GD.Print("no gamemanager: " + GameManager.Get("current_animal"));
		}

		if (Mathf.IsZeroApprox(Mathf.AngleDifference(Mathf.Floor((Mathf.RadToDeg(Rotation) + 60) / 60.0), Mathf.Floor((monkeyAngle) / 60.0))))
		{
			GameManager.Set("current_animal", GameManager.Get("MONKEY"));
			GD.Print("no gamemanager: " + GameManager.Get("current_animal"));
		}

		if (Mathf.IsZeroApprox(Mathf.AngleDifference(Mathf.Floor((Mathf.RadToDeg(Rotation) + 60) / 60.0), Mathf.Floor((oncaAngle) / 60.0))))
		{
			GameManager.Set("current_animal", GameManager.Get("ONCA"));
			GD.Print("no gamemanager: " + GameManager.Get("current_animal"));
		}

		if (Mathf.IsZeroApprox(Mathf.AngleDifference(Mathf.Floor((Mathf.RadToDeg(Rotation) + 60) / 60.0), Mathf.Floor((garoupaAngle) / 60.0))))
		{
			GameManager.Set("current_animal", GameManager.Get("GAROUPA"));
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
