using Cysharp.Threading.Tasks;
using UnityEngine;

public enum StateType
{
    Normal,     // Idle, Moving - can be interrupted by status effects
    StatusEffect // Stunned, Frozen, Sleeping - has priority over normal states
}

public class PlayerStateMachine : MonoBehaviour
{
    #region Dependencies

    private PlayerInputsHandler _playerInputsHandler;
    private PlayerMovement _playerMovement;

    #endregion Dependencies

    private PlayerState _currentState;
    private bool _isInitialized = false;

    // State instances
    public PlayerIdleState IdleState { get; private set; }

    public PlayerMovingState MovingState { get; private set; }
    
    public PlayerStunnedState StunnedState { get; private set; }
    
    public PlayerInvisibleState InvisibleState { get; private set; }

    // Public accessors
    public PlayerInputsHandler PlayerInputsHandler => _playerInputsHandler;

    public PlayerMovement PlayerMovement => _playerMovement;
    public PlayerState CurrentState => _currentState;
    public bool IsInitialized => _isInitialized;

    public void Init(PlayerInputsHandler playerInputsHandler, PlayerMovement playerMovement)
    {
        _playerInputsHandler = playerInputsHandler;
        _playerMovement = playerMovement;

        if (_playerInputsHandler == null)
        {
            Debug.LogError("PlayerInputsHandler is null in PlayerStateMachine initialization");
            return;
        }
        if (_playerMovement == null)
        {
            Debug.LogError("PlayerMovement is null in PlayerStateMachine initialization");
            return;
        }

        IdleState = new PlayerIdleState(this);
        MovingState = new PlayerMovingState(this);
        StunnedState = new PlayerStunnedState(this);
        InvisibleState = new PlayerInvisibleState(this);

        _isInitialized = true;
    }

    private async void Start()
    {
        await UniTask.WaitUntil(() => _isInitialized);
        ChangeState(IdleState);
    }

    private void Update()
    {
        _currentState?.Update();
    }

    /// <summary>
    /// Change to a new state with validation
    /// </summary>
    public void ChangeState(PlayerState newState)
    {
        if (_currentState == newState)
        {
            // Already in this state, no need to change
            return;
        }

        _currentState?.Exit();

        _currentState = newState;

        _currentState.Enter();
    }

    /// <summary>
    /// Apply stun effect to the player
    /// </summary>
    public void ApplyStun(float duration)
    {
        StunnedState.SetStunDuration(duration);
        ChangeState(StunnedState);
    }
    
    /// <summary>
    /// Activate invisibility ability
    /// </summary>
    public void ActivateInvisibility(float duration, float speedMultiplier = 0.5f)
    {
        InvisibleState.SetInvisibilityDuration(duration);
        InvisibleState.SetSpeedMultiplier(speedMultiplier);
        ChangeState(InvisibleState);
    }

    /// <summary>
    /// Force change state - bypasses normal state priorities (use carefully)
    /// </summary>
    public void ForceChangeState(PlayerState newState)
    {
        ChangeState(newState);
    }
    
    /// <summary>
    /// Check if we can transition to a normal state (not blocked by status effects)
    /// </summary>
    public bool CanTransitionToNormalState()
    {
        // If currently in a status effect state, don't allow normal transitions
        return _currentState != StunnedState && _currentState != InvisibleState;
    }
}