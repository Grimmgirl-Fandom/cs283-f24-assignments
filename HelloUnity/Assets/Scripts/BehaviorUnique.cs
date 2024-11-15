using BTAI;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;


public class BehaviorUnique : MonoBehaviour
{
    private Root m_btRoot = BT.Root();
    Animator my_Animator;
    public GameObject player;
    public GameObject fireballs;


    // Start is called before the first frame update
    void Start()
    {
        my_Animator = gameObject.GetComponent<Animator>();
        fireballs.SetActive(false);
        BTNode fire = BT.RunCoroutine(FireTime);

        Sequence sequence = BT.Sequence();
        sequence.OpenBranch(fire);

        m_btRoot.OpenBranch(sequence);
    }


    // Update is called once per frame
    void Update()
    {
        m_btRoot.Tick();

    }
    IEnumerator<BTState> FireTime()
    {


        Vector3 a = transform.position;
        Vector3 b = player.gameObject.transform.position;
        float distance = (a - b).magnitude;


        // wait for agent to reach destination
        //while (agent.remainingDistance < 1)
        while (distance < 3)
        {
            fireballs.SetActive(true);
            my_Animator.Play("Base Layer.BananaRig|WinnerDance");
            a = transform.position;
            b = player.gameObject.transform.position;
            distance = (a - b).magnitude;
            yield return BTState.Continue;
        }
        my_Animator.Play("Base Layer.BananaRig|Idle");
        fireballs.SetActive(false);
        yield return BTState.Success;

    }

}
