using UnityEngine;

[CreateAssetMenu(fileName = "PlayerMovementSettings", menuName = "Scriptable Objects/Player/PlayerMovementSettings")]
public class PlayerMovementSettings : ScriptableObject
{
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private float _invisibleMoveSpeed = 2.5f;
    [SerializeField] private float _jumpHeight = 5f;

    public float MoveSpeed => _moveSpeed;
    public float InvisibleMoveSpeed => _invisibleMoveSpeed;
    public float JumpHeight => _jumpHeight;
}
