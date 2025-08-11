using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementStateMachine : MonoBehaviour
{
    PlayerState _currentState;
    InputHandler _inputHandler;
    PlayerMovement _playerMovement;

    public PlayerMovingState MovingState { get; private set; }

    public PLayerIdelState IdleState { get; private set; }

    public PlayerJumpingState JumpingState { get; private set; }



    public PlayerMovement PlayerMovement => _playerMovement;
    public InputHandler InputHandler => _inputHandler;


    public void Init(InputHandler inputHandler, PlayerMovement playerMovement) {
        _inputHandler = inputHandler;
        _playerMovement = playerMovement;
    }



    private void Awake() {
        MovingState = new PlayerMovingState(this);
        IdleState = new PLayerIdelState(this);
        JumpingState = new PlayerJumpingState(this);

        _currentState = IdleState; // Set initial state to Idle
    }

    private void Start() {
        ChangeState(_currentState); // Change to MovingState at the start
    }

    void Update() {
        _currentState?.Update();
    }

    public void ChangeState(PlayerState newState) {
        _currentState?.Exit();
        _currentState = newState;
        _currentState.Enter();
    }


}
