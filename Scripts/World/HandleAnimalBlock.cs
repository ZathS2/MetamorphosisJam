using Godot;
using System;

public partial class HandleAnimalBlock : Node
{
	public void UnlockAnimal(int animal)
	{
		var GameManager = (GodotObject)GetNode<Node>("/root/GameManager");

		animal -= 1;

		int status = (int)GameManager.Get("animal_status");
		status |= (1 << animal);
		GameManager.Set("animal_status", status);
		GD.Print($"Desbloqueando animal {animal + 1}. Novo status: {Convert.ToString(status, 2).PadLeft(8, '0')}");
	}

	public void LockAnimal(int animal)
	{
		var GameManager = (GodotObject)GetNode<Node>("/root/GameManager");

		animal -= 1;

		int status = (int)GameManager.Get("animal_status");
		status &= (byte)~(1 << animal);
		GameManager.Set("animal_status", status);
		GD.Print($"Bloqueando animal {animal}. Novo status: {Convert.ToString(status, 2).PadLeft(8, '0')}");
	}

	public bool isAnimalUnlocked(int animal)
	{
		var GameManager = (GodotObject)GetNode<Node>("/root/GameManager");

		animal -= 1;

		int status = (int)GameManager.Get("animal_status");
		return (status & (1 << animal)) != 0;
	}

	public void UnlockAll()
	{
		var GameManager = (GodotObject)GetNode<Node>("/root/GameManager");
		int status = 255;
		GameManager.Set("animal_status", status);
		GD.Print($"Desbloqueado todos, Status: {Convert.ToString(status, 2).PadLeft(8, '0')}");
	}

}
