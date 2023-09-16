using System;
using Godot;

namespace BoomerangGame;

public partial class SinMove : Node
{
    [Export] private float amplitude;
    [Export] private float frequency;

    private float t;
    private float baseLineY;
    private Node2D node;

    public override void _Ready()
    {
        node = GetParentOrNull<Node2D>()
               ?? throw new NullReferenceException("Mover requires a parent!");
        baseLineY = node.Position.Y;
    }

    public override void _Process(double delta)
    {
        t += frequency * (float)delta;
        var offset = Mathf.Sin(t) * amplitude;
        node.Position = new Vector2(node.Position.X, baseLineY + offset);
    }
}