using UnityEngine;

public class KeepUpright : MonoBehaviour
{
    [SerializeField] private float speed = 5f;

    private void Update()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.identity,
            Time.deltaTime * speed);
    }
}
