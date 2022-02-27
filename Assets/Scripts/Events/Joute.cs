using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Joute: CardEvent
{
    public Joute()
    {
 
    }



    public override void drawEvent()
    {

        Name = "Joust";
        int bet = Random.Range(30, 51);
        Description = "To determine which one is the best, the knights decided to set up a joust. They will be facing each other, trying to push their opponent off their horse. According to you, for " + bet.ToString() + " bucks, who is going to win? If you guess right, you make five times the bet.";
        if (GameManager.playerKingdom.Gold >= bet)
        {
            getChoices.Add(new Choice(0, 0, 0, "Arthur", () =>
            {
                bool win = Random.Range(1, 101) <= 25;
                string not = "not ";
                string dot = "...";
                if (win)
                {
                    not = "";
                    dot = "Great!";
                }
                GameManager.AddEventForToday(new Message("Joust result", "And the victor was... " + not + "Arthur", dot, () =>
                {
                    if (win)
                    {
                        GameManager.playerKingdom.removeGold(-5 * bet);
                    }
                    return false;
                }));
                GameManager.addEvent(new Joute());
                return false;
            }));

            getChoices.Add(new Choice(0, 0, 0, "Lancelot", () =>
            {
                bool win = Random.Range(1, 101) <= 25;
                string not = "not ";
                string dot = "...";
                if (win)
                {
                    not = "";
                    dot = "Great!";
                }
                GameManager.AddEventForToday(new Message("Joust result", "And the victor was... " + not + "Lancelot", dot, () =>
                {
                    if (win)
                    {
                        GameManager.playerKingdom.removeGold(-5 * bet);
                    }
                    return false;
                }));
                GameManager.addEvent(new Joute());
                return false;
            }));
            getChoices.Add(new Choice(0, 0, 0, "Bob", () =>
            {
                bool win = Random.Range(1, 101) <= 25;
                string not = "not ";
                string dot = "...";
                if (win)
                {
                    not = "";
                    dot = "Great!";
                }
                GameManager.AddEventForToday(new Message("Joust result", "And the victor was... " + not + "Bob", dot, () =>
                {
                    if (win)
                    {
                        GameManager.playerKingdom.removeGold(-5 * bet);
                    }
                    return false;
                }));
                GameManager.addEvent(new Joute());
                return false;
            }));
            getChoices.Add(new Choice(0, 0, 0, "Percival", () =>
            {
                bool win = Random.Range(1, 101) <= 25;
                string not = "not ";
                string dot = "...";
                if (win)
                {
                    not = "";
                    dot = "Great!";
                }
                GameManager.AddEventForToday(new Message("Joust result", "And the victor was... " + not + "Percival", dot, () =>
                {
                    if (win)
                    {
                        GameManager.playerKingdom.removeGold(-5 * bet);
                    }
                    return false;
                }));
                GameManager.addEvent(new Joute());
                return false;
            }));
        }
        else
        {
            getChoices.Add(new Choice(0, 0, 0, "Don't bet", () => { return false; }));
        }
        base.drawEvent();
    }
}
