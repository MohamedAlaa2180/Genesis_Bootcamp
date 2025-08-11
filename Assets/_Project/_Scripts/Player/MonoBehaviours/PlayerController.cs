using UnityEngine;

[RequireComponent(typeof(PlayerInputHandler), typeof(PlayerMovement), typeof(PlayerAbilities))]
public class PlayerController : MonoBehaviour
{
    private PlayerInputHandler _playerInputHandler;
    private PlayerMovement _playerMovement;
    private PlayerAbilities _playerAbilities;
    private PlayerStateMachine _playerStateMachine;

    private void Awake()
    {
        _playerMovement = GetComponent<PlayerMovement>();
        _playerInputHandler = GetComponent<PlayerInputHandler>();
        _playerAbilities = GetComponent<PlayerAbilities>();
        _playerStateMachine = GetComponent<PlayerStateMachine>();

        Init();
    }

    private void Init()
    {
        _playerMovement.Init(_playerInputHandler, _playerAbilities);
        _playerStateMachine.Init(_playerAbilities, _playerMovement, _playerInputHandler);
    }
}
