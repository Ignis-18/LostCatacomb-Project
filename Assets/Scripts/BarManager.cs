using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarManager : MonoBehaviour
{
    public Player Player;
    public GameObject sanityBarObject;
    public GameObject torchBarObject;
    public Slider sanityBar;
    public Slider torchBar;


    // Start is called before the first frame update
    void Start()
    {
        Player.torchDurability = Player.torchDurabilityMax;
        Player.sanity = Player.sanityMax;
        sanityBar.maxValue = Player.sanityMax;
        torchBar.maxValue = Player.torchDurabilityMax;
        StartCoroutine(sanityTick());
        StartCoroutine(torchTick());
    }

    // Update is called once per frame
    void Update()
    {
        sanityBar.value = Player.sanity;
        torchBar.value = Player.torchDurability;
    }

    IEnumerator sanityTick()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            Debug.Log("sanity working");

            if (Player.torch.activeSelf == false)
            {
                Player.sanity--;
            }

            if (Player.torch.activeSelf == true && Player.sanity < Player.sanityMax)
            {
                Player.sanity++;
            }
        }

    }

    IEnumerator torchTick()
    {

        while (true)
        {
            yield return new WaitForSeconds(1);
            Debug.Log("torch working");

            if (Player.torchDurability > 0)
            {
                Player.torchDurability--;
            }

            if (Player.torchDurability <= 0)
            {
                Player.torch.SetActive(false);
            }
        }

    }
}
