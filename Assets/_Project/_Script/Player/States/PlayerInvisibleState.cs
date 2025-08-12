using UnityEngine;

public class PlayerInvisibleState : PlayerState
{
    private float _invisibilityDuration;
    private float _invisibilityTimer;
    private float _slowSpeedMultiplier = 0.5f; // 50% speed while invisible
    
    // Cached input for performance
    private Vector2 _cachedInput;

    public PlayerInvisibleState(PlayerStateMachine playerStateMachine) : base(playerStateMachine)
    {
    }

    public void SetInvisibilityDuration(float duration)
    {
        _invisibilityDuration = duration;
        _invisibilityTimer = 0f;
    }
    
    public void SetSpeedMultiplier(float multiplier)
    {
        _slowSpeedMultiplier = multiplier;
    }

    public override void Enter()
    {
        Debug.Log($"Entered {StateName} - Duration: {_invisibilityDuration}s, Speed: {_slowSpeedMultiplier * 100}%");
        _invisibilityTimer = 0f;
        
        // Apply speed reduction
        _movement.SetSpeedMultiplier(_slowSpeedMultiplier);
        
        // Here you could also:
        // - Change player material to transparent
        // - Disable enemy detection
        // - Play invisibility sound effect
    }

    public override void Update()
    {
        // Execute movement with reduced speed
        _movement.Move();
        
        // Cache input for performance
        _cachedInput = _inputHandler.MovementInput;
        
        // Update invisibility timer
        _invisibilityTimer += Time.deltaTime;
        
        // Check if invisibility duration is over
        if (_invisibilityTimer >= _invisibilityDuration)
        {
            // Return to appropriate state based on current input
            if (_cachedInput.sqrMagnitude > INPUT_THRESHOLD_SQR)
            {
                _playerStateMachine.ChangeState(_playerStateMachine.MovingState);
            }
            else
            {
                _playerStateMachine.ChangeState(_playerStateMachine.IdleState);
            }
        }
        
        // Note: Player CAN move but at reduced speed
        // This demonstrates state-controlled movement modification
    }

    public override void Exit()
    {
        Debug.Log($"Exited {StateName} - Player visible again, speed restored");
        
        // Restore normal speed
        _movement.ResetSpeed();
        
        // Here you could also:
        // - Restore normal material
        // - Re-enable enemy detection
        // - Play visibility sound effect
    }
}