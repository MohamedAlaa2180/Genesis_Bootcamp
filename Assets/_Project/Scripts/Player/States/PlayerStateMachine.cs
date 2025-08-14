public class PlayerStateMachine : StateMachine
{
    PlayerInputHandler inputHandler;
    PlayerMovement playerMovement;
    PlayerVisualHandler playerVisualHandler;

    public PlayerIdleState IdleState { get; private set; }
    public PlayerMovingState MovingState { get; private set; }
    public PlayerInvisibleState InvisibleState { get; private set; }

    public PlayerInputHandler InputHandler => inputHandler;
    public PlayerMovement PlayerMovement => playerMovement;
    public PlayerVisualHandler PlayerVisualHandler => playerVisualHandler;

    void Awake()
    {
        IdleState = new PlayerIdleState(this);
        MovingState = new PlayerMovingState(this);
        InvisibleState = new PlayerInvisibleState(this);
    }

    public void Init(PlayerInputHandler inputHandler, PlayerMovement playerMovement, PlayerVisualHandler playerVisualHandler)
    {
        this.inputHandler = inputHandler;
        this.playerMovement = playerMovement;
        this.playerVisualHandler = playerVisualHandler;
    }

    void Start()
    {
        ChangeState(IdleState);
    }
}