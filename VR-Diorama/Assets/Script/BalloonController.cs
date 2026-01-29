using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;
using UnityEngine.XR;
using System;

public class BalloonController : MonoBehaviour
{
    [SerializeField] private GameObject balloonPrefab;
    [SerializeField] private float floatStrength = 20f;
    [SerializeField] private float growRate = 1.5f;
    private GameObject balloon;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //code substitute for drag and drop
        //InputController.RightTriggerDownEvent.AddListener(CreateBalloon);
        //InputController.RightTriggerUpEvent.AddListener(ReleaseBalloon);
    }

    // Update is called once per frame
    void Update()
    {
        if(balloon != null)
        {
            GrowBalloon();
        }
    }

    private void GrowBalloon()
    {
        //balloon will grow faster as it gets larger
        float growThisFrame = growRate * Time.deltaTime;
        Vector3 changeScale = balloon.transform.localScale * growThisFrame;
        balloon.transform.localScale += changeScale;
    }

    public void CreateBalloon(Transform parentHand)
    {
        balloon = Instantiate(balloonPrefab, parentHand);
        balloon.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
    }

    public void ReleaseBalloon()
    {
        balloon.transform.parent = null;
        Rigidbody rb = balloon.GetComponent<Rigidbody>();
        Vector3 force = Vector3.up * floatStrength;
        rb.AddForce(force);

        GameObject.Destroy(balloon, 10f);
        balloon = null;
    }
}
