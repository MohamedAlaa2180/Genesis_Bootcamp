using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputsHandler : MonoBehaviour
{
    private PlayerControls _playerControls;
    private Vector2 _movementInput;

    public event Action OnJump;
    public event Action<AbilityKey> OnAbilityButonTriggered;

    public Vector2 MovementInput => _movementInput;

    private void Awake()
    {
        _playerControls = new PlayerControls();
    }

    private void OnEnable()
    {
        _playerControls.Enable();
        _playerControls.PlayerActionMap.Movement.performed += SetMovementInput;
        _playerControls.PlayerActionMap.Movement.canceled += SetMovementInput; // To reset input when movement stops
        _playerControls.PlayerActionMap.Jump.performed += SetJumpButtonEvent;
        _playerControls.PlayerActionMap.Q_Ability.performed += (context => SetAbilityButtonEvent(context, AbilityKey.Q));
    }

    private void OnDisable()
    {
        _playerControls.Disable();
        _playerControls.PlayerActionMap.Movement.performed -= SetMovementInput;
        _playerControls.PlayerActionMap.Movement.canceled -= SetMovementInput; // To reset input when movement stops
        _playerControls.PlayerActionMap.Jump.performed -= SetJumpButtonEvent;
        _playerControls.PlayerActionMap.Q_Ability.performed -= (context => SetAbilityButtonEvent(context, AbilityKey.Q));
    }

    private void SetJumpButtonEvent(InputAction.CallbackContext context)
    {
        OnJump?.Invoke();
    }

    private void SetAbilityButtonEvent(InputAction.CallbackContext context, AbilityKey abilityKey)
    {
        OnAbilityButonTriggered?.Invoke(abilityKey);
    }

    private void SetMovementInput(InputAction.CallbackContext context)
    {
        _movementInput = context.ReadValue<Vector2>();
    }
}