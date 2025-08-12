using UnityEngine;

public class PlayerMovingState : PlayerState
{
    // Cached input for performance
    private Vector2 _cachedInput;

    private bool _isPlayerMoving;

    public PlayerMovingState(PlayerStateMachine playerStateMachine) : base(playerStateMachine)
    {
    }

    public override void Enter()
    {
        _playerStateMachine.OnPlayerMoving.OnEventRaised += SetIsPlayerMoving;

        // Logic for entering the moving state
        Debug.Log($"Entered {StateName}");
    }

    public override void Update()
    {
        if (!_isPlayerMoving)
        {
            _playerStateMachine.ChangeState(_playerStateMachine.IdleState);
        }
    }

    public override void Exit()
    {
        _playerStateMachine.OnPlayerMoving.OnEventRaised -= SetIsPlayerMoving;

        // Logic for exiting the moving state
        Debug.Log($"Exited {StateName}");
    }

    private void SetIsPlayerMoving(bool isMoving)
    {
        _isPlayerMoving = isMoving;
    }
}