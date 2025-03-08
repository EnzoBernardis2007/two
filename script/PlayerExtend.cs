using Godot;
using System;

public partial class PlayerExtend : Player
{
	[Export] public CharacterBody2D otherPlayer;
	private Player otherPlayerScript;
	[Export] public SceneManager sceneManager;
	
	public override void _Ready() 
	{
		base._Ready();
		otherPlayerScript = otherPlayer as Player;
	}

	public override void _PhysicsProcess(double delta)
	{
		base._PhysicsProcess(delta); 

		for (int i = 0; i < GetSlideCollisionCount(); i++)
		{
			KinematicCollision2D collision = GetSlideCollision(i);
			if (collision.GetCollider() == otherPlayer && hasHearth && otherPlayerScript.hasHearth)
			{
				sceneManager.ShowEndScene();
				break;
			}
		}
	}
}
