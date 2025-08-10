using Cysharp.Threading.Tasks;
using UnityEngine;

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
}