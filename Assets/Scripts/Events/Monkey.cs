using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monkey : CardEvent
{
    public Monkey()
    {
        
        Name = "Special monkeys";
        Description = "During his daily walk in the forest to get mushrooms, our Druid found these four weird-looking monkeys playing with balloons. They seems to be able to shoot things and have some kind of special powers. We only have space in the castle to pick one of them, which one should we take?";

        getChoices.Add(new Choice(0,0,0,"Dart Monkey",()=> {
            GameManager.AddEventForToday(new Message("Dart Monkey","This one is the weakest, only having a dart he doesn't do much damage. ","Fudge"));
           GameManager.playerKingdom.removeMilitaryPower(-1);
            GameManager.playerKingdom.Units.Add(new Unit(Resources.Load<Sprite>("Units/singe"), 10, 5, 1, 1));
            return false;
        }));

        getChoices.Add(new Choice(0,0,0,"Sniper monkey ",()=> {
            GameManager.AddEventForToday(new Message("Sniper monkey","The sniper hides in trees to shoot enemies, but he often gets tired and falls asleep...","Not bad"));
            GameManager.playerKingdom.removeMilitaryPower(-5);
            GameManager.playerKingdom.Units.Add(new Unit(Resources.Load<Sprite>("Units/singe"), 50, 25, 1.2f, 5));
            return false;
        }));
        getChoices.Add(new Choice(15,0,0,"Magician Monkey",()=> {
            GameManager.AddEventForToday(new Message("Magician Monkey","This one can ascend extremely big walls of fire on the ways of enemies so they shall not pass. ","Poggers"));
            GameManager.playerKingdom.removeMilitaryPower(-50);
            GameManager.playerKingdom.Units.Add(new Unit(Resources.Load<Sprite>("Units/singe"), 100, 25, 1, 20));
            return false;
        }));
        getChoices.Add(new Choice(0,0,0,"Trap Monkey",()=> {
            GameManager.AddEventForToday(new Message("Trap Monkey","The traps he sets along the paths of enemies have bananas as baits... even though it seems dumb, it actually works pretty well. Enemy soldiers are hungrier than we think.... ","Correct"));
            GameManager.playerKingdom.removeMilitaryPower(-30);
            GameManager.playerKingdom.Units.Add(new Unit(Resources.Load<Sprite>("Units/singe"), 75, 30, 1, 15));
            return false;
        }));
    }
}
