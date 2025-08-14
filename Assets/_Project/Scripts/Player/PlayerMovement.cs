using UnityEngine;

//Enum for movement
public enum PlayerMovementSpeed
{
    Normal,
    Invisible
}

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    PlayerInputHandler inputHandler;
    CharacterController characterController;

    [Header("Ground Check Settings")]
    [SerializeField] LayerMask groundLayer;
    [SerializeField] Transform groundCheckTransform;
    [SerializeField] float groundCheckDistance = 0.3f;

    [SerializeField] PlayerMovementSettings movementSettings;

    const float gravity = -9.81f;

    Vector3 velocity;
    float currentMoveSpeed;
    float verticalVelocity;
    bool isGrounded;

    public void Init(PlayerInputHandler inputHandler) => this.inputHandler = inputHandler;

    void Awake()
    {
        characterController = GetComponent<CharacterController>();
        currentMoveSpeed = movementSettings.NormalMoveSpeed;
    }

    void Update()
    {
        ApplyGravity();

        characterController.Move(velocity * Time.deltaTime);

        CheckGroundStatus();
    }

    void ApplyGravity()
    {
        if (isGrounded) verticalVelocity = 0f;
        else verticalVelocity += gravity * movementSettings.GravityMultiplier * Time.deltaTime;

        velocity.y = verticalVelocity;
    }

    void CheckGroundStatus() => isGrounded = Physics.Raycast(groundCheckTransform.position, Vector3.down, groundCheckDistance, groundLayer);

    public void Move()
    {
        velocity = new Vector3(inputHandler.MovementInput.x * currentMoveSpeed, velocity.y, inputHandler.MovementInput.y * currentMoveSpeed);
    }

    public void Jump() => verticalVelocity = isGrounded ? Mathf.Sqrt(-2f * movementSettings.JumpHeight * gravity * movementSettings.GravityMultiplier) : verticalVelocity;

    public void SetMoveSpeed(PlayerMovementSpeed speedType)
    {
        switch (speedType)
        {
            case PlayerMovementSpeed.Normal:
                currentMoveSpeed = movementSettings.NormalMoveSpeed;
                break;
            case PlayerMovementSpeed.Invisible:
                currentMoveSpeed = movementSettings.InvisibleMoveSpeed;
                break;
        }
    }
}
