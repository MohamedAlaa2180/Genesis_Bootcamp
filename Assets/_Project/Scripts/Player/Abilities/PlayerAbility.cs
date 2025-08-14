public abstract class PlayerAbility
{
    protected PlayerInputHandler inputHandler;
    protected PlayerStateMachine stateMachine;
    protected bool isActive;

    public virtual void Init(PlayerInputHandler inputHandler, PlayerStateMachine stateMachine)
    {
        this.inputHandler = inputHandler;
        this.stateMachine = stateMachine;
    }

    public abstract void Activate();
    public abstract void Deactivate();
}