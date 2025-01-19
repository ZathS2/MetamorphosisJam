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
		var GameManager = (GodotObject)GetNode<Node>("/root/GameManager");
		var AnimalBlock = (HandleAnimalBlock)GetNode<Node>("/root/HandleAnimalBlock");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if (Input.IsActionJustPressed("toggle_wheel"))
		{
			toggleMenu();
		}

		if (Input.IsActionJustPressed("select_animal") && opened)
		{
			SelectAnimal();
			toggleMenu();
		}

		if (opened)
		{
			var angleToCenter = (GetViewport().GetMousePosition() - (GetViewport().GetVisibleRect().Size / 2)).Angle();

			//GD.Print("length: " + (GetViewport().GetMousePosition() - (GetViewport().GetVisibleRect().Size / 2)).Length());
			if ((GetViewport().GetMousePosition() - (GetViewport().GetVisibleRect().Size / 2)).Length() < 60)
			{
				centerCircle.Visible = true;
				Visible = false;
			}
			else
			{
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
		var AnimalBlock = (HandleAnimalBlock)GetNode<Node>("/root/HandleAnimalBlock");

		if ((int)GameManager.Get("current_animal") == (int)GameManager.Get("TURTLE"))
		{
			GameManager.Set("current_breath", 10f);
			GameManager.Set("just_changed_to_turtle", true);
		}

		if ((GetViewport().GetMousePosition() - (GetViewport().GetVisibleRect().Size / 2)).Length() < 60)
		{
			GameManager.Set("current_animal", GameManager.Get("CREATURE"));
			GD.Print("no gamemanager: " + GameManager.Get("current_animal"));
			return;
		}

		if (Mathf.IsZeroApprox(Mathf.AngleDifference(Mathf.Floor((Mathf.RadToDeg(Rotation) + 60) / 60.0), Mathf.Floor((turtleAngle) / 60.0))))
		{
			if (!AnimalBlock.isAnimalUnlocked((int)GameManager.Get("TURTLE")))
			{
				GD.Print("ta travado TURTLE");
				return;
			}

			GameManager.Set("current_animal", GameManager.Get("TURTLE"));
			GD.Print("no gamemanager: " + GameManager.Get("current_animal"));
		}

		if (Mathf.IsZeroApprox(Mathf.AngleDifference(Mathf.Floor((Mathf.RadToDeg(Rotation) + 60) / 60.0), Mathf.Floor((heronAngle) / 60.0))))
		{
			if (!AnimalBlock.isAnimalUnlocked((int)GameManager.Get("HERON")))
			{
				GD.Print("ta travado HERON");
				return;
			}

			GameManager.Set("current_animal", GameManager.Get("HERON"));
			GD.Print("no gamemanager: " + GameManager.Get("current_animal"));
		}

		if (Mathf.IsZeroApprox(Mathf.AngleDifference(Mathf.Floor((Mathf.RadToDeg(Rotation) + 60) / 60.0), Mathf.Floor((macawAngle) / 60.0))))
		{
			if (!AnimalBlock.isAnimalUnlocked((int)GameManager.Get("MACAW")))
			{
				GD.Print("ta travado MACAW");
				return;
			}

			GD.Print("MACAW");

			GameManager.Set("current_animal", GameManager.Get("MACAW"));
			GD.Print("no gamemanager: " + GameManager.Get("current_animal"));
		}

		if (Mathf.IsZeroApprox(Mathf.AngleDifference(Mathf.Floor((Mathf.RadToDeg(Rotation) + 60) / 60.0), Mathf.Floor((monkeyAngle) / 60.0))))
		{
			if (!AnimalBlock.isAnimalUnlocked((int)GameManager.Get("MONKEY")))
			{
				GD.Print("ta travado MONKEY");
				return;
			}

			GameManager.Set("current_animal", GameManager.Get("MONKEY"));
			GD.Print("no gamemanager: " + GameManager.Get("current_animal"));
		}

		if (Mathf.IsZeroApprox(Mathf.AngleDifference(Mathf.Floor((Mathf.RadToDeg(Rotation) + 60) / 60.0), Mathf.Floor((oncaAngle) / 60.0))))
		{
			if (!AnimalBlock.isAnimalUnlocked((int)GameManager.Get("ONCA")))
			{
				GD.Print("ta travado ONCA");
				return;
			}

			GameManager.Set("current_animal", GameManager.Get("ONCA"));
			GD.Print("no gamemanager: " + GameManager.Get("current_animal"));
		}

		if (Mathf.IsZeroApprox(Mathf.AngleDifference(Mathf.Floor((Mathf.RadToDeg(Rotation) + 60) / 60.0), Mathf.Floor((garoupaAngle) / 60.0))))
		{
			if (!AnimalBlock.isAnimalUnlocked((int)GameManager.Get("GAROUPA")))
			{
				GD.Print("ta travado GAROUPA");
				return;
			}

			if (!(bool)GameManager.Get("is_player_in_water"))
			{
				GD.Print("Não ta na agua");
				return;
			}

			GameManager.Set("current_animal", GameManager.Get("GAROUPA"));
			GD.Print("no gamemanager: " + GameManager.Get("current_animal"));
		}
	}
}
