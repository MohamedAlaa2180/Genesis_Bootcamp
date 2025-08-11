using System;
using UnityEngine;

public class PlayerStateMachine : MonoBehaviour 
{
    private PlayerInputHandler _playerInputHandler;
    private PlayerAbilities _playerAbilities;
    private PlayerMovement _playerMovement;
    private StateMachine _locomotionStateMachine;
    private StateMachine _abilityStateMachine;
    public PlayerInputHandler PlayerInputHandler => _playerInputHandler;
    public PlayerMovement PlayerMovement => _playerMovement;
    public PlayerAbilities PlayerAbilities => _playerAbilities;
    public StateMachine LocomotionStateMachine => _locomotionStateMachine;
    public StateMachine AbilityStateMachine => _abilityStateMachine;

    public PlayerInvisibleState PlayerInvisibleState { get; private set; }
    public PlayerNoneState PlayerNoneState { get; private set; }
    public PlayerMovingState PlayerMovingState { get; private set; }
    public PlayerIdleState PlayerIdleState { get; private set; }


    public void Init(PlayerAbilities playerAbilities, PlayerMovement playerMovement, PlayerInputHandler playerInputHandler)
    {
        _playerAbilities = playerAbilities;
        _playerMovement = playerMovement;
        _playerInputHandler = playerInputHandler;
    }

    private void Awake()
    {
        PlayerInvisibleState = new PlayerInvisibleState(this);
        PlayerNoneState = new PlayerNoneState(this);
        PlayerMovingState = new PlayerMovingState(this);
        PlayerIdleState = new PlayerIdleState(this);

        _locomotionStateMachine = new StateMachine();
        _abilityStateMachine = new StateMachine();
    }

    private void Start()
    {
        _locomotionStateMachine.ChangeState(PlayerIdleState);
        _abilityStateMachine.ChangeState(PlayerNoneState);
    }

    private void Update()
    {
        _locomotionStateMachine.Update();
        _abilityStateMachine.Update();
    }

    private void OnEnable()
    {
        _playerInputHandler.OnAbilityUse += HandleAbilityUse;
        _playerInputHandler.HandleMovement += HandleMovement;
    }

    private void HandleMovement()
    {
        _locomotionStateMachine.ChangeState(PlayerMovingState);
    }

    private void OnDisable()
    {
        _playerInputHandler.OnAbilityUse -= HandleAbilityUse;
        _playerInputHandler.HandleMovement -= HandleMovement;

    }

    private void HandleAbilityUse(AbilityType type)
    {
        if (!PlayerAbilities.IsInvisible) _abilityStateMachine.ChangeState(PlayerInvisibleState);
        else _abilityStateMachine.ChangeState(PlayerNoneState);
    }
}
