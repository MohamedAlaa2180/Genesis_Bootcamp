using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerSettings", menuName = "ScriptableObjects/PlayerSettings", order = 1)]
public class PlayerSettings : ScriptableObject
{
    [SerializeField] float _movementSpeed = 5f;
    [SerializeField] float _rotationSpeed = 10f;
    [SerializeField] float _jumpHeight = 2f;
    [SerializeField] float _gravityFactor = 2f;

    public float MovementSpeed => _movementSpeed;
    public float RotationSpeed => _rotationSpeed;

    public float JumpHeight => _jumpHeight;

    public float GravityFactor => _gravityFactor;

    public void SetMovementSpeed(float speed) {
        _movementSpeed = speed;
    }
}
