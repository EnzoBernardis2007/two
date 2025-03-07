using Godot;
using System;

public partial class Player : CharacterBody2D
{
	[Export] public Enums.HearthType hearthType;
	[Export] public bool hasHearth = false;
	[Export] public int speed = 200;
	[Export] public int jumpForce = 300;
	[Export] public float gravity = 980;
	[Export] public bool active = false;
	
	public override void _Ready() 
	{
		AddToGroup("player");
	}

	public override void _PhysicsProcess(double delta)
	{
		ApplyGravity(delta);
		ChangeCharacter();
		
		if (active) {
			HandleMovement(delta);
		} else if (IsOnFloor()) {
			Velocity = new Vector2(0, Velocity.Y);
		}
		
		MoveAndSlide();
	}
	
	private void ApplyGravity(double delta) 
	{
		if (!IsOnFloor()) Velocity += new Vector2(0, gravity * (float)delta);
	}

	private void HandleMovement(double delta)
	{
		Vector2 direction = Vector2.Zero;

		if (Input.IsActionPressed("move_right")) direction.X += 1;
		if (Input.IsActionPressed("move_left")) direction.X -= 1;

		Velocity = new Vector2(direction.X * speed, Velocity.Y);
		
		// jump
		if (Input.IsActionJustPressed("jump") && IsOnFloor()) Velocity = new Vector2(Velocity.X, -jumpForce);
	}
	
	private void ChangeCharacter() {
		if (Input.IsActionJustPressed("change_character")) active = !active;
	}
}
