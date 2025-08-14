using UnityEngine;

public class StateMachine : MonoBehaviour
{
    protected State currentState;

    protected void Update()
    {
        currentState?.Update();
    }

    public void ChangeState(State newState)
    {
        currentState?.Exit();
        currentState = newState;
        currentState.Enter();
    }
}