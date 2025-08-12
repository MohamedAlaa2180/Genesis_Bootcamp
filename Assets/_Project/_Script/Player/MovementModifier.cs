using UnityEngine;

/// <summary>
/// Advanced approach: Movement modifier system
/// Allows multiple simultaneous effects (invisibility + poison + speed boost, etc.)
/// </summary>
[System.Serializable]
public class MovementModifier
{
    public string name;
    public float speedMultiplier = 1f;
    public bool canJump = true;
    public bool canSprint = true;
    public float duration = -1f; // -1 = permanent until removed
    public int priority = 0; // Higher priority overrides lower
    
    public MovementModifier(string modifierName, float speed = 1f, float dur = -1f, int prio = 0)
    {
        name = modifierName;
        speedMultiplier = speed;
        duration = dur;
        priority = prio;
    }
}

/// <summary>
/// Extension to PlayerMovement for handling multiple modifiers
/// </summary>
public static class PlayerMovementExtensions
{
    public static void MoveWithModifiers(this PlayerMovement movement, MovementModifier[] modifiers)
    {
        // Calculate effective speed from all modifiers
        float effectiveSpeed = 1f;
        bool canMove = true;
        
        foreach (var modifier in modifiers)
        {
            if (modifier.speedMultiplier == 0f)
            {
                canMove = false;
                break;
            }
            effectiveSpeed *= modifier.speedMultiplier;
        }
        
        if (canMove)
        {
            movement.SetSpeedMultiplier(effectiveSpeed);
            movement.Move();
        }
        // If can't move (stunned), don't call Move() at all
    }
}