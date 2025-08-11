using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
    public event Action OnJumpPressed;
    public event Action OnDisappearPressed;

    PlayerActions _playerActions;
    public Vector2 MoveInput { get; private set; }




    private void Awake() {
        _playerActions = new PlayerActions();
    }

    private void OnEnable() {
        _playerActions.Enable();
        _playerActions._PlayerActions.Movement.performed += SetMovement;
        _playerActions._PlayerActions.Movement.canceled += SetMovement;
        _playerActions._PlayerActions.Jump.performed += SetJump;
        _playerActions._PlayerActions.Disappear.performed += SetDisappear;
    }

   
    private void OnDisable() {
        _playerActions.Disable();
        _playerActions._PlayerActions.Movement.performed -= SetMovement;
        _playerActions._PlayerActions.Movement.canceled -= SetMovement;
        _playerActions._PlayerActions.Jump.performed -= SetJump;
        _playerActions._PlayerActions.Disappear.performed -= SetDisappear;
    }

    private void SetMovement(InputAction.CallbackContext context) {
        MoveInput = context.ReadValue<Vector2>();
    }
    private void SetJump(InputAction.CallbackContext context) {
        if (context.performed) OnJumpPressed?.Invoke();
        Debug.Log("Jump Pressed");
    }
    private void SetDisappear(InputAction.CallbackContext context) {
        if (context.performed) OnDisappearPressed?.Invoke();
    }

}
