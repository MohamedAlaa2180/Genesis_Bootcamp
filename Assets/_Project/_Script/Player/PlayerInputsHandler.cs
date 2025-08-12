using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputsHandler : MonoBehaviour
{
    private PlayerControls _playerControls;

    #region Event Channels

    [Header("Broadcast on Event Channels")]
    [SerializeField] private Vector2EventChannelSO OnMovement;
    [SerializeField] private VoidEventChannelSO OnJump;

    [SerializeField] private AbilityKeyEventChannelSO OnAbilityKeyTriggered;

    #endregion Event Channels

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
        OnJump.RaiseEvent();
    }

    private void SetAbilityButtonEvent(InputAction.CallbackContext context, AbilityKey abilityKey)
    {
        OnAbilityKeyTriggered.RaiseEvent(abilityKey);
    }

    private void SetMovementInput(InputAction.CallbackContext context)
    {
        OnMovement.RaiseEvent(context.ReadValue<Vector2>());
    }
}