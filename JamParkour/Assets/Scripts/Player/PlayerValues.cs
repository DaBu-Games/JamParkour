using System.Collections;
using System.Collections.Generic; 
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "PlayerValues", menuName = "Player/values")]
public class PlayerValues : ScriptableObject
{
    [Header("Movement values")]
    public float WalkSpeed = 6f;
    public float RunSpeed = 2f;
    public float JumpInputBufferTime = 0.15f;
    public float LeaveGroundBufferTime = 0.15f;
    public float JumpHeight = 1.5f;
    public float Gravity = -9.81f;
    public float FallingGravity = -12.85f;
    public float Drag = 10f;
}
