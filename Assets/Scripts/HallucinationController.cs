using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HallucinationController : MonoBehaviour
{
    public Player Player;
    /*public GameObject Black;
    public Animator Animator;
    public AudioSource Audio;
    public AudioClip Clip;*/
    public GameObject Humanoide, Plr, Mapa, sanityBar, torchBar;
    public Transform Target;

    // Start is called before the first frame update
    void Start()
    {
        /*Audio.clip = Clip;*/
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Mapa.SetActive(false);
            sanityBar.SetActive(false);
            torchBar.SetActive(false);
            Player.canMove = false;
            Plr.transform.LookAt(Target);
            Humanoide.SetActive(true);
            /*Audio.Play();
            Debug.Log(Audio.isPlaying);
            StartCoroutine(WaitAudio(Clip));*/
        }
    }

    /*IEnumerator WaitAudio(AudioClip clip)
    {
        Debug.Log("launch coroutine");
        yield return new WaitForSeconds(clip.length);
        Animator.SetBool("PickUp", true);
    }*/
}
