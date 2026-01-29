using UnityEngine;

public class poppable : MonoBehaviour
{
    public GameObject popEffectPrefab;

    private void OnCollisionEnter(Collision collision)
    {
        //pop after release if this object collides with anything that is not poppable
        if(transform.parent == null && collision.gameObject.GetComponent<poppable>() == null)
        {
            PopBalloon();
        }
    }

    private void PopBalloon()
    {
        if(popEffectPrefab != null)
        {
            GameObject effect = Instantiate(popEffectPrefab, transform.position, transform.rotation);
            Destroy(effect, 1f);
        }
        Destroy(gameObject);
    }
}
