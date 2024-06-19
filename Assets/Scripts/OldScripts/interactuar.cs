using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interactuar : MonoBehaviour
{
    public puntos puntaje;
    void Start()
    {
        puntaje = GameObject.FindGameObjectWithTag("Player").GetComponent<puntos>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            puntaje.cantidad = puntaje.cantidad + 1;
            Destroy(gameObject);
        }
    }
}
