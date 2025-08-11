using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    InputHandler _inputHandler;
    PlayerMovement _playerMovement;
    PlayerAbilitiesLogic _playerAbilitiesLogic;
    PlayerMovementStateMachine _playerMovementStateMachine;
    PlayerAbilityStateMachine _playerAbilityStateMachine;
    private void Awake() {
        _inputHandler = GetComponent<InputHandler>();
        _playerMovement = GetComponent<PlayerMovement>();
        _playerAbilitiesLogic = GetComponent<PlayerAbilitiesLogic>();
        _playerMovementStateMachine = GetComponent<PlayerMovementStateMachine>();
        _playerAbilityStateMachine = GetComponent<PlayerAbilityStateMachine>();
        Init();
    }

    private void Init() {
        _playerMovement.Init(_inputHandler);
        _playerAbilitiesLogic.Init(_playerMovement);
        _playerMovementStateMachine.Init(_inputHandler, _playerMovement);
        _playerAbilityStateMachine.Init(_inputHandler, _playerMovement, _playerAbilitiesLogic);
    }


}
