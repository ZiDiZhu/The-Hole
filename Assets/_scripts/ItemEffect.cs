using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemEffect : MonoBehaviour
{

    public GameManager gm;
    public Player player;
    public Roommate roommate;

    public Button eatVitamins;
    public Text pillslefttxt;
    public Button eatCorpseBtn;

    public int vitaminsLeft = 10;

    public int[] foodVar;
    /*0: 0food (best);
     1: 1food 
     2: 2food 
     3: sleep
     4: fresh corpse
     5: rotten corpse
     6: talk
     7: vitamins
     8: read
     9: murder*/

    public int[] healthVar;
    //same as above
    public int[] sanVar;
    //same as above

    void Start()
    {

    }

    
    void Update()
    {
        
    }

    public void EatVitamins()
    {
        if(vitaminsLeft >= 1)
        {
            player.healthLevel += healthVar[7];
            player.foodLevel += foodVar[7];
            vitaminsLeft -= 1;
            pillslefttxt.text = "pills left: " + vitaminsLeft;
            player.CheckHunger();
            roommate.foodLevel -= 10;
            gm.dayPhase += 1;
            gm.UpdateEnvironment();
            roommate.CheckStats();
        }
        else
        {
            Debug.Log("no more pills left");
            eatVitamins.interactable = false;
        }
    }

    public void ReadBook()
    {
        player.foodLevel -= 10;
        player.sanityLevel += 30;
        player.CheckHunger();
        roommate.foodLevel -= 10;
        gm.dayPhase += 1;
        gm.UpdateEnvironment();
        roommate.CheckStats();
    }

    public void PlayWithDog()
    {
        player.foodLevel -= 20;
        player.sanityLevel += 30;
        player.CheckHunger();
        roommate.foodLevel -= 10;
        gm.dayPhase += 1;
        gm.UpdateEnvironment();
        roommate.CheckStats();
    }

    public void UseKnife()
    {
        roommate.Killed();
        player.healthLevel += healthVar[8];
        player.sanityLevel += sanVar[8];
        player.CheckHunger();
        eatCorpseBtn.interactable = true;
    }

}
