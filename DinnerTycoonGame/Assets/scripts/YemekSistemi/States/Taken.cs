using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Taken : YemekState
{
    float counter;
    public Taken(Yemek yemek, StateMachine stateMachine) : base(yemek, stateMachine)
    {
    }

    public override void EnterState()
    {
        base.EnterState();
        yemek.yemekFotosu.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
        yemek.yemekFotosu.transform.position = yemek.yeniSpot.transform.position;

    }

    public override void ExitState()
    {
        base.ExitState();
    }

    public override void FrameUpdate()
    {
        base.FrameUpdate();
        counter += Time.deltaTime;
        if (counter > 5)
        {
            yemek.yemekBitti = true;         
        }
    }
}
