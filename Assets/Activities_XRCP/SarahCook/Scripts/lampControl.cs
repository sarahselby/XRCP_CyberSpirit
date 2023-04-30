using UnityEngine;

public class lampControl : MonoBehaviour
{
    public GameObject objectToActivate;
// public bool lightState;

    private bool _previousValue = false;
    private bool _currentValue = false;

    public void lampSelected()
    {
        _currentValue = !_previousValue;
        Debug.Log("lamp state changed");
    }

    void Update()
    {
        if (_currentValue == true)
        {
            objectToActivate.SetActive(true);
            Debug.Log("lamp on");
        }
        else
        {
            objectToActivate.SetActive(false);
            Debug.Log("lamp off");
        }

        _previousValue = _currentValue;
    }
}

