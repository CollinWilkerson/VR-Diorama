using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillTarget : MonoBehaviour
{
    [SerializeField] private GameObject target;
    [SerializeField] private ParticleSystem hitEffect;
    [SerializeField] private GameObject killEffect;
    [SerializeField] private float timeToSelect = 3.0f;
    public int score;

    Transform mainCamera;
    private float countDown;

    void Start()
    {
        mainCamera = Camera.main.transform;
        score = 0;
        countDown = timeToSelect;
    }

    void Update()
    {
        bool isHitting = false;
        Ray ray = new Ray(mainCamera.position, mainCamera.rotation *
            Vector3.forward);
        RaycastHit hit;

        //determins if the target object is being hit by the ray (layermasks might be a better approach to this)
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.gameObject == target)
            {
                isHitting = true;
            }
        }

        //If we are hitting the target start counting down their health or kill them
        if (isHitting)
        {
            if (countDown > 0.0f)
            {
                // on target 
                countDown -= Time.deltaTime;
                // print (countDown); 
                hitEffect.transform.position = hit.point;
                if (hitEffect.isStopped)
                {
                    hitEffect.Play();
                }
            }
            else
            {
                // killed 
                Instantiate(killEffect, target.transform.position,
                   target.transform.rotation);
                score += 1;
                countDown = timeToSelect;
                SetRandomPosition();
            }
        }
        //if we are not hitting we restart the timer
        else
        {
            // reset 
            countDown = timeToSelect;
            hitEffect.Stop();
        }
    }
    void SetRandomPosition()
    {
        float x = Random.Range(-5.0f, 5.0f);
        float z = Random.Range(-5.0f, 5.0f);
        target.transform.position = new Vector3(x, 0.0f, z);
    }
}
