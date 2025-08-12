using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private PlayerInputsHandler _playerInputsHandler;

    private CharacterController _characterController;

    private const float _gravity = -9.81f;
    private float _verticalVelocity;

    private float _stickVelocity = -2f;
    private Vector3 _movementInput;
    private Vector3 _velocity;
    private bool _isGrounded;

    [SerializeField] private PlayerMovementSettings _movementSettings;
    
    // Speed modification system
    private float _speedMultiplier = 1f;

    public void Init(PlayerInputsHandler playerInputsHandler)
    {
        _playerInputsHandler = playerInputsHandler;
        if(_playerInputsHandler == null)
        {
            Debug.LogError("PlayerInputsHandler is not assigned in PlayerMovement.");
        }
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
        if (_playerInputsHandler != null)
        {
            _playerInputsHandler.OnJump += Jump;
        }
    }

    private void OnDisable()
    {
        if (_playerInputsHandler != null)
        {
            _playerInputsHandler.OnJump -= Jump;
        }
    }

    public void Move()
    {
        // Reuse existing Vector3 instead of creating new one
        Vector2 inputVector = _playerInputsHandler.MovementInput;
        _movementInput.x = inputVector.x;
        _movementInput.y = 0;
        _movementInput.z = inputVector.y;
        
        // Reuse velocity vector with speed multiplier
        float effectiveSpeed = _movementSettings.MovementSpeed * _speedMultiplier;
        _velocity.x = _movementInput.x * effectiveSpeed;
        _velocity.z = _movementInput.z * effectiveSpeed;

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
    }

    private void Jump()
    {
        if (_isGrounded)
        {
            _verticalVelocity = MathF.Sqrt(-2f * _gravity * _movementSettings.JumpHeight);
            _isGrounded = false;
        }
    }
    
    /// <summary>
    /// Set speed multiplier for current movement
    /// </summary>
    public void SetSpeedMultiplier(float multiplier)
    {
        _speedMultiplier = Mathf.Max(0f, multiplier); // Prevent negative speeds
    }
    
    /// <summary>
    /// Reset speed to normal
    /// </summary>
    public void ResetSpeed()
    {
        _speedMultiplier = 1f;
    }
    
    /// <summary>
    /// Get current speed multiplier
    /// </summary>
    public float GetSpeedMultiplier() => _speedMultiplier;
}