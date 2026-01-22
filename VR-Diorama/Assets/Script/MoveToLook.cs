using UnityEngine;

public class MoveToLook : MonoBehaviour
{
    [SerializeField] private LayerMask walkableLayer;
    [SerializeField] private GameObject ground;
    private RaycastHit hitPoint;
    private Transform mainCamera;

    private void Start()
    {
        mainCamera = Camera.main.transform;
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
                    Debug.Log("Hit (x,y,z): " + hit.point.ToString("F2"));
                    transform.position = hit.point;
                }
            }
        
    }
}
