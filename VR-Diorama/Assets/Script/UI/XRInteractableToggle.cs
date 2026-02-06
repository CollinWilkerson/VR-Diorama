using UnityEngine;
using UnityEngine.UI;
public class XRInteractableToggle : MonoBehaviour
{
    private Toggle toggle;

    private void Start()
    {
        toggle = GetComponent<Toggle>();
    }

    public void Toggle()
    {
        toggle.isOn = !toggle.isOn;
    }
}
