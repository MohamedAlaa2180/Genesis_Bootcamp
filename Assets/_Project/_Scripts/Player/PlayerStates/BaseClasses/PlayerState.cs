public abstract class PlayerState
{
    protected PlayerStateMachine _playerStateMachine;

    public PlayerState(PlayerStateMachine playerStateMachine)
    {
        _playerStateMachine = playerStateMachine;
    }

    public abstract void Enter();
    public abstract void Exit();
    public abstract void Update();
}
