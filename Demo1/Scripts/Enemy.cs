using Godot;

public partial class Enemy : Area2D
{
    private readonly PackedScene particle = ResourceLoader.Load<PackedScene>("res://Scene/Particle.tscn");
    private Rect2 _screen;
    private Vector2 _velocity;

    public override void _InputEvent(Viewport viewport, InputEvent @event, int shapeIdx)
    {
        if (@event is InputEventMouseButton)
        {
            QueueFree();

            var p = particle.Instantiate<Particle>();
            p.Start(Position);
            var rootNode = GetParent();
            rootNode.AddChild(p);
        }
    }

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        _screen = GetViewportRect();
        var random = new RandomNumberGenerator();
        random.Randomize();
        _velocity.X = random.RandiRange(-300, 300);
        _velocity.Y = random.RandiRange(-300, 300);
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
    {
        Vector2 position = Position;
        Position += _velocity * (float) delta;

        if (Position.X < 0)
        {
            position.X = 0;
            _velocity.X *= -1;
        }

        if (Position.Y < 0)
        {
            position.Y = 0;
            _velocity.Y *= -1;
        }

        if (Position.X > _screen.Size.X)
        {
            position.X = _screen.Size.X;
            _velocity.X *= -1;
        }

        if (Position.Y > _screen.Size.Y)
        {
            position.Y = _screen.Size.Y;
            _velocity.Y *= -1;
        }
    }
}