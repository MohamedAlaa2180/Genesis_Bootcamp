using UnityEngine;

public class PlayerMovingState : PlayerState
{
    // Cached input for performance
    private Vector2 _cachedInput;

    public PlayerMovingState(PlayerStateMachine playerStateMachine) : base(playerStateMachine)
    {
    }

    public override void Enter()
    {       
        // Logic for entering the moving state
        Debug.Log($"Entered {StateName}");
    }

    public override void Exit()
    {

        // Logic for exiting the moving state
        Debug.Log($"Exited {StateName}");
    }

    public override void Update()
    {

        // Execute movement logic first
        _movement.Move();
        
        // Cache input for performance (single property access)
        _cachedInput = _inputHandler.MovementInput;

        // Check for transition to idle state
        if (_cachedInput.sqrMagnitude <= INPUT_THRESHOLD_SQR)
        {
            _playerStateMachine.ChangeState(_playerStateMachine.IdleState);
        }
    }
}