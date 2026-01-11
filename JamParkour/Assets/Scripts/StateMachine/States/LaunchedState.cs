using UnityEngine;

public class LaunchedState : IState
{
    private PlayerController _player;

    public LaunchedState(PlayerController player)
    {
        _player = player;
    }

    public void OnEnterState()
    {
        Launch();
        _player.LaunchDirection = Vector3.zero;
    }

    public void OnExitState() { }
    public void OnUpdate() { }

    public void OnFixedUpdate() { }
    
    private void Launch()
    {
        _player.LaunchDirection.Normalize();

        _player.ImpulseVelocity += _player.LaunchDirection * _player.LaunchForce;
        
        if (_player.Velocity.y < 0f)
            _player.Velocity.y = 0f;
    }
}
