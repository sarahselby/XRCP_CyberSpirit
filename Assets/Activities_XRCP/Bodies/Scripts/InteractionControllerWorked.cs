using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class InteractionControllerWorked : MonoBehaviour
{
    public float followRadius;
    public float waitToFollow = 3;
    private GameObject player;
    private NavMeshAgent agent;
    private Animator animator;
    private float waitTimer;
    private bool hasWavedGoodbye;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();

        waitTimer = 0;
        hasWavedGoodbye = true; // we only want to wave goodbye once the agent has followed us
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(player.transform.position,transform.position);

        if(distance <= followRadius)
        {
            
                if (distance <= agent.stoppingDistance)
                {
                    animator.SetBool("Walking", false);
                    waitTimer = 0;
                }
                else
                {
                    waitTimer += Time.deltaTime;
                    
                    Debug.Log(waitTimer);
                    if (waitTimer >= waitToFollow)
                    {
                        hasWavedGoodbye = false; // once the agent has followed us we want them to wave goodbye if we escape



                        agent.isStopped = false;
                        agent.SetDestination(player.transform.position);




                        animator.SetBool("Walking", true);
                    }
                }
        }
        else
        {
            
            if (hasWavedGoodbye == false)
            {
                agent.isStopped = true;
                animator.SetBool("Walking", false);
                DoWave();

            }
        }
    }

    private void DoWave()
    {
        waitTimer = 0;
        hasWavedGoodbye = true;
        animator.SetTrigger("Wave");
        Debug.Log("Set trigger");
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, followRadius);
    }
}