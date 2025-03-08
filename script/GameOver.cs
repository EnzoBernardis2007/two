using Godot;
using System;

public partial class GameOver : Control
{
	public string sceneName;
	public override void _Ready()
	{
		GetNode<Button>("Button").Connect("pressed", new Callable(this, nameof(OnRestartButtonPressed)));
	}
	
	private void OnRestartButtonPressed()
	{
		GetTree().ChangeSceneToFile($"res://scene/{sceneName}.tscn");
	}
}
