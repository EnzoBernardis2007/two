using Godot;

public partial class SceneManager : Node2D
{
	[Export] public Player player1;
	[Export] public Player player2;
	[Export] public string nextScene;
	[Export] public string actualScene;
	private Control ui;
	private ChangeScene changeSceneScript;
	private Control gameOver;
	private GameOver gameOverScript;

	public override void _Ready()
	{
		PackedScene uiScene = (PackedScene)GD.Load("res://prefab/end_scene.tscn");
		PackedScene gameOverScene = (PackedScene)GD.Load("res://prefab/gameOver.tscn");
		ui = (Control)uiScene.Instantiate();
		gameOver = (Control)gameOverScene.Instantiate();
		AddChild(ui);
		AddChild(gameOver);
		
		Button button = ui.GetNode<Button>("Button");
		changeSceneScript = button.GetNode<ChangeScene>(".");
		
		gameOverScript = gameOver.GetNode<GameOver>(".");
	}
	
	public void ShowEndScene() 
	{
		player1.active = false;
		player2.active = false;
		changeSceneScript.sceneName = nextScene;
		ui.Visible = true;
	}
	
	public void GameOver() 
	{
		player1.active = false;
		player2.active = false;
		gameOverScript.sceneName = actualScene;
		gameOver.Visible = true;
	}
}
