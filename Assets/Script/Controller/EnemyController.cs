using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public float lookRedius = 5f;

    Transform target;
    NavMeshAgent agent;

    CharacterCombat combat;
    // Start is called before the first frame update
    void Start()
    {
        target = PlayerManager.instence.player.transform;
        agent = GetComponent<NavMeshAgent>();
        combat = GetComponent<CharacterCombat>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);   
        if(distance <= lookRedius)
        {
            agent.SetDestination(target.position);
            if(distance <= agent.stoppingDistance)
            {
                CharecterStats targetStat = target.GetComponent<CharecterStats>();
                if(targetStat != null)
                {
                    combat.Attack(targetStat);
                }
                
                FaceTarget();

            }
        }
    }

    public void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0f, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRedius);
    }
}
