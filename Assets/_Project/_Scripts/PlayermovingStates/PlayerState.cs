using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerState
{
    protected PlayerMovementStateMachine _playerMovingStateMachine;
    public PlayerState( PlayerMovementStateMachine playerMovingStateMachine)
    {
        _playerMovingStateMachine = playerMovingStateMachine;
    }
    public virtual void Enter() { }
    public virtual void Exit() { }
    public virtual void Update() { }
}
