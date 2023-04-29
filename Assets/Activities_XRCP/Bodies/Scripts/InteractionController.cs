using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class InteractionController : MonoBehaviour
{
    public float followRadius = 5; // default is distance of 5
    public float waitToFollow = 3; // default is wait 3 seconds
    private GameObject player;
    private NavMeshAgent agent;
    private Animator animator;
    private float waitTimer; // we will use this to count how long the agent has waited

    //add in the boolean for waving here


    // Start is called before the first frame update
    void Start()
    {
        // we have hard-coded this Player tag name here you can adapt it to be more flexible if you want (like in the LookAtController)
        player = GameObject.FindGameObjectWithTag("Player");

        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();

        waitTimer = 0;

        // we will set out hasWavedGoodbye boolen to trye here because we want to wave goodbye only once the agent has followed us first

    }

    // Update is called once per frame
    void Update()
    {
        //we check the distance between our nav agent and our player
        float distance = Vector3.Distance(player.transform.position,transform.position);

        if(distance <= followRadius)
        {
            Debug.Log("Close enough to follow");
            // Follow player logic here


        }
        else
        {
            //Add call to waving goodbye function here


        }
    }



    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, followRadius);
    }
}