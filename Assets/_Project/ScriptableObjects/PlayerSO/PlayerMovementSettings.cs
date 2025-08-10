using UnityEngine;

[CreateAssetMenu(fileName = "PlayerMovementSettings", menuName = "Sos/Player/MovementSettings")]

public class PlayerMovementSettings : ScriptableObject
{
    [SerializeField] private float _movementSpeed;
    [SerializeField] private float _jumpHeight = 5f;

    public float MovementSpeed => _movementSpeed;
    public float JumpHeight => _jumpHeight;
}