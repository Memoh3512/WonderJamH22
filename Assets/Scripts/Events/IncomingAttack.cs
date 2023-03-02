using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncomingAttack : CardEvent
{
    
    private Kingdom attacker;
    public IncomingAttack(Kingdom attacker)
    {
        Name = "Incoming Attack!";
        //kingdomToFight = GameManager.aiKingdoms[0];
        this.attacker = attacker;
        this.Weight = 0;
        
    }


    public override void drawEvent()
    {

        this.Description = "You have received a message from your army commander : \n" +
                           "\"Your excellency, the " + attacker.Name + " Kingdom is at our doors! We must defend our land or find a way to make peace, quick!";
       
        Object.FindObjectOfType<Parallax>().TransitionTo(new List<Sprite>()
        {

            Resources.Load<Sprite>("Parallax/fire1"),
            Resources.Load<Sprite>("Parallax/fire2"),
            Resources.Load<Sprite>("Parallax/fire3")

        });
        
        
        Choice choice1 = new Choice(0, 0, 0, "ALATAK!", () => {
            GameManager.fightOpponent = attacker;
            
            //STARTO FIGHTO
            return true;
        });
        getChoices.Add(choice1);
        getChoices.Add(new Choice(40, 0, 0, "I'll try to pay my way to peace...", () =>
        {
            if (Random.Range(0f, 1f) <= 0.5f)
            {
                
                GameManager.AddEventForToday(new Message("Peace at a cost", "You give a hefty sum of money to the " + attacker.Name + " Kingdom, and they decide to leave you alone... for now.", "That was a close one."));
                Object.FindObjectOfType<Parallax>().TransitionTo(new List<Sprite>()
                {

                    Resources.Load<Sprite>("Parallax/Day1"),
                    Resources.Load<Sprite>("Parallax/Day2"),
                    Resources.Load<Sprite>("Parallax/Day3")

                });
                return false;
            }
            else
            {
                
                GameManager.AddEventForToday(new Message("Failure", "The " + attacker.Name + " Kingdom is really mad at you for even suggesting that option, and they start to advance their troops. Get your weapons ready!", "ALATAK!!!",
                    () =>
                    {
                        GameManager.fightOpponent = attacker;
                        
                        return true;
                    }));
                return false;
            }
        }));
        base.drawEvent();
    }
    
}
