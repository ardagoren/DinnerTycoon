using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Preparing : YemekState
{
    float counter;
    public Preparing(Yemek yemek, StateMachine stateMachine) : base(yemek, stateMachine)
    {
    }

    public override void EnterState()
    {
        base.EnterState();
        
       
    }

    public override void ExitState()
    {
        base.ExitState();
        if (yemek.gameObject.name == "corba")
            yemek.mutfak.GetComponent<Mutfak>().corbaCount++;
        else if (yemek.gameObject.name == "tavuk")
            yemek.mutfak.GetComponent<Mutfak>().tavukCount++;
        else if (yemek.gameObject.name == "et")
            yemek.mutfak.GetComponent<Mutfak>().etCount++;

    }

    public override void FrameUpdate()
    {
        base.FrameUpdate();
        //pişirme süresi kadar sonra ready state'ine geçti
        counter += Time.deltaTime;
        if (counter > yemek.pisirmeSuresi)
        {
            yemek.StateMachine.ChangeState(yemek.ready);
        }
        
    }

}
