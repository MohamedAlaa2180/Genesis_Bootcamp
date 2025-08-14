using UnityEngine;

public class PlayerMovingState : PlayerState
{
    public PlayerMovingState(PlayerStateMachine stateMachine) : base(stateMachine) { }

    public override void Enter() => Debug.Log("Entering Moving State");

    public override void Update()
    {
        Debug.Log("Player is moving");
        if (stateMachine.InputHandler.MovementInput.magnitude < 0.1f) stateMachine.ChangeState(stateMachine.IdleState);

        stateMachine.PlayerMovement.Move();
    }

    public override void Exit() => Debug.Log("Exiting Moving State");
}