using Godot;
using System;
using System.Diagnostics;

public partial class Level : Node2D
{
    SignalManager signalManager;
    Label DebugLabel;
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        signalManager = GetNode<SignalManager>("/root/SignalManager");
        DebugLabel = GetNode<Label>(nameof(DebugLabel));

        Callable OnUpdateDebugLabelCallable = new(this, nameof(OnUpdateDebugLabel));
        signalManager.Connect(nameof(signalManager.OnUpdateDebugLabel), OnUpdateDebugLabelCallable);
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
    {
    }

    private void OnUpdateDebugLabel(string labelText)
    {
        DebugLabel.Text = labelText;
    }
}
