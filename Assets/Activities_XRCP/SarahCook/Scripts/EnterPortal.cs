using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterPortal : MonoBehaviour
{
    [Tooltip("State to change to")]
    public State TargetState;

    // Start is called before the first frame update
    public void EnterThroughPortal()
    {
        GameManager.Instance.UpdateState(TargetState);
    }
}
