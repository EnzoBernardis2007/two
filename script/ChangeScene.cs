using Godot;

public partial class ChangeScene : Button
{
	public string sceneName;

	public override void _Ready()
	{
		this.Pressed += OnChangeScene;
	}

	private void OnChangeScene()
	{
		GetTree().ChangeSceneToFile($"res://scene/{sceneName}.tscn");
	}
}
