using Godot;
using System;

public partial class PlayerDetector : Area2D
{
	private int playerCount = 0;
	[Export] public StaticBody2D door;

	public override void _Ready()
	{
		Connect("body_entered", new Callable(this, nameof(OnBodyEntered)));
		Connect("body_exited", new Callable(this, nameof(OnBodyExited)));
	}

	private void OnBodyEntered(Node2D obj)
	{
		if (obj.IsInGroup("player"))
		{
			playerCount++;
			door.Scale = new Vector2(door.Scale.X, 0);
		}
	}

	private void OnBodyExited(Node2D obj)
	{
		if (obj.IsInGroup("player"))
		{
			playerCount--;
			if (playerCount <= 0) {
				door.Scale = new Vector2(door.Scale.X, 5);
			}
		}
	}
}
