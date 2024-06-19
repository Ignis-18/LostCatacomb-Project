using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EliminaPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        //Si chocamos con un Player lo eliminamos a el.
        if (other.gameObject.tag == "Player")
        {
            
            Destroy(other.gameObject);
        }
       
    }
}
