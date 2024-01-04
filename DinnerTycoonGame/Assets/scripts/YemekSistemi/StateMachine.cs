using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine 
{
    public YemekState currentYemekState;

    //statemachine'yi başlattı
    public void Initialize(YemekState startingState)
    {
        currentYemekState = startingState;
        currentYemekState.EnterState();
    }

    //state değiştirdi
    public void ChangeState(YemekState newState)
    {
        currentYemekState.ExitState();
        currentYemekState = newState;
        currentYemekState.EnterState();
    }
}
