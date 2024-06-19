using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeInController : MonoBehaviour

{
    public Player Player;
    public AudioSource Fondo1, Fondo2;
    public GameObject Black;
    public Animator Animator;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void AnimEnd()
    {
        Player.canMove = true;
        Animator.SetBool("PickUp", false);
        Fondo1.Play();
        Fondo2.Play();
        Black.SetActive(false);
        
    }
}
