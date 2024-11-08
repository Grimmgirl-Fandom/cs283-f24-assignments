using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Wander : MonoBehaviour
{
    private NavMeshAgent agent;
    Vector3 target;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        target = new Vector3((float)0, (float)-6.38, (float)0);

        target = setTarget();
        agent.SetDestination(target);

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

    Vector3 setTarget()
    {

        Vector3 point;
        if (RandomPoint(transform.position, (float) 10, out point))
        {
           if(point!=target)
            return point;
        }

        Vector3 t = new Vector3((float)0, (float)-6.38, (float)0);

        return t;

    }

    // Update is called once per frame
    void Update()
    {
    
        if(agent.remainingDistance<5)
        {
            target = setTarget();
            agent.SetDestination(target);
        }


    }
}
