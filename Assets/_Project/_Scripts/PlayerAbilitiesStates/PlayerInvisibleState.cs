using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInvisibleState : PlayerAbility {
    public PlayerInvisibleState(PlayerAbilityStateMachine playerAbilityStateMachine) : base(playerAbilityStateMachine) {
    }

    public override void Enter() {
        Debug.Log("Entering Invisible State");
        _AbilitystateMachine.InputHandler.OnDisappearPressed += _AbilitystateMachine.PlayerAbilitiesLogic.AppearingHandler;
    }

    public override void Exit() {
        Debug.Log("Exiting Invisible State");
        _AbilitystateMachine.InputHandler.OnDisappearPressed -= _AbilitystateMachine.PlayerAbilitiesLogic.AppearingHandler;
    }

    public override void Update() {
        if (_AbilitystateMachine.PlayerAbilitiesLogic.GetPlayerMaterial() == _AbilitystateMachine.PlayerAbilitiesLogic.GetVisibleMaterial()) {
            _AbilitystateMachine.ChangeAbility(_AbilitystateMachine.NormalState);
        }
    }
}
