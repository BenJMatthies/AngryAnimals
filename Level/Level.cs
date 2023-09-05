using Godot;
using System;
using System.Diagnostics;

public partial class Level : Node2D
{
    SignalManager signalManager;
    Label DebugLabel;
    PackedScene animalScene;
    Marker2D AnimalStart;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        signalManager = GetNode<SignalManager>("/root/SignalManager");
        DebugLabel = GetNode<Label>(nameof(DebugLabel));
        animalScene = GD.Load<PackedScene>("res://Animal/Animal.tscn");
        AnimalStart = GetNode<Marker2D>(nameof(AnimalStart));

        Callable OnUpdateDebugLabelCallable = new(this, nameof(OnUpdateDebugLabel));
        signalManager.Connect(nameof(signalManager.OnUpdateDebugLabel), OnUpdateDebugLabelCallable);

        Callable OnAnimalDiedCallable = new(this, nameof(OnAnimalDied));
        signalManager.Connect(nameof(signalManager.OnAnimalDied), OnAnimalDiedCallable);

        spawnAnimal();
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
    {
    }

    private void spawnAnimal()
    {
        Animal animal = animalScene.Instantiate<Animal>();
        animal.GlobalPosition = AnimalStart.GlobalPosition;
        AddChild(animal);
    }

    private void OnUpdateDebugLabel(string labelText)
    {
        DebugLabel.Text = labelText;
    }

    private void OnAnimalDied()
    {
        spawnAnimal();
    }
}
