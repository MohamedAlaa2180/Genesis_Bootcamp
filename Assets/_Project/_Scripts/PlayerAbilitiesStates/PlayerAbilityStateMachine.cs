using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbilityStateMachine : MonoBehaviour
{
    PlayerAbility _currentAbility;
    InputHandler _inputHandler;
    PlayerMovement _playerMovement;
    PlayerAbilitiesLogic _playerAbilitiesLogic;

    public PlayerNormalState NormalState { get; private set; }
    public PlayerInvisibleState InvisibleState { get; private set; }
    public InputHandler InputHandler => _inputHandler;
    public PlayerMovement PlayerMovement => _playerMovement;
    public PlayerAbilitiesLogic PlayerAbilitiesLogic => _playerAbilitiesLogic;

    public void Init(InputHandler inputHandler, PlayerMovement playerMovement,PlayerAbilitiesLogic playerAbilitiesLogic) {
        _inputHandler = inputHandler;
        _playerMovement = playerMovement;
        _playerAbilitiesLogic = playerAbilitiesLogic;
    }

    private void Awake() {
        NormalState = new PlayerNormalState(this);
        InvisibleState = new PlayerInvisibleState(this);
        _currentAbility = NormalState;
    }

    private void Start() {
        ChangeAbility(_currentAbility);
    }

    void Update() {
        _currentAbility?.Update();
    }

    public void ChangeAbility(PlayerAbility newAbility) {
        _currentAbility?.Exit();
        _currentAbility = newAbility;
        _currentAbility.Enter();
    }



}
