using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpingState : PlayerState {
    public PlayerJumpingState(PlayerMovementStateMachine playerMovingStateMachine) : base(playerMovingStateMachine) {
    }
    public override void Enter() {
        // You can add any initialization logic here if needed
    }
    public override void Exit() {
        // You can add any cleanup logic here if needed
    }
    public override void Update() {
        _playerMovingStateMachine.PlayerMovement.MovementHandler();
        if (_playerMovingStateMachine.PlayerMovement.IsGrounded) {
            _playerMovingStateMachine.ChangeState(_playerMovingStateMachine.IdleState);
        }
    }
}
