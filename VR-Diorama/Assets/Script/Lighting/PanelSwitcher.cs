using UnityEngine;

public class PanelSwitcher : MonoBehaviour
{
    private GameObject ActivePanel;
    public void swapPanel(GameObject panel)
    {
        ActivePanel?.SetActive(false);
        panel.SetActive(true);
        ActivePanel = panel;
    }
}
