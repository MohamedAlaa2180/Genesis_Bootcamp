using UnityEngine;

[RequireComponent(typeof(PlayerMovement), typeof(PlayerInputHandler), typeof(PlayerStateMachine))]
[RequireComponent(typeof(PlayerVisualHandler), typeof(PlayerAbilityManager))]
public class PlayerController : MonoBehaviour
{
    PlayerMovement playerMovement;
    PlayerInputHandler playerInputHandler;
    PlayerStateMachine playerStateMachine;
    PlayerVisualHandler playerVisualHandler;
    PlayerAbilityManager playerAbilityManager;

    void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
        playerInputHandler = GetComponent<PlayerInputHandler>();
        playerStateMachine = GetComponent<PlayerStateMachine>();
        playerVisualHandler = GetComponent<PlayerVisualHandler>();
        playerAbilityManager = GetComponent<PlayerAbilityManager>();
        Init();
    }

    void Init()
    {
        playerMovement.Init(playerInputHandler);
        playerStateMachine.Init(playerInputHandler, playerMovement, playerVisualHandler);
        playerAbilityManager.Init(playerInputHandler, playerStateMachine);
    }
}