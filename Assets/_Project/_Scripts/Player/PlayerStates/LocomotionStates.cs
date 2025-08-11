using UnityEngine;
public class PlayerMovingState : PlayerState
{
    public PlayerMovingState(PlayerStateMachine playerStateMachine) : base(playerStateMachine)
    {
    }

    public override void Enter()
    {
    }

    public override void Exit()
    {
    }

    public override void Update()
    {
        if (_playerStateMachine.PlayerMovement.PlayerAbilities != null 
            && !_playerStateMachine.PlayerMovement.PlayerAbilities.IsInvisible)
        {
            _playerStateMachine.PlayerMovement.MovePlayer(_playerStateMachine.PlayerMovement.PlayerMovementSettings.MoveSpeed);
        }
        else
        {
            _playerStateMachine.PlayerMovement.MovePlayer(_playerStateMachine.PlayerMovement.PlayerMovementSettings.InvisibleMoveSpeed);
        }

        if (_playerStateMachine.PlayerInputHandler.MovementInput.magnitude <= 0)
        {
            _playerStateMachine.LocomotionStateMachine.ChangeState(_playerStateMachine.PlayerIdleState);
        }

    }
}

public class PlayerIdleState : PlayerState
{
    public PlayerIdleState(PlayerStateMachine playerStateMachine) : base(playerStateMachine)
    {
    }

    public override void Enter()
    {
    }

    public override void Exit()
    {
    }

    public override void Update()
    {

        if (_playerStateMachine.PlayerInputHandler.MovementInput.magnitude > 0.1f)
        {
            _playerStateMachine.LocomotionStateMachine.ChangeState(_playerStateMachine.PlayerMovingState);
        }

    }
}
