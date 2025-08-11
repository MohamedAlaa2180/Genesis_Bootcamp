using UnityEngine;

public class PlayerInvisibleState : PlayerState
{
    public PlayerInvisibleState(PlayerStateMachine playerStateMachine) : base(playerStateMachine)
    {
    }

    public override void Enter()
    {
        //_playerStateMachine.PlayerAbilities.ActiveAbility.StartCooldown();
        _playerStateMachine.PlayerAbilities.PerformAbility(AbilityType.Invisibility);
        Debug.Log("Enter Invisible State");
    }

    public override void Exit()
    {
        _playerStateMachine.PlayerAbilities.DeactivateAbility(AbilityType.Invisibility);
        Debug.Log("Exit Invisible State");

    }

    public override void Update()
    {
        
    }
}
public class PlayerNoneState : PlayerState
{
    public PlayerNoneState(PlayerStateMachine playerStateMachine) : base(playerStateMachine)
    {
    }

    public override void Enter()
    {
    }

    public override void Exit()
    {
    }

    public override void Update()
    {
    }
}
