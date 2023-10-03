using Godot;

public partial class Particle : CpuParticles2D
{
	public void Start(Vector2 pos)
	{
		Emitting = true;
		Position = pos;
	}

	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if (Emitting == false)
		{
			QueueFree();
		}
	}
}
