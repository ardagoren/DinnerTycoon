using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ready : YemekState
{

    public Ready(Yemek yemek, StateMachine stateMachine) : base(yemek, stateMachine)
    {
    }

    public override void EnterState()
    {
        base.EnterState();
    }

    public override void ExitState()
    {
        base.ExitState();
        
    }

    public override void FrameUpdate()
    {
        base.FrameUpdate();
        Collider2D hit = Physics2D.OverlapCircle(yemek.gameObject.transform.position, 0.7f, ~yemek.layerMask);

        if (hit != null)
        {
            if (!yemek.playerScript.eliBos && hit.name == "player" && Input.GetKeyDown(KeyCode.E))
            {
                
                if (yemek.gameObject.name == "corba" && yemek.playerScript.elindekiCorba)
                {
                    yemek.playerScript.elindekiCorba = false;
                    yemek.playerScript.eliBos = true;
                    yemek.StateMachine.ChangeState(yemek.taken);
                   
                }
                else if (yemek.gameObject.name == "tavuk" && yemek.playerScript.elindekiTavuk)
                {
                    yemek.playerScript.elindekiTavuk = false;
                    yemek.playerScript.eliBos = true;
                    yemek.StateMachine.ChangeState(yemek.taken);
                }
                else if (yemek.gameObject.name == "et" && yemek.playerScript.elindekiEt)
                {
                    yemek.playerScript.elindekiEt = false;
                    yemek.playerScript.eliBos = true;
                    yemek.StateMachine.ChangeState(yemek.taken);
                }
            }
        }
    }
}
