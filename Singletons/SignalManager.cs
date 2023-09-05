using Godot;
using System;

public partial class SignalManager : Node
{
	[Signal] public delegate void OnUpdateDebugLabelEventHandler(string text);
}
