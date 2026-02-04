using UnityEngine;
using TMPro;

public class MoveToLook : MonoBehaviour
{
    [SerializeField] private LayerMask walkableLayer;
    [SerializeField] private GameObject ground;
    [Space]
    [SerializeField] Transform infoBubble;

    private RaycastHit hitPoint;
    private Transform mainCamera;

    private TextMeshProUGUI infoText;

    private void Start()
    {
        mainCamera = Camera.main.transform;

        if(infoBubble != null)
        {
            infoText = GetComponentInChildren<TextMeshProUGUI>();
        }
    }

    private void Update()
    {
        GameObject hitObject;
        Ray outRay = new Ray(mainCamera.position, mainCamera.rotation *
             Vector3.forward);
        RaycastHit[] hits = Physics.RaycastAll(outRay, walkableLayer);
        
            for (int i = 0; i < hits.Length; i++)
            {
                RaycastHit hit = hits[i];
                hitObject = hit.collider.gameObject;
                if (hitObject == ground)
            {
                if (infoBubble != null)
                {
                    infoText.text = "X:" + hit.point.x.ToString("F2") +
                                    ", " +
                                    "Z:" + hit.point.z.ToString("F2");

                    infoBubble.LookAt(mainCamera.position);
                    infoBubble.Rotate(0, 180f, 0);
                }
                transform.position = hit.point;
                }
            }
        
    }
}
