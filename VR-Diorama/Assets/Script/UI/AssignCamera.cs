using UnityEngine;

public class AssignCamera : MonoBehaviour
{
        void Start()
        {
            Canvas canvas = GetComponent<Canvas>();
            if (canvas && canvas.worldCamera == null)
            {
                canvas.worldCamera = Camera.main;
            }
        }
}
