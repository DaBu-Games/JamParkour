public class IdleState : IState
{
    private PlayerController _player;
    
    public IdleState(PlayerController player)
    {
        _player = player;
    }

    public void OnEnterState()
    {
        
    }

    public void OnExitState() { }
    public void OnUpdate() { }

    public void OnFixedUpdate() { }
}