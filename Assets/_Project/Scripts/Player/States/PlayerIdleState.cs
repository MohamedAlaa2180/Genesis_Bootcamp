using UnityEngine;

public class PlayerIdleState : PlayerState
{
    public PlayerIdleState(PlayerStateMachine stateMachine) : base(stateMachine) { }

    public override void Enter() => Debug.Log("Entering Idle State");

    public override void Update()
    {
        Debug.Log("Player is idle");
        if (stateMachine.InputHandler.MovementInput.magnitude > 0.1f) stateMachine.ChangeState(stateMachine.MovingState);
    }

    public override void Exit() => Debug.Log("Exiting Idle State");
}