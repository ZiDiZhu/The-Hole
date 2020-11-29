using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemEffect : MonoBehaviour
{
    public GameManager gm;
    public Player player;
    public Roommate roommate;

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
        player.healthLevel += 20;
        player.foodLevel -= 5;
        player.sanityLevel += 5;
        player.CheckHunger();
        roommate.foodLevel -= 10;
        gm.dayPhase += 1;
        gm.UpdateEnvironment();
        roommate.CheckStats();
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
        player.healthLevel -= 40;
    }

}
