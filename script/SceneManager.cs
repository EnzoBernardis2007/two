using Godot;

public partial class SceneManager : Node2D
{
	[Export] public Player player1;
	[Export] public Player player2;
	[Export] public string sceneName;
	private Control ui;
	private ChangeScene changeSceneScript;

	public override void _Ready()
	{
		PackedScene uiScene = (PackedScene)GD.Load("res://prefab/end_scene.tscn");
		ui = (Control)uiScene.Instantiate();
		AddChild(ui);
		
		Button button = ui.GetNode<Button>("Button");
		changeSceneScript = button.GetNode<ChangeScene>(".");
	}
	
	public void ShowEndScene() {
		player1.active = false;
		player2.active = false;
		changeSceneScript.sceneName = sceneName;
		ui.Visible = true;
	}
}
