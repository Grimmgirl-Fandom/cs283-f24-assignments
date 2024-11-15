using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;
using BTAI;

class AIState
{
    public class Transition
    {
        public System.Func<bool> fn;
        public AIState next;
    }
    public List<Transition> transitions = new List<Transition>();
    private bool isFinished = false;
    private AIState next = null;

    public AIState() { }
    public bool IsTriggered() { return isFinished; }
    public virtual void Enter() { isFinished = false; }
    public virtual void Exit() { }
    public virtual void Update(float dt)
    {
        foreach (Transition transition in transitions)
        {
            if (transition.fn())
            {
                isFinished = true;
                next = transition.next;
            }
        }
    }
    public AIState Next() { return next; }
}

class AIWander : AIState
{
    public WanderFSM entity;

    public AIWander(WanderFSM component)
    {
        entity = component;
    }

    public override void Enter()
    {
        base.Enter();
        NavMeshAgent agent = entity.GetComponent<NavMeshAgent>();

        Vector3 target;
        target = new Vector3(0, 0, 0);
       // Utils.RandomPointOnTerrain(
         //  entity.wanderRange.position,
         //  entity.wanderRange.localScale.x,
         //  out target);

        agent.SetDestination(target);
    }

    public bool ReachedDestination()
    {
        NavMeshAgent agent = entity.GetComponent<NavMeshAgent>();
        return (agent.remainingDistance < 0.1f);
    }
}

class AIController
{
    private AIState root = null;
    private AIState current = null;

    public AIController(AIState r)
    {
        root = r;
        current = root;
    }

    public void Update(float dt)
    {
        current.Update(dt);
        if (current.IsTriggered())
        {
            current.Exit();
            current = current.Next();
            current.Enter();
        }
    }
}


public class WanderFSM : MonoBehaviour
{
    public Transform wanderRange;  // Set to a sphere
    private AIController m_controller;

    void Start()
    {
        AIWander wander = new AIWander(this);

        AIState.Transition repeat = new AIState.Transition();
        repeat.fn = wander.ReachedDestination;
        repeat.next = wander;

        wander.transitions.Add(repeat);

        m_controller = new AIController(wander);
    }

    void Update()
    {
        m_controller.Update(Time.deltaTime);
    }
}
