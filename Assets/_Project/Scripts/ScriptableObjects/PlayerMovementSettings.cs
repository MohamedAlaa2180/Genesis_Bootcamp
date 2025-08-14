using UnityEngine;

[CreateAssetMenu(fileName = "PlayerMovementSettings", menuName = "SOs/Player/Movement Settings")]
public class PlayerMovementSettings : ScriptableObject
{
    [Header("Movement Settings")]
    [SerializeField] float normalMoveSpeed = 5f;
    [SerializeField] float invisibleMoveSpeed = 3f;
    [SerializeField] float jumpHeight = 2f;
    [SerializeField, Range(1f, 10f)] float gravityMultiplier = 1f;

    public float NormalMoveSpeed => normalMoveSpeed;
    public float InvisibleMoveSpeed => invisibleMoveSpeed;
    public float JumpHeight => jumpHeight;
    public float GravityMultiplier => gravityMultiplier;
}
