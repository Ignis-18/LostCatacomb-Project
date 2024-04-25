using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara : MonoBehaviour
{
    public GameObject jugador;
    private Vector3 offset;
    
    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - jugador.transform.position;
    }

    // Update is called once per frame
    private void LateUpdate(){
        transform.position = jugador.transform.position + offset;
    }
}
