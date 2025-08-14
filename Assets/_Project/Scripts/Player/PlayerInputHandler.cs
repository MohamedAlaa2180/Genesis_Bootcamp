using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    PlayerInputs playerInputs;
    Vector2 movementInput;

    public event Action OnJump;
    public event Action OnInvisible;

    public Vector2 MovementInput => movementInput;

    void Awake()
    {
        playerInputs = new PlayerInputs();
        playerInputs.Enable();
    }

    void OnEnable()
    {
        playerInputs.GameplayActionMap.Movement.performed += SetMovementInput;
        playerInputs.GameplayActionMap.Movement.canceled += SetMovementInput;
        playerInputs.GameplayActionMap.Jump.performed += SetJumpEvent;
        playerInputs.GameplayActionMap.Invisible.performed += SetInvisibleEvent;
    }

    void OnDisable()
    {
        playerInputs.GameplayActionMap.Movement.performed -= SetMovementInput;
        playerInputs.GameplayActionMap.Movement.canceled -= SetMovementInput;
        playerInputs.GameplayActionMap.Jump.performed -= SetJumpEvent;
        playerInputs.GameplayActionMap.Invisible.performed -= SetInvisibleEvent;
    }

    void SetMovementInput(InputAction.CallbackContext context) => movementInput = context.ReadValue<Vector2>();
    void SetJumpEvent(InputAction.CallbackContext context) => OnJump?.Invoke();
    void SetInvisibleEvent(InputAction.CallbackContext context) => OnInvisible?.Invoke();
}