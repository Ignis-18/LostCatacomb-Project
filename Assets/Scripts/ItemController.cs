using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    public Player Player;
    public GameObject playerg, Item, Canvas, Black, Mapa, sanityBar, torchBar;
    public Animator Animator;
    public AudioSource Audio1, Audio2, Fondo1, Fondo2;
    public AudioClip Clip1, Clip2;
    public Transform player, destination, trigger;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Player.looking && Mapa.activeSelf == false)
        {
            if (Input.GetKeyDown("f"))
            {
                sanityBar.SetActive(false);
                torchBar.SetActive(false);
                Fondo1.Stop();
                Fondo2.Stop();
                Audio1.clip = Clip1;
                Audio2.clip = Clip2;
                if(player.position == trigger.position)
                {
                    Item.SetActive(false);
                }                
                Player.canMove = false;
                playerg.SetActive(false);
                player.position = destination.position;
                playerg.SetActive(true);
                Canvas.SetActive(false);
                Black.SetActive(true);
                if(Player.ItemAmount == 0)
                {
                    Audio1.Play();
                    StartCoroutine(WaitAudio(Clip1));
                }
                else
                {
                    Audio2.Play();
                    StartCoroutine(WaitAudio(Clip2));
                }              
            }
        }
    }

    IEnumerator WaitAudio(AudioClip clip)
    {
        Debug.Log("launch coroutine");
        yield return new WaitForSeconds(clip.length);
        Player.ItemAmount++;
        Animator.SetBool("PickUp", true);
    }
}
