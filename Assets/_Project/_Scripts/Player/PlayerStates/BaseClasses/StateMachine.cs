using Unity.VisualScripting;
using UnityEngine;

public class StateMachine
{
    private PlayerState _currentState;

    public PlayerState CurrentState => _currentState;

    public void Update()
    {
        _currentState?.Update();
    }

    public void ChangeState(PlayerState newState)
    {
        _currentState?.Exit();
        _currentState = newState;
        _currentState.Enter();
    }
}
