using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{

    public float lookRadius = 10f;
    Transform target;
    NavMeshAgent agent;
    public Animator animator;
    public PlayerStatus playerHealth;
    private bool isAttacking = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        target = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();

    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);

        if(distance <= lookRadius)
        {
            agent.SetDestination(target.position);

            if(distance <= agent.stoppingDistance)
            {
                //Attack and face target
                if (!isAttacking)
                {
                    StartCoroutine(AttackPlayerRoutine());
                }
                FaceTarget();
            }
        }
    }

    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime*5f);

    }

    private IEnumerator AttackPlayerRoutine()
    {
        isAttacking = true;

        animator.SetTrigger("AttackPlayer");
        //leaves it up to chance if the zombie hits
        int landsHit = Random.Range(0,2);
        if(landsHit == 1)
        {
            playerHealth.health -= 15;
        }

        yield return new WaitForSeconds(1.5f);

        isAttacking = false;

    }

}
