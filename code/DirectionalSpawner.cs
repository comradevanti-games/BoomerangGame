﻿using Godot;

namespace BoomerangGame;

public partial class DirectionalSpawner : Node2D
{
    [Export] private PackedScene sceneToSpawn;

    private Node root;


    public override void _Ready()
    {
        root = GetNode("/root");
    }


    public void Spawn()
    {
        var sceneRoot = sceneToSpawn.Instantiate();
        root.AddChild(sceneRoot);
        
        if (sceneRoot is not Node2D sceneRoot2D) return;

        sceneRoot2D.GlobalPosition = GlobalPosition;
        sceneRoot2D.GlobalRotation = GlobalRotation;
    }
}