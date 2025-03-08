using Godot;
using System;

public partial class PlayerExtend : Player
{
	[Export] public CharacterBody2D otherPlayer;
	[Export] public SceneManager sceneManager;

	public override void _PhysicsProcess(double delta)
	{
		base._PhysicsProcess(delta); // Chama o método base primeiro

		// Verifica se houve colisão com outro jogador
		for (int i = 0; i < GetSlideCollisionCount(); i++)
		{
			KinematicCollision2D collision = GetSlideCollision(i);
			if (collision.GetCollider() == otherPlayer)
			{
				sceneManager.ShowEndScene();
				break;
			}
		}
	}
}
