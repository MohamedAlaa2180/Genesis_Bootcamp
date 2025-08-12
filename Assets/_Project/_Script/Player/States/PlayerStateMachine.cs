using Cysharp.Threading.Tasks;
using UnityEngine;

public class PlayerStateMachine : MonoBehaviour
{
    private PlayerState _currentState;
    private bool _isInitialized = false;

    // State instances
    public PlayerIdleState IdleState { get; private set; }

    public PlayerMovingState MovingState { get; private set; }

    public PlayerState CurrentState => _currentState;
    public bool IsInitialized => _isInitialized;

    #region Event Channels

    [Header("Listen to Event Channels")]
    [SerializeField] public BoolEventChannelSO OnPlayerMoving;

    #endregion Event Channels

    public void Init()
    {
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