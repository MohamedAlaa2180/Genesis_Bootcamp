using UnityEngine;

public class PlayerStunnedState : PlayerState
{
    private float _stunDuration;
    private float _stunTimer;

    public PlayerStunnedState(PlayerStateMachine playerStateMachine) : base(playerStateMachine)
    {
    }

    public void SetStunDuration(float duration)
    {
        _stunDuration = duration;
        _stunTimer = 0f;
    }

    public override void Enter()
    {
        Debug.Log($"Entered {StateName} - Duration: {_stunDuration}s");
        _stunTimer = 0f;
        
        // Optional: Stop any current movement
        // Could add a Stop() method to PlayerMovement if needed
    }

    public override void Update()
    {
        // NO MOVEMENT EXECUTION - This is the key!
        // Even if input is detected, we don't call _movement.Move()
        
        _stunTimer += Time.deltaTime;
        
        // Check if stun duration is over
        if (_stunTimer >= _stunDuration)
        {
            // Return to appropriate state based on input
            if (_inputHandler.MovementInput.sqrMagnitude > INPUT_THRESHOLD_SQR)
            {
                _playerStateMachine.ChangeState(_playerStateMachine.MovingState);
            }
            else
            {
                _playerStateMachine.ChangeState(_playerStateMachine.IdleState);
            }
        }
        
        // Note: We completely ignore input while stunned
        // Input is detected but NO movement happens because we don't call _movement.Move()
    }

    public override void Exit()
    {
        Debug.Log($"Exited {StateName} - Player can move again");
    }
}