using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController _characterController;

    private const float _gravity = -9.81f;
    private float _verticalVelocity;

    private float _stickVelocity = -2f;
    private Vector3 _movement;
    private Vector3 _velocity;
    private bool _isGrounded;
    private Vector2 _movementInput;

    private bool _isMoving => _movementInput != Vector2.zero;

    [SerializeField] private PlayerMovementSettings _movementSettings;

    #region Event Channels
    [Header("Broadcast on Event Channels")]
    [SerializeField] private BoolEventChannelSO OnPlayerMoving;

    [Header("Listen to Event Channels")]
    [SerializeField] private Vector2EventChannelSO OnMovement;
    [SerializeField] private VoidEventChannelSO OnJump;
    #endregion Event Channels

    public void Init()
    {
        if (_movementSettings == null)
        {
            Debug.LogError("PlayerMovementSettings is not assigned in PlayerMovement.");
        }
    }

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
    }

    private void OnEnable()
    {
        OnMovement.OnEventRaised += SetMovementInput;
        OnJump.OnEventRaised += Jump;
    }

    private void OnDisable()
    {
        OnMovement.OnEventRaised -= SetMovementInput;
        OnJump.OnEventRaised -= Jump;
    }

    private void SetMovementInput(Vector2 movementInput)
    {
        _movementInput = movementInput;
    }

    private void Update()
    {
        Move();
    }

    public void Move()
    {
        _movement.x = _movementInput.x;
        _movement.y = 0;
        _movement.z = _movementInput.y;
        
        // Reuse velocity vector
        _velocity.x = _movement.x * _movementSettings.MovementSpeed;
        _velocity.z = _movement.z * _movementSettings.MovementSpeed;

        // Apply gravity
        if (_isGrounded)
        {
            _verticalVelocity = _stickVelocity;
        }
        else
        {
            _verticalVelocity += _gravity * Time.deltaTime;
        }

        _velocity.y = _verticalVelocity;

        _characterController.Move(Time.deltaTime * _velocity);

        // Cache ground state for next frame
        _isGrounded = _characterController.isGrounded;

        OnPlayerMoving.RaiseEvent(_isMoving);
    }

    private void Jump()
    {
        if (_isGrounded)
        {
            _verticalVelocity = MathF.Sqrt(-2f * _gravity * _movementSettings.JumpHeight);
            _isGrounded = false;
        }
    }
}