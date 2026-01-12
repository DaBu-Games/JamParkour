using UnityEngine;

public class InAirState : IState
{
    private PlayerController _player;
    private PlayerValues _values;
    
    public InAirState(PlayerController player, PlayerValues values)
    {
        _player = player;
        _values = values;
    }

    public void OnEnterState() { }

    public void OnExitState()
    {
        if(_player.IsJumping)
            _player.IsJumping = false;
    }
    public void OnUpdate() { }

    public void OnFixedUpdate()
    {
        ApplyGravity();
        AirControl();
    }

    private void ApplyGravity()
    {
        float gravity = (_player.RB.linearVelocity.y < 0 || (_player.IsJumping && !_player.IsHoldingJump))
            ? _values.FallingGravity
            : _values.Gravity;

        _player.RB.AddForce(Vector3.up * gravity, ForceMode.Acceleration);
    }

    private void AirControl()
    {
        Vector3 input = _player.transform.right * _player.MoveInput.x + _player.transform.forward * _player.MoveInput.y;

        float speed = _player.IsHoldingRun ? _values.RunSpeed : _values.WalkSpeed;

        Vector3 velocity = _player.RB.linearVelocity;
        velocity.x = input.x * speed;
        velocity.z = input.z * speed;

        _player.RB.linearVelocity = velocity;
    }
}
