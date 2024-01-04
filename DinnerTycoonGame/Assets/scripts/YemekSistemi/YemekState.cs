using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YemekState 
{
    protected Yemek yemek;
    protected StateMachine stateMachine;

    public YemekState(Yemek yemek,StateMachine stateMachine)
    {
        this.yemek = yemek;
        this.stateMachine = stateMachine;
    }

    public virtual void EnterState() { }

    public virtual void ExitState() { }

    public virtual void FrameUpdate() { }

}
