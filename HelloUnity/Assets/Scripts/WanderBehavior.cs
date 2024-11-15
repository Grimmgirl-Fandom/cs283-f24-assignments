using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;
using BTAI;

public class WanderBehavior : MonoBehaviour
{
    public Transform wanderRange;  // Set to a sphere
    private Root m_btRoot = BT.Root(); 

    void Start()
    {
        BTNode moveTo = BT.RunCoroutine(MoveToRandom);

        Sequence sequence = BT.Sequence();
        sequence.OpenBranch(moveTo);

        m_btRoot.OpenBranch(sequence);
    }

    void Update()
    {
        m_btRoot.Tick();
    }

    bool RandomPoint(Vector3 center, float range, out Vector3 result)
    {
        for (int i = 0; i < 30; i++)
        {
            Vector3 randomPoint = center + Random.insideUnitSphere * range;
            NavMeshHit hit;
            if (NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas))
            {
                result = hit.position;
                return true;
            }
        }
        result = Vector3.zero;
        return false;
    }

    IEnumerator<BTState> MoveToRandom()
    {
       NavMeshAgent agent = GetComponent<NavMeshAgent>();

       Vector3 target;
       RandomPoint(wanderRange.position, wanderRange.localScale.x, out target);
       agent.SetDestination(target);
        Debug.Log(target);


        // wait for agent to reach destination
        while (agent.remainingDistance > 5)
       {
            Debug.Log("Continuing");
            Debug.Log(agent.remainingDistance);
            yield return BTState.Continue;
           
       }
        Debug.Log("Freeing");
       yield return BTState.Success;
    }
}