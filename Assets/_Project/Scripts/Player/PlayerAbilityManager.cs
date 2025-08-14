using System.Collections.Generic;
using UnityEngine;

public class PlayerAbilityManager : MonoBehaviour
{
    List<PlayerAbility> abilities = new List<PlayerAbility>();
    PlayerInputHandler inputHandler;
    PlayerStateMachine stateMachine;

    public void Init(PlayerInputHandler inputHandler, PlayerStateMachine stateMachine)
    {
        this.inputHandler = inputHandler;
        this.stateMachine = stateMachine;

        AddAbility(new InvisibilityAbility());
    }

    void AddAbility(PlayerAbility ability)
    {
        abilities.Add(ability);
        ability.Init(inputHandler, stateMachine);
    }
}