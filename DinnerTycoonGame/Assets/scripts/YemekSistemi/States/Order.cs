using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Order : YemekState
{
    public Order(Yemek yemek, StateMachine stateMachine) : base(yemek, stateMachine)
    {
    }

    public override void EnterState()
    {
        base.EnterState();
    }

    public override void ExitState()
    {
        base.ExitState();
        yemek.yemekFotosu.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, .5f);


    }

    public override void FrameUpdate()
    {
        base.FrameUpdate();


        Collider2D hit = Physics2D.OverlapCircle(yemek.gameObject.transform.position,0.5f,~yemek.layerMask);

        if (hit != null)
        {
            if (Input.GetKeyDown(KeyCode.E) && hit.name == "player")
            {
                yemek.StateMachine.ChangeState(yemek.Preparing);
            }
        }
    }

    
    
}
