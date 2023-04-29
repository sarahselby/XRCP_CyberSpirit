using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LookAtController : MonoBehaviour
{
    public string lookAtGameobjectTag;
    public float interactionRadius = 20;
    public Transform defaultLookTarget;
    public GameObject constraintTarget;
    public float lookAtAngleLimit = 50;
    public Vector3 lookAtObjectOffset;
    public bool lookDirectlyAt = true;
    [Tooltip("Look At Target Range is only used if Look Directly At is false.")]
    public float lookAtTargetRange = 10;

    private GameObject lookAtObject;

    // Start is called before the first frame update
    void Start()
    {
        //in this case it is the user / xr rig that is the lookAtObject
        lookAtObject = GameObject.FindGameObjectWithTag(lookAtGameobjectTag);
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 targetVector = (lookAtObject.transform.position + lookAtObjectOffset) - transform.position;

        //angle between two vectors 
        // angle is 0 when vectors are aligned, angle value no higher than 180 in both directions
        float angle = Vector3.Angle(targetVector, transform.forward); 
        float distance = targetVector.magnitude;

        
        // check if the user is close enough (distance) and not behind the character (angle) 
        if (distance <= interactionRadius && angle <= lookAtAngleLimit)
        {
            
            Vector3 newTargetPos;
            if (lookDirectlyAt)
            {
                newTargetPos = lookAtObject.transform.position + lookAtObjectOffset;
            }
            else
            {
                Vector3 direction = targetVector.normalized;
                newTargetPos = transform.position + direction * lookAtTargetRange; 
            }
            
            //Lerp using delta time (time between frames) keeps it independant of frame rate
            constraintTarget.transform.position = Vector3.Lerp(constraintTarget.transform.position, newTargetPos, Time.deltaTime * 4f);
           // Debug.Log(angle); // un comment to understand the range
        }
        else
        {

            Vector3 newTargetPos = defaultLookTarget.position;//transform.position + transform.forward * lookAtTargetRange + transform.up * 2f;
             constraintTarget.transform.position = Vector3.Lerp(constraintTarget.transform.position, newTargetPos, Time.deltaTime * 3f);

        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position,interactionRadius);
    }
}
