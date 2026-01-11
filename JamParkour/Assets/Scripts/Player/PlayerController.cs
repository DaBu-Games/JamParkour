using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private PlayerValues _values;
    public CharacterController Controller {get; private set;}
    public Vector2 MoveInput {get; private set;}
    
    public bool IsHoldingJump;
    public bool IsJumping;
    public float LastPressedJumpTime;
    public bool IsSprinting {get; private set;}

    public Vector3 LaunchDirection;
    public float LaunchForce;
    public Vector3 Velocity;
    public Vector3 ImpulseVelocity;

    private float _lastOnGroundTime = 0f;

    private void Start()
    { 
        Controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        if(Controller.isGrounded)
            _lastOnGroundTime = Time.time;
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        MoveInput = context.ReadValue<Vector2>();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if ( context.started )
        {
            IsHoldingJump = true;
            LastPressedJumpTime = Time.time;
        }
        else if (context.canceled)
        {
            IsHoldingJump = false;
        }
    }

    public void OnSprint(InputAction.CallbackContext context)
    {
        IsSprinting = context.performed;
    }

    public void Launch(Vector3 launchDir, float launchForce)
    {
        LaunchDirection = launchDir.normalized;
        LaunchForce = launchForce;
    }
    
    private bool CanBufferJump()
    {
        return Time.time - _lastOnGroundTime <= _values.LeaveGroundBufferTime;
    }

    public bool IsJumpBufferd()
    {
        return Time.time - LastPressedJumpTime <= _values.JumpInputBufferTime && Time.time > _values.JumpInputBufferTime;
    }
}
