using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovingState : PlayerState {
    public PlayerMovingState(PlayerMovementStateMachine playerMovingStateMachine) : base(playerMovingStateMachine) {
    }

    public override void Enter() {
        // You can add any initialization logic here if needed
        _playerMovingStateMachine.InputHandler.OnJumpPressed += _playerMovingStateMachine.PlayerMovement.JumpHandler;
    }

    public override void Exit() {
        // You can add any cleanup logic here if needed
        _playerMovingStateMachine.InputHandler.OnJumpPressed -= _playerMovingStateMachine.PlayerMovement.JumpHandler;
    }

    public override void Update() {
        _playerMovingStateMachine.PlayerMovement.MovementHandler();
        if(_playerMovingStateMachine.PlayerMovement.MovementVector.magnitude < 0.1f) {
            _playerMovingStateMachine.ChangeState(_playerMovingStateMachine.IdleState);
        }
        else if (!_playerMovingStateMachine.PlayerMovement.IsGrounded) {
            _playerMovingStateMachine.ChangeState(_playerMovingStateMachine.JumpingState);
        }
    }
}
