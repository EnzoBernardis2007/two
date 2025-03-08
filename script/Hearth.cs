using Godot;
using System;

public partial class Hearth : Area2D
{
	[Export] public Enums.HearthType hearthType;
	
	public override void _Ready() 
	{
		Connect("body_entered", new Callable(this, nameof(OnBodyEntered)));
	}
	
	public void OnBodyEntered(Node2D obj)
	{
		if (!obj.IsInGroup("player")) return;

		if (obj is Player player && player.hearthType == hearthType)
		{
			player.hasHearth = true;
			QueueFree();
		}
		else if (obj is PlayerExtend playerExtend && playerExtend.hearthType == hearthType)
		{
			playerExtend.hasHearth = true;
			QueueFree();
		}
	}


}
