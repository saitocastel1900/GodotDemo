using Godot;

public partial class Main : Node2D
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		var isDestroyed = true;

		foreach (var node in GetChildren())
		{
			if (node.GetNode("Enemy") == null)
			{
				isDestroyed = false;
			}
		}

		if (isDestroyed)
		{
			OS.Alert("ゲームクリア");
			GetTree().Quit();
		}
	}
}
