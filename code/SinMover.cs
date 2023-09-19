using Godot;

namespace BoomerangGame;

/// <summary>
/// Moves itself in a sine-wave
/// </summary>
public partial class SinMover : Node2D
{
    [Export] private float maxAmplitude;
    [Export] private float frequency;
    [Export(PropertyHint.Range, "0,360")] private float angle;

    private Vector2 offset;
    private float t;


    public override void _Ready()
    {
        offset = Vector2.Zero;
    }

    public override void _PhysicsProcess(double delta)
    {
        t += (float) delta;
        var amplitude = Mathf.Sin(t * frequency) * maxAmplitude;
        var newOffset = Vector2.FromAngle(Mathf.DegToRad(angle)) * amplitude;

        Position = Position - offset + newOffset;
        offset = newOffset;
    }
}