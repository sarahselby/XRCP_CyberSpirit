using UnityEngine;

public class fairyControl : MonoBehaviour
{
    public GameObject objectToActivate;
    public bool activateOnTrue;

    private bool _previousValue = false;
    private bool _currentValue = false;

    public void lightSelected()
    {
        _currentValue =! _previousValue;
        Debug.Log("fairy light state changed");
    }

    void Update()
    {
        if (_currentValue == true)
        {
            objectToActivate.SetActive(true);
            Debug.Log("light on");
        }
            else
            {
                objectToActivate.SetActive(false);
                Debug.Log("light off");
            }

        _previousValue = _currentValue;
    }
 }

