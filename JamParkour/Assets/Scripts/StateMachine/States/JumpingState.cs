using UnityEngine;

public class JumpingState : IState
{
    private PlayerController _player;
    private PlayerValues _values;
    
    public JumpingState(PlayerController player, PlayerValues values)
    {
        _player = player;
        _values = values;
    }

    public void OnEnterState()
    {
        _player.IsJumping = true;
        _player.Velocity.y = Mathf.Sqrt(_values.JumpHeight * -2f * _values.Gravity);
    }

    public void OnExitState() { }

    public void OnUpdate() { }

    public void OnFixedUpdate()
    {
        _player.Controller.Move(_player.Velocity * Time.deltaTime);
    }
}