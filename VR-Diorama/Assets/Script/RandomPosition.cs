using UnityEngine;
using System.Collections;
public class RandomPosition : MonoBehaviour
{
    [SerializeField] private float roamRange = 20;
    [SerializeField] private float refreshRate = 0.5f;
    private void Start()
    {
        StartCoroutine(MoveToRandomPosition());
    }

    public IEnumerator MoveToRandomPosition()
    {
        while (true)
        {
            transform.position = Vector3.Scale(Random.insideUnitSphere, new Vector3(1, 0, 1)) * roamRange;
            yield return new WaitForSeconds(refreshRate);
        }
    }
}
