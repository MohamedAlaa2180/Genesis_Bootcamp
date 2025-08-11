using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNormalState : PlayerAbility {
    public PlayerNormalState(PlayerAbilityStateMachine playerAbilityStateMachine) : base(playerAbilityStateMachine) {
    }

    public override void Enter() {
        Debug.Log("Entering Normal State");
        _AbilitystateMachine.InputHandler.OnDisappearPressed += _AbilitystateMachine.PlayerAbilitiesLogic.DisapearingHandler;
    }

    public override void Exit() {
        Debug.Log("Exiting Normal State");
        _AbilitystateMachine.InputHandler.OnDisappearPressed -= _AbilitystateMachine.PlayerAbilitiesLogic.DisapearingHandler;
    }

    public override void Update() {
        if (_AbilitystateMachine.PlayerAbilitiesLogic.GetPlayerMaterial() == _AbilitystateMachine.PlayerAbilitiesLogic.GetInvisibleMaterial()) {
            _AbilitystateMachine.ChangeAbility(_AbilitystateMachine.InvisibleState);
        }
    }
}
