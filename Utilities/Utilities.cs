using Godot;
using System;

public partial class Utilities : Node
{
    public static string vectorToString(Vector2 vector)
    {
        return vector.ToString("F1");
    }

}
