using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

[RequireComponent(typeof(AudioSource))]
public class ActionEffect : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip hover1;
    public AudioClip click2;

    public Player player;
    public Roommate roommate;
    public GameManager gm;
    public ItemEffect item;

    public GameObject[] ui;
    //0-healthup 1-foodup 2-sanUp 3-healthdown 4-hungerDown 5-sandown

    public Text healthVar;
    public Text foodVar;
    public Text sanVar;
    public Text log;
    void Start()
    {
        disableEffect();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        
    }

    public void confirmSFX()
    {
        audioSource.PlayOneShot(click2);
    }

    public void food()
    {
        audioSource.PlayOneShot(hover1);
        if (gm.dayPhase == 2)
        {
            if (gm.foodNum == 0)
            {
                log.text = "A luxurious feast, barely touched!";
                ui[0].gameObject.SetActive(true);
                ui[1].gameObject.SetActive(true);
                ui[2].gameObject.SetActive(true);
                foodVar.text = "+ " + item.foodVar[0];
                healthVar.text = "+ " + item.healthVar[0];
                sanVar.text = "+ " + item.sanVar[0];
            }
            else if (gm.foodNum == 1)
            {
                ui[0].gameObject.SetActive(true);
                ui[1].gameObject.SetActive(true);
                ui[5].gameObject.SetActive(true);
                foodVar.text = "+ " + item.foodVar[1];
                healthVar.text = "+ " + item.healthVar[1];
                sanVar.text = " " + item.sanVar[1];
                log.text = "Leftovers of a luxurious feast... kind of gross but it'll fill you up.";
            }
            else if (gm.foodNum == 2)
            {
                ui[1].gameObject.SetActive(true);
                ui[5].gameObject.SetActive(true);
                foodVar.text = "+ " + item.foodVar[2];
                healthVar.text = " " + item.healthVar[2];
                sanVar.text = " " + item.sanVar[2];
                log.text = "Crumbs and residues of food.. disgusting, you thought.";
            }
        }
        else
        {
            log.text = "food will be here at noon.";
        }
    }

    public void talkEffect()
    {
        audioSource.PlayOneShot(hover1);
        if (roommate.isAlive)
        {
            ui[2].gameObject.SetActive(true);
            ui[4].gameObject.SetActive(true);
            foodVar.text = " " + item.foodVar[6];
            sanVar.text = "+ " + item.sanVar[6];
            healthVar.text = "+ " + item.healthVar[6];
            log.text = "you don't really like this stranger but..maybe it's a good idea to befriend them?";
        }else if (!roommate.isAlive)
        {
            if (!roommate.isRotten)
            {
                ui[0].gameObject.SetActive(true);
                ui[1].gameObject.SetActive(true);
                ui[5].gameObject.SetActive(true);
                foodVar.text = "+ " + item.foodVar[4];
                sanVar.text = " " + item.sanVar[4];
                healthVar.text = "+ " + item.healthVar[4];
                log.text = "the corpse is still fresh";
            }else if (roommate.isRotten)
            {
                ui[1].gameObject.SetActive(true);
                ui[3].gameObject.SetActive(true);
                ui[5].gameObject.SetActive(true);
                foodVar.text = "+ " + item.foodVar[5];
                sanVar.text = " " + item.sanVar[5];
                healthVar.text = " " + item.healthVar[5];
                log.text = "the corpse is decomposing";
            }
        }
    }

    public void sleepEffect()
    {
        audioSource.PlayOneShot(hover1);
        log.text = "Sleep..because there ain't much to do here";
        ui[4].gameObject.SetActive(true);
        foodVar.text = " " + item.foodVar[3];
        healthVar.text = " " + item.healthVar[3];
        sanVar.text = " " + item.sanVar[3];
    }

    public void vitamin()
    {
        audioSource.PlayOneShot(hover1);
        if (item.vitaminsLeft >=1)
        {
            log.text = "multi-vitamins! 'nutritional supplements, cannot substitute food', says the label";
            ui[0].gameObject.SetActive(true);
            ui[4].gameObject.SetActive(true);
            foodVar.text = " " + item.foodVar[7];
            healthVar.text = "+ " + item.healthVar[7];
            sanVar.text = " " + item.sanVar[7];
        }
        else
        {
            log.text = "there's no more left";
        }
    }

    public void knife()
    {
        audioSource.PlayOneShot(hover1);
        if (gm.dayPhase == 3)
        {
            log.text = "..you chose the knife for a reason. Do it, it's for your survival.";
            ui[3].gameObject.SetActive(true);
            ui[5].gameObject.SetActive(true);
            foodVar.text = " " + item.foodVar[8];
            healthVar.text = " " + item.healthVar[8];
            sanVar.text = " " + item.sanVar[8];
        }
        else
        {
            log.text = "you should probably wait for your roommate to be asleep to do it";
        }
    }


    public void disableEffect()
    {
        for(int i = 0; i<ui.Length; i++)
        {
            ui[i].gameObject.SetActive(false);
        }
        log.text = "";
        foodVar.text = "";
        healthVar.text = "";
        sanVar.text = "";
    }


}
