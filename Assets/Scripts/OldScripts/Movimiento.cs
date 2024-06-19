using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Movimiento : MonoBehaviour
{
    public float velocidad = 1f;
    public float rotacion = 1f;
    public float fuerzaSalto = 3f;
    public float contador=0;
    public float delayDamage = 0f;
    private Rigidbody rb;
    public Text puntos;
    public float vidaPlayer;
    public Text vida;
    
    
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = true;
        rb = GetComponent<Rigidbody>();
        puntos.text = "Puntos: 0";
        vidaPlayer = 5f;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        
        transform.Translate(new Vector3(horizontal, 0f, vertical) * Time.deltaTime * velocidad);
        
        float rotationY = Input.GetAxis("Mouse X");
        transform.Rotate(new Vector3(0f, rotationY, 0f));
        
        if(Input.GetKeyDown(KeyCode.Space)){
            rb.AddForce(new Vector3(0f, fuerzaSalto, 0f), ForceMode.Impulse);
        }

        vida.text = "Vida: " + vidaPlayer.ToString();
        
        if (delayDamage > 0)
        {
            delayDamage -= Time.deltaTime;
        }

        if (vidaPlayer <= 0)
        {
            Destroy(gameObject);
            SceneManager.LoadScene("Menu");
        }

        if (contador >= 4)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
    
    private void OnTriggerEnter(Collider other){
        if(other.gameObject.CompareTag("Coleccionable")){
            other.gameObject.SetActive(false);
            contador++;
            Debug.Log("Coleccionables recogidos: "+contador);
            puntos.text = "Puntos: "+contador.ToString();
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemigo"))
        {
            if (delayDamage <= 0)
            {
                delayDamage = 5f;
                vidaPlayer--;
                
            }
        }
    }
}