using BTAI;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;


public class BehaviorMinion : MonoBehaviour
{
    private Root m_btRoot = BT.Root();
    Animator my_Animator;
    public GameObject home;
    public GameObject player;
    Vector3 npcHome;

    // Start is called before the first frame update
    void Start()
    {
        my_Animator = gameObject.GetComponent<Animator>();
        npcHome = transform.position;

        BTNode attack = BT.RunCoroutine(AttackTime);

        Sequence sequence = BT.Sequence();
        sequence.OpenBranch(attack);

        m_btRoot.OpenBranch(sequence);
    }


    // Update is called once per frame
    void Update()
    {
        m_btRoot.Tick();

    }

    Boolean InHomeArea()
    {


        Vector3 a = home.transform.position;
        Vector3 b = player.gameObject.transform.position;
        float distance = (a - b).magnitude;

        if(distance<1)
        { return true; }

        return false;
    }

    IEnumerator<BTState> AttackTime()
    {
        NavMeshAgent agent = GetComponent<NavMeshAgent>();

        //agent.SetDestination(player.gameObject.transform.position);


        Vector3 a = transform.position;
        Vector3 b = player.gameObject.transform.position;
        float distance = (a - b).magnitude;


        // wait for agent to reach destination
        //while (agent.remainingDistance < 1)
        while (distance < 3)
        {
            //player retreated back to base
            if (InHomeArea() == true)
            {
               agent.SetDestination(npcHome);
                my_Animator.Play("Base Layer.BananaRig|Walk");
                yield return BTState.Success;
            }

            agent.SetDestination(player.gameObject.transform.position);
            my_Animator.Play("Base Layer.BananaRig|JumpSpinAround");
            a = transform.position;
            b = player.gameObject.transform.position;
            distance = (a - b).magnitude;
            yield return BTState.Continue;
        }
        my_Animator.Play("Base Layer.BananaRig|Idle");
        yield return BTState.Success;

    }

}
