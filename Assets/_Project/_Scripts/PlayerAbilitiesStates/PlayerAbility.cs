using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerAbility
{
    protected PlayerAbilityStateMachine _AbilitystateMachine;
    public PlayerAbility(PlayerAbilityStateMachine playerAbilityStateMachine)
    {
        _AbilitystateMachine = playerAbilityStateMachine;
    }
    public abstract void Enter();
    public abstract void Exit();
    public abstract void Update();

}
