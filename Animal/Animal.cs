using Godot;
using System;

public partial class Animal : RigidBody2D
{
    SignalManager signalManager;
    bool dead;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        signalManager = GetNode<SignalManager>("/root/SignalManager");
        dead = false;
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _PhysicsProcess(double delta)
    {
        updateDebugLabel();
    }

    public void updateDebugLabel()
    {
        string globalPosition = Utilities.vectorToString(GlobalPosition);
        string angularVelocity = AngularVelocity.ToString("F1");
        string linearVelocity = Utilities.vectorToString(LinearVelocity);

        string labelString = $"glob_pos: {globalPosition}" +
        $"\nang_vel: {angularVelocity} \nlin_vel: {linearVelocity}";

        signalManager.EmitSignal(nameof(signalManager.OnUpdateDebugLabel), labelString);
    }

    private void die()
    {
        if (!dead)
        {
            dead = true;
            signalManager.EmitSignal(nameof(signalManager.OnAnimalDied));
            QueueFree();
        }
    }

    public void signal_onAnimalScreenExited()
    {
        die();
    }

    public void signal_OnInputEvent(Viewport viewport, InputEvent inputEvent, int shape_idx)
    {
        if (inputEvent.IsActionPressed("drag"))
        {
            GD.Print(inputEvent);
        }
    }
}
