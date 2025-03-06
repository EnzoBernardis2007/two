using Godot;
using System;

public partial class Player : CharacterBody2D
{
	[Export] public int speed = 200;
	[Export] public int jumpForce = 300;
	[Export] public float gravity = 980; // Padrão do Godot para 2D

	public override void _PhysicsProcess(double delta)
	{
		HandleMovement(delta);
		MoveAndSlide();
	}

	private void HandleMovement(double delta)
	{
		Vector2 direction = Vector2.Zero;

		if (Input.IsActionPressed("move_right")) direction.X += 1;
		else if (Input.IsActionPressed("move_left")) direction.X -= 1;

		Velocity = new Vector2(direction.X * speed, Velocity.Y);
		
		// gravity
		if (!IsOnFloor()) Velocity += new Vector2(0, gravity * (float)delta);

		// jump
		if (Input.IsActionJustPressed("jump") && IsOnFloor()) Velocity = new Vector2(Velocity.X, -jumpForce);
	}
}
