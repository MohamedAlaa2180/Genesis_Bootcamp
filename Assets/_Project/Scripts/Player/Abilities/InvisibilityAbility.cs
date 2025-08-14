using UnityEngine;

public class InvisibilityAbility : PlayerAbility
{
    public override void Init(PlayerInputHandler inputHandler, PlayerStateMachine stateMachine)
    {
        base.Init(inputHandler, stateMachine);
        inputHandler.OnInvisible += ToggleInvisibility;
    }

    public override void Activate()
    {
        isActive = true;
        stateMachine.ChangeState(stateMachine.InvisibleState);
        Debug.Log("Invisibility Activated");
    }

    public override void Deactivate()
    {
        isActive = false;
        stateMachine.ChangeState(stateMachine.IdleState);
        Debug.Log("Invisibility Deactivated");
    }

    private void ToggleInvisibility()
    {
        if (isActive)
            Deactivate();
        else
            Activate();
    }
}