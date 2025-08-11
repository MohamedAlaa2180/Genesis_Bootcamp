using System;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private PlayerMovementSettings _playerMovementSettings;

    private CharacterController _characterController;
    private PlayerInputHandler _playerInputHandler;
    private PlayerAbilities _abilities;
    private Vector3 _movement, _velocity;
    private bool _isGrounded;
    private float _verticalVelocity, _stickVelocity = -1f, _gravity = -9.81f;

    public PlayerMovementSettings PlayerMovementSettings => _playerMovementSettings;
    public PlayerAbilities PlayerAbilities => _abilities;

    public void Init(PlayerInputHandler playerInputHandler, PlayerAbilities playerAbilities)
    {
        _playerInputHandler = playerInputHandler;
        _abilities = playerAbilities;
    }

    private void Awake()
    {
        _movement = Vector3.zero;
        _velocity = Vector3.zero;
        _characterController = GetComponent<CharacterController>();
    }

    private void OnEnable()
    {
        _playerInputHandler.OnJump += Jump;
    }

    private void OnDisable()
    {
        _playerInputHandler.OnJump -= Jump;
    }
    
    public void MovePlayer(float moveSpeed)
    {
        _movement.x = _playerInputHandler.MovementInput.x;
        _movement.z = _playerInputHandler.MovementInput.y;

        _velocity = _movement * moveSpeed;

        if (_isGrounded) _verticalVelocity = _stickVelocity;

        else _verticalVelocity += _gravity * Time.deltaTime;
        

        _velocity.y = _verticalVelocity;
        _characterController.Move(Time.deltaTime * _velocity);
        _isGrounded = _characterController.isGrounded;
    }

    private void Jump()
    {
        if (_isGrounded) {
            _verticalVelocity = MathF.Sqrt(-2f * _gravity * _playerMovementSettings.JumpHeight);
            _isGrounded = false;
        }
    }
}
