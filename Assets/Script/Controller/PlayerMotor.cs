using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class PlayerMotor : MonoBehaviour
{
    public Transform target;
    NavMeshAgent agent;


    private void Update()
    {
        if(target != null)
        {
            agent.SetDestination(target.position);
            FaseTarget();
        }
    }

    public void FaseTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0f, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    public void moveTOPoint(Vector3 point)
    {
        agent.SetDestination(point);
    }
    public void followTarget(Interactable newTarget)
    {
        target = newTarget.interactionTransform;
        agent.stoppingDistance = newTarget.redius * 0.8f;
        agent.updateRotation = false;
    }
    
    public void stopFollowing()
    {
        agent.stoppingDistance = 0f;
        agent.updateRotation = true;
        target = null;
    }
}
