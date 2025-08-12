using System;
using UnityEngine;

public class PlayerIdleState : PlayerState
{
    public PlayerIdleState(PlayerStateMachine playerStateMachine) : base(playerStateMachine)
    {
    }

    public override void Enter()
    {
        // Logic for entering the idle state
        Debug.Log($"Entered {StateName}");
    }

    public override void Update()
    {
        // Only transition if not blocked by status effects
        if (_playerStateMachine.CanTransitionToNormalState())
        {
            // Check for transition to moving state
            if (_inputHandler.MovementInput.sqrMagnitude > INPUT_THRESHOLD_SQR)
            {
                _playerStateMachine.ChangeState(_playerStateMachine.MovingState);
            }
        }
    }

    public override void Exit()
    {
        // Logic for exiting the idle state
        Debug.Log($"Exited {StateName}");
    }
}