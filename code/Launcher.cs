using Godot;

namespace BoomerangGame;

public partial class Launcher : Node2D
{
    [Export] private PackedScene bullet = null!;
    [Export(hintString: "suffix:px/s")] private float launchSpeed;

    private Node root = null!;


    public override void _Ready()
    {
        root = GetNode("/root");
    }


    public void Spawn()
    {
        // TODO: Use a pool

        var sceneRoot = bullet.Instantiate();
        root.AddChild(sceneRoot);

        if (sceneRoot is Node2D transform)
        {
            transform.GlobalPosition = GlobalPosition;
            transform.GlobalRotation = GlobalRotation;
        }

        if (sceneRoot is RigidBody2D rigidBody)
        {
            var forward = Vector2.FromAngle(GlobalRotation);
            rigidBody.LinearVelocity = forward * launchSpeed;
        }
    }
}