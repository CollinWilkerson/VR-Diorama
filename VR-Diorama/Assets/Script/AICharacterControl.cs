using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class AICharacterControl : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float refreshRate = 0.5f;
    private NavMeshAgent agent;

    private void Start()
    {
        agent = gameObject.GetComponent<NavMeshAgent>();
        StartCoroutine(MoveToTarget());
    }

    private IEnumerator MoveToTarget()
    {
        while (true)
        {
            agent.SetDestination(target.position);
            yield return new WaitForSeconds(refreshRate);
        }
    }
}
