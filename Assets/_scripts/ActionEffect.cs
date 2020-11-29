using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionEffect : MonoBehaviour
{
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
    }

    void Update()
    {
        
    }

    public void food0()
    {
      if(gm.dayPhase == 2)
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
                log.text = "Leftovers of a luxurious feast... kind of gross but it'll fill you up.";
            }
            else if (gm.foodNum == 2)
            {
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
        Debug.Log("talkkkkkk");
        ui[2].gameObject.SetActive(true);
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
