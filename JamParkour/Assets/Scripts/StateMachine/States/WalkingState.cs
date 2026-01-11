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
        Vector3 move = _player.transform.right * _player.MoveInput.x + _player.transform.forward * _player.MoveInput.y;
        
        move.y = -2f;
        
        _player.Controller.Move(move * (_speed * Time.deltaTime));
    }
}