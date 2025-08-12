using UnityEngine;

public abstract class PlayerState
{
    // Shared constants for all states
    protected const float INPUT_THRESHOLD = 0.1f;
    protected const float INPUT_THRESHOLD_SQR = INPUT_THRESHOLD * INPUT_THRESHOLD;
    
    protected PlayerStateMachine _playerStateMachine;
    
    // State info
    public string StateName { get; protected set; }
    
    public PlayerState(PlayerStateMachine playerStateMachine)
    {
        _playerStateMachine = playerStateMachine;
        StateName = GetType().Name;
    }
    
    public abstract void Enter();
    public abstract void Exit();
    public abstract void Update();
}
