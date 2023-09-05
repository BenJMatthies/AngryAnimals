using Godot;
using System;

public partial class Animal : RigidBody2D
{
    SignalManager signalManager;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        signalManager = GetNode<SignalManager>("/root/SignalManager");
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
        $"\rang_vel: {angularVelocity} \rlin_vel: {linearVelocity}";

        signalManager.EmitSignal(nameof(signalManager.OnUpdateDebugLabel), labelString);
    }
}
