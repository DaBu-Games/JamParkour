using UnityEngine;

public class JumpingState : IState
{
    private PlayerController _player;
    private PlayerValues _values;
    
    private Rigidbody _rigidbody;
    private bool _canJump = true;
    
    public JumpingState(PlayerController player, PlayerValues values)
    {
        _player = player;
        _values = values;
        _rigidbody = player.RB;
    }

    public void OnEnterState()
    {
        _canJump = true;
    }

    public void OnExitState() { }

    public void OnUpdate() { }

    public void OnFixedUpdate()
    {
        if (_canJump)
        {
            Jump();
            _canJump = false;
        }
    }

    private void Jump()
    {
        _player.IsJumping = true;
        
        float force = _values.JumpForce;
        
        if ( _player.RB.linearVelocity.y < 0)
        {
            force -= _player.RB.linearVelocity.y;
        }
        
        _player.RB.AddForce(Vector3.up * force, ForceMode.Impulse);
    }
}