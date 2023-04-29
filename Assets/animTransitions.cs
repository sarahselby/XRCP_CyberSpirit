using UnityEngine;
using System.Collections;

public class animTransitions : MonoBehaviour
{

    Animator animator;

    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void selectedIt()
    {

            animator.SetTrigger("isDefeatedAnim");

    }
}
