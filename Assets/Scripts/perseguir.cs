using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class perseguir : MonoBehaviour
{
    public float velocidad = 0.75f;
    public float minDist = 1f;
    public Transform target;

    void Start()
    {
        if (target == null)
        {
            if (GameObject.FindWithTag("Player") != null)
            {
                target = GameObject.FindWithTag("Player").GetComponent<Transform>();
            }
        }
    }

    void Update()
    {
        if (target == null)
            return;
        transform.LookAt(target);
        float distance = Vector3.Distance(transform.position, target.position);
        if (distance > minDist)
            transform.position += transform.forward * velocidad * Time.deltaTime;
    }

}

