using System;
using UnityEngine;

public class PlayerIdleState : PlayerState
{
    private bool _isPlayerMoving;

    public PlayerIdleState(PlayerStateMachine playerStateMachine) : base(playerStateMachine)
    {
    }

    public override void Enter()
    {
        _playerStateMachine.OnPlayerMoving.OnEventRaised += SetIsPlayerMoving;
        // Logic for entering the idle state
        Debug.Log($"Entered {StateName}");
    }

    public override void Update()
    {
        if (_isPlayerMoving)
        {
            _playerStateMachine.ChangeState(_playerStateMachine.MovingState);
        }
    }

    public override void Exit()
    {
        // Logic for exiting the idle state
        Debug.Log($"Exited {StateName}");

        _playerStateMachine.OnPlayerMoving.OnEventRaised -= SetIsPlayerMoving;
    }

    private void SetIsPlayerMoving(bool isMoving)
    {
        _isPlayerMoving = isMoving;
    }
}