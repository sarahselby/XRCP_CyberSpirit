using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// All code taken from here:
//https://www.youtube.com/watch?v=tBYl-aSxUe0

[System.Serializable]
public class VRMap
{
    public Transform vrTarget;
    public Transform rigTarget;
    public Vector3 trackingPositionOffset;
    public Vector3 trackingRotationOffset;

    public void Map()
    {
        rigTarget.position = vrTarget.TransformPoint(trackingPositionOffset);
        rigTarget.rotation = vrTarget.rotation * Quaternion.Euler(trackingRotationOffset);
    }
}

public class ThreePointRig : MonoBehaviour
{
    public VRMap head;
    public VRMap leftHand;
    public VRMap rightHand;

    public Transform headConstraint;
    public Vector3 headBodyOffset;

    // Start is called before the first frame update
    void Start()
    {
        headBodyOffset = transform.position - headConstraint.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = headConstraint.position + headBodyOffset;
      
        //You might not need the following couple of lines, but if the body flips around when you look up or down test them out
       // float headAngle = Vector3.Angle(headConstraint.up, Vector3.up);
       // Debug.Log(headAngle);
       // if(headAngle > 35 && headAngle < 120)
       // {
        //   transform.forward = Vector3.ProjectOnPlane(headConstraint.up, Vector3.up).normalized;
        //}
   

        //this is how we map our rig constraints to our XR toolkit rotation & position of head and hands
        if (head.vrTarget != null)
        {
            head.Map();
        }
        if (leftHand.vrTarget != null)
        {
            leftHand.Map();
        }
        if (rightHand.vrTarget != null)
        {
            rightHand.Map();
        }

    }
}
