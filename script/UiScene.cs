using Godot;
using System;

public partial class UiScene : Button
{
	[Export] public string sceneName;
	
	public override void _Ready() 
	{
		Connect("button_down", new Callable(this, nameof(OnButtonDown)));
	}
	
	private void OnButtonDown() 
	{
		GetTree().ChangeSceneToFile($"res://scene/{sceneName}");
	}
}
