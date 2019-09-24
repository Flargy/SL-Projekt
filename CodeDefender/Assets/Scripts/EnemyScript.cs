using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyScript : MonoBehaviour
{
    public bool playerLocated = false;
    public GameObject player;
    public GameObject fightTrigger;

    private NavMeshAgent agent;
    private float followDelay = 0;
    private float attackDelay;
    private bool canAttack = true;

    void Start()
    {
        agent = gameObject.GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerLocated)
        {
            if(canAttack == false)
            {
                attackDelay += Time.deltaTime;
                if(attackDelay >= 1.5f)
                {
                    canAttack = true;
                }
            }

            followDelay += Time.deltaTime;
            if (followDelay > 0.3f)
            {
                agent.SetDestination(player.transform.position);
                followDelay = 0.0f;
            }
            
            if (CheckRemainingDistance(player.transform.position, 1.0f))
            {
                if (canAttack == true)
                {
                    player.GetComponent<PlayerController>().TakeDamage();
                    canAttack = false;
                    attackDelay = 0.0f;
                }

            }
        }
        
    }

    public void Die()
    {
        fightTrigger.GetComponent<FightTrigger>().RemoveEnemy(gameObject);
        Destroy(gameObject);
    }

    private bool CheckRemainingDistance(Vector3 destination, float acceptableRange)
    {
        return (destination - transform.position).sqrMagnitude < acceptableRange * acceptableRange;
    }
}
