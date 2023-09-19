using System;
using Godot;

namespace BoomerangGame;

public partial class PointAtTarget : Node2D
{
    private Node2D? target;


    public void SetTarget(Node2D newTarget)
    {
        target = newTarget;
        PointAt(target);
    }

    public void ClearTarget()
    {
        target = null;
    }

    private void PointAt(Node2D node)
    {
        var direction = node.GlobalPosition - GlobalPosition;
        Rotation = direction.Angle();
    }

    public override void _PhysicsProcess(double delta)
    {
        if (target == null) return;

        PointAt(target);
    }
}