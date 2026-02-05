using UnityEngine;

public class CursorPositioner : MonoBehaviour
{
    private float defaultPosZ;
    private Transform mainCamera;

    void Start()
    {
        mainCamera = Camera.main.transform;
        defaultPosZ = transform.localPosition.z;
    }

    void Update()
    {
        Ray ray = new Ray(mainCamera.position, mainCamera.rotation *
            Vector3.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.distance > defaultPosZ)
            {
                transform.localPosition = new Vector3(0, 0,
                    hit.distance * 0.95f);
            }
            else
            {
                transform.localPosition = new Vector3(0, 0,
                     defaultPosZ);
            }
        }
    }
}
