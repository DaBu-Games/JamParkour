using UnityEngine;

public class InAirState : IState
{
    private PlayerController _player;
    private PlayerValues _values;
    
    private float CurrentGravity;
    
    public InAirState(PlayerController player, PlayerValues values)
    {
        _player = player;
        _values = values;
    }

    public void OnEnterState()
    {
        CurrentGravity = _values.Gravity;
    }

    public void OnExitState()
    {
        if(_player.IsJumping)
            _player.IsJumping = false;
        
        _player.Velocity.y = -2f;
    }
    public void OnUpdate() { }

    public void OnFixedUpdate()
    {
        Move();
    }
    
    private void Move()
    {
        if (_player.Velocity.y < 0 || (_player.IsJumping && !_player.IsHoldingJump))
        {
            CurrentGravity = _values.FallingGravity;
        }
        
        _player.Velocity.y += CurrentGravity * Time.deltaTime;

        if (_player.MoveInput != Vector2.zero)
        {
            Vector3 move = _player.transform.right * _player.MoveInput.x + _player.transform.forward * _player.MoveInput.y;
            
            float speed = _player.IsHoldingRun ? _values.RunSpeed : _values.WalkSpeed;
            _player.Controller.Move(move * (speed * Time.deltaTime));
        }

        if (_player.ImpulseVelocity != Vector3.zero)
        {
            _player.Controller.Move(_player.ImpulseVelocity * Time.deltaTime);
        
            _player.ImpulseVelocity = Vector3.Lerp(
                _player.ImpulseVelocity,
                Vector3.zero,
                Time.deltaTime * _values.Drag
            );
        }
        
        _player.Controller.Move(_player.Velocity * Time.deltaTime);
    }
}
