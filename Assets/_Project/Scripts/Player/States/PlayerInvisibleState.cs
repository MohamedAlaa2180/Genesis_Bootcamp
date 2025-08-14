using UnityEngine;

public class PlayerInvisibleState : PlayerState
{
    public PlayerInvisibleState(PlayerStateMachine stateMachine) : base(stateMachine) { }

    public override void Enter()
    {
        stateMachine.PlayerMovement.SetMoveSpeed(PlayerMovementSpeed.Invisible);
        stateMachine.PlayerVisualHandler.SetVisible(false);
    }

    public override void Update() => stateMachine.PlayerMovement.Move();

    public override void Exit()
    {
        stateMachine.PlayerMovement.SetMoveSpeed(PlayerMovementSpeed.Normal);
        stateMachine.PlayerVisualHandler.SetVisible(true);
    }
}
