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
		
		Player player = obj as Player;
		if (player != null && player.hearthType == hearthType) {
			player.hasHearth = true;
			QueueFree();
		}
	}
}
