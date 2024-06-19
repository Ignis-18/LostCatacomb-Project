using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class Player : MonoBehaviour
{
    CharacterController characterController;
    [Header("Opciones de personaje")]
    public float walkSpeed = 6.0f;
    public float runSpeed = 10.0f;
    public float gravity = 20.0f;
    public bool canMove = true;
    public int torchDurability;
    public int torchDurabilityMax = 50;
    public bool canRecharge = true;
    public int sanity;
    public int sanityMax = 60;
    public GameObject torch;
    public GameObject sanityBarObject;
    public GameObject torchBarObject;
    public Slider sanityBar;
    public Slider torchBar;

    [Header("Opciones de camara")]
    public Camera cam;
    public float mouseHorizontal = 3.0f;
    public float mouseVertical = 2.0f;

    public float minRotation = -65.0f;
    public float maxRotation = 60.0f;
    float h_mouse, v_mouse;

    [Header("Manejo de objetos")]
    public bool looking = false;
    public int ItemAmount = 0;

    [Header("Introduccion y mapa")]
    public GameObject Nota;
    public GameObject Mapa;

    private Vector3 move = Vector3.zero;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        canMove = false;
        torchDurability = torchDurabilityMax;
        sanity = sanityMax;
        sanityBar.maxValue = sanityMax;
        torchBar.maxValue = torchDurabilityMax;
    }

    void Update()
    {
        /*sanityBar.value = sanity;
        torchBar.value = torchDurability;*/
        
        if(Nota.activeSelf == true)
        {
            if(Input.GetMouseButtonDown(0))
            {
                Nota.SetActive(false);
                canMove = true;
                sanityBarObject.SetActive(true);
                torchBarObject.SetActive(true);
            }
        }
        
        if(canMove)
        {
            sanityBarObject.SetActive(true);
            torchBarObject.SetActive(true);

            h_mouse = mouseHorizontal * Input.GetAxis("Mouse X");
            v_mouse += mouseVertical * Input.GetAxis("Mouse Y");
            v_mouse = Mathf.Clamp(v_mouse, minRotation, maxRotation);

            cam.transform.localEulerAngles = new Vector3(-v_mouse, 0, 0);
            transform.Rotate(0, h_mouse, 0);

            if (characterController.isGrounded)
            {
                move = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));

                if (Input.GetKey(KeyCode.LeftShift))
                    move = transform.TransformDirection(move) * runSpeed;

                else
                    move = transform.TransformDirection(move) * walkSpeed;

            }

            move.y -= gravity * Time.deltaTime;
            characterController.Move(move * Time.deltaTime);

            if(Input.GetKeyDown("m"))
            {
                Mapa.SetActive(true);
            }

            if(Input.GetKeyUp("m"))
            {
                Mapa.SetActive(false);
            }

            if(Input.GetKeyDown("c") && canRecharge)
            {
                torch.SetActive(true);
                canRecharge = false;
                torchDurability = torchDurabilityMax;
                StartCoroutine(Cooldown());
            }

            if(Input.GetKeyDown("escape"))
            {
                Application.Quit();
            }

            if(sanity <= 0)
            {
                SceneManager.LoadScene("Menu");
            }
        }        

    }

    IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(60);
        canRecharge = true;
    }

    /*IEnumerator sanityTick()
    {
        while(canMove)
        {
            yield return new WaitForSeconds(1);
            Debug.Log("sanity working");

            if (torch.activeSelf == false)
            {
                sanity--;
            }

            if (torch.activeSelf == true && sanity < sanityMax)
            {
                sanity++;
            }
        }
        
    }

    IEnumerator torchTick()
    {
        
        while(canMove)
        {
            yield return new WaitForSeconds(1);
            Debug.Log("torch working");

            if (torchDurability > 0)
            {
                torchDurability--;
            }

            if (torchDurability <= 0)
            {
                torch.SetActive(false);
            }
        }
        
    }*/

}
