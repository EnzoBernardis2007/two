using Godot;
using System;

public partial class SceneManager : Node2D
{
	[Export] public Player player1;
	[Export] public Player player2;
	private Control ui;

	public override void _Ready()
	{
		PackedScene uiScene = (PackedScene)GD.Load("res://prefab/end_scene.tscn");
		ui = (Control)uiScene.Instantiate();
		AddChild(ui);
	}
	
	public void ShowEndScene() {
		player1.active = false;
		player2.active = false;
		ui.Visible = true;
	}
}
