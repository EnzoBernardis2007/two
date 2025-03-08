using Godot;

public partial class ChangeScene : Button
{
	public string sceneName;

	public override void _Ready()
	{
		if (this != null)
		{
			this.Pressed += OnChangeScene;
			GD.Print("Sinal do botão conectado com sucesso.");
		}
		else
		{
			GD.Print("Erro: Botão não encontrado.");
		}
	}

	private void OnChangeScene()
	{
		GD.Print("Botão pressionado!");
		GD.Print($"Tentando carregar a cena: res://scene/{sceneName}.tscn");
		GetTree().ChangeSceneToFile($"res://scene/{sceneName}.tscn");
	}
}
