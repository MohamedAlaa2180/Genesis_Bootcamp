using UnityEngine;

/// <summary>
/// Alternative approach: Specialized movement state for invisibility
/// This inherits from normal moving behavior but modifies speed
/// </summary>
public class PlayerInvisibleMovingState : PlayerMovingState
{
    private float _invisibilitySpeedMultiplier = 0.5f;
    private float _originalSpeedMultiplier;

    public PlayerInvisibleMovingState(PlayerStateMachine playerStateMachine) : base(playerStateMachine)
    {
    }

    public void SetSpeedMultiplier(float multiplier)
    {
        _invisibilitySpeedMultiplier = multiplier;
    }

    public override void Enter()
    {
        // Store original speed and apply invisibility speed
        _originalSpeedMultiplier = _movement.GetSpeedMultiplier();
        _movement.SetSpeedMultiplier(_originalSpeedMultiplier * _invisibilitySpeedMultiplier);
        
        Debug.Log($"Entered {StateName} - Speed reduced to {_invisibilitySpeedMultiplier * 100}%");
    }

    public override void Update()
    {
        // Use the base moving state logic but with modified speed
        base.Update();
        
        // Could add invisibility-specific logic here
        // - Check for actions that break invisibility
        // - Handle invisibility timer if needed
    }

    public override void Exit()
    {
        // Restore original speed
        _movement.SetSpeedMultiplier(_originalSpeedMultiplier);
        
        Debug.Log($"Exited {StateName} - Speed restored");
        base.Exit();
    }
}