using UnityEngine;
using UnityEngine.Events;

public class InputController : MonoBehaviour
{

    public UnityEvent RightTriggerDownEvent = new UnityEvent();
    public UnityEvent RightTriggerUpEvent = new UnityEvent();

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("XRI_Right_TriggerButton"))
        {
            Debug.Log("Trigger down");
            RightTriggerDownEvent.Invoke();
        }
        else if (Input.GetButton("XRI_Right_TriggerButton"))
        {
            Debug.Log("Trigger is pressed");
        }
        else if (Input.GetButtonUp("XRI_Right_TriggerButton"))
        {
            Debug.Log("Trigger up");
            RightTriggerUpEvent.Invoke();
        }
    }
}
