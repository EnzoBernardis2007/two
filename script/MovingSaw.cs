using Godot;

public partial class MovingSaw : PathFollow2D
{
	[Export] public float Speed = 50.0f;
	[Export] public SceneManager sceneManager;

	private int _direction = 1;
	
	public override void _Ready() 
	{
		GetNode<Area2D>("Area2D").Connect("body_entered", new Callable(this, nameof(OnBodyEntered)));
	}

	public override void _PhysicsProcess(double delta)
	{
		float pathLength = GetParent<Path2D>().Curve.GetBakedLength();

		Progress += Speed * _direction * (float)delta;

		if (Progress >= pathLength || Progress <= 0)
		{
			_direction *= -1;

			Progress = Mathf.Clamp(Progress, 0, pathLength);
		}
	}
	
	private void OnBodyEntered(Node2D obj)
	{
		if(obj.IsInGroup("player")) {
			sceneManager.GameOver();
		}
	}
}
