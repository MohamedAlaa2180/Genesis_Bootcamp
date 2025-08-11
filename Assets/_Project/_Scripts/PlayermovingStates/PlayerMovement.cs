using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] PlayerSettings _playerSettings;

    CharacterController _playerController;
    InputHandler _inputHandler;
    

    Vector3 _movementVector;
    Vector3 _velocity;
    Quaternion _playerRotation;

    float _gravity = -9.81f;
    float _stickToGroundForce = -2f;
    float _verticalVelocity;


    public Vector3 MovementVector => _movementVector;
    float EffectiveGravity => _gravity * _playerSettings.GravityFactor;
     public bool IsGrounded => _playerController.isGrounded;

    public void Init(InputHandler inputHandler) {
        _inputHandler = inputHandler;
    }
    private void Awake() {
        _playerController = GetComponent<CharacterController>();
        _playerSettings.SetMovementSpeed(10f);
    }

    public void JumpHandler() {
        if (IsGrounded) {
            _verticalVelocity = Mathf.Sqrt(2f * - (EffectiveGravity) * _playerSettings.JumpHeight);
        }
    }



    public void MovementHandler() {
        _movementVector = new Vector3(_inputHandler.MoveInput.x, 0, _inputHandler.MoveInput.y);

        // handling gravity
        if (IsGrounded && _verticalVelocity < 0) {
            _verticalVelocity = _stickToGroundForce;
        }
        else {
            _verticalVelocity += EffectiveGravity * Time.deltaTime;
        }
        _velocity = _movementVector * GetPlayerSpeed();
        _velocity.y = _verticalVelocity;

        _playerController.Move(Time.deltaTime * _velocity);

        //rotate the player to the movement direction
        if (_movementVector != Vector3.zero) {
            _playerRotation = Quaternion.LookRotation(_movementVector);
            transform.rotation = Quaternion.Slerp(transform.rotation, _playerRotation, Time.deltaTime * _playerSettings.RotationSpeed);
        }
    }

    public void SetPlayerSpeed(float speed) {
        _playerSettings.SetMovementSpeed(speed);
    }

    public float GetPlayerSpeed() {
        return _playerSettings.MovementSpeed;
    }
}
