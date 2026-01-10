using UnityEngine;

public static class AxisUtils
{
    public static Vector3 ToVector(Axis axis)
    {
        return axis switch
        {
            Axis.Right => Vector3.right,
            Axis.Up => Vector3.up,
            Axis.Forward => Vector3.forward,
            _ => Vector3.right
        };
    }
}