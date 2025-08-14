public abstract class PlayerState : State
{
    protected PlayerStateMachine stateMachine;

    public PlayerState(PlayerStateMachine stateMachine)
    {
        this.stateMachine = stateMachine;
    }
}