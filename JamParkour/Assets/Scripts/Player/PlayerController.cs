using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private PlayerValues _values;
    [SerializeField] private GroundCheck _groundCheck;
    public Rigidbody RB {get; private set;}
    public Vector2 MoveInput {get; private set;}
    
    public bool IsHoldingJump;
    public bool IsJumping;
    public float LastPressedJumpTime;
    public bool IsHoldingRun {get; private set;}
    
    public bool IsGrounded => _groundCheck.IsGrounded;

    private void Start()
    { 
        RB = GetComponent<Rigidbody>();
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
        IsHoldingRun = context.performed;
    }

    public void Launch(Vector3 launchDir, float launchForce)
    {
        launchDir.Normalize();
        
        if ( RB.linearVelocity.y < 0)
        {
            launchForce -= RB.linearVelocity.y;
        }
        
        RB.AddForce(launchDir * launchForce, ForceMode.Impulse);
    }
    
    public bool CanBufferJump()
    {
        return Time.time - _groundCheck.LastOnGroundTime <= _values.LeaveGroundBufferTime;
    }

    public bool IsJumpBufferd()
    {
        return Time.time - LastPressedJumpTime <= _values.JumpInputBufferTime && Time.time > _values.JumpInputBufferTime;
    }
}
