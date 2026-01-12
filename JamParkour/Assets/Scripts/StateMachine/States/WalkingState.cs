using UnityEngine;

public class WalkingState : IState
{
    private PlayerController _player;
    protected float _speed;
    
    public WalkingState(PlayerController player, PlayerValues values)
    {
        _player = player;
        _speed = values.WalkSpeed;
    }
    public void OnEnterState() { }

    public void OnExitState() { }

    public void OnUpdate(){}

    public void OnFixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        Vector3 input = _player.transform.right * _player.MoveInput.x + _player.transform.forward * _player.MoveInput.y;

        Vector3 velocity = _player.RB.linearVelocity;
        velocity.x = input.x * _speed;
        velocity.z = input.z * _speed;

        _player.RB.linearVelocity = velocity;
    }
}