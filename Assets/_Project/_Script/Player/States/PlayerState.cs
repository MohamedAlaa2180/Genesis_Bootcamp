using UnityEngine;

public abstract class PlayerState
{
    // Shared constants for all states
    protected const float INPUT_THRESHOLD = 0.1f;
    protected const float INPUT_THRESHOLD_SQR = INPUT_THRESHOLD * INPUT_THRESHOLD;
    
    protected PlayerStateMachine _playerStateMachine;
    
    // Cached references for performance
    protected PlayerInputsHandler _inputHandler;
    protected PlayerMovement _movement;
    
    // State info
    public string StateName { get; protected set; }
    
    public PlayerState(PlayerStateMachine playerStateMachine)
    {
        _playerStateMachine = playerStateMachine;
        _inputHandler = _playerStateMachine.PlayerInputsHandler;
        _movement = _playerStateMachine.PlayerMovement;
        StateName = GetType().Name;
    }
    
    public abstract void Enter();
    public abstract void Exit();
    public abstract void Update();
}
