using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CardEvent 
{
    private List<Choice> choices = new List<Choice>();
    private int daysToPlay;
    private int weight;
    private string name = "Card Event";
    private string description = "This is a default card event description. Have fun debugging!";
    
    
    public int DaysToPlay { get => daysToPlay; set => daysToPlay=value; }
    public int Weight { get => weight; set => weight = value; }
    public string Name { get => name; set => name = value; }
    public string Description { get => description; set => description = value; }
    
    public int getNbChoices => choices?.Count ?? 0;
    public List<Choice> getChoices => choices;
    public void addChoice(Choice choice)
    {
        choices.Add(choice);
    }
    public CardEvent()
    {
        daysToPlay = -10;
        Weight = 1;
    }

    public void checkIfChoiceBuyable()
    {
        foreach (var choice in choices.ToList())
        {
            if (choice.MMoney > GameManager.playerKingdom.Gold || choice.MMilitaryPower > GameManager.playerKingdom.MilitaryPower)
            {
                choices.Remove(choice);
            }
        }
    }

    public void choose(int choix)
    {
        Choice choiceChosen = choices[choix];
        if(GameManager.playerKingdom.canBuy(choiceChosen.MMoney) && GameManager.playerKingdom.canMilitaryPower(choiceChosen.MMilitaryPower) && GameManager.playerKingdom.canKingdomlife(choiceChosen.MKingLife))
        {
            choiceChosen.process();
        }
    }
    public void removeDays(int days)
    {
        daysToPlay -= days;
    }
    
    public virtual void drawEvent()
    {
        //draw :) 

        GameObject c = GameObject.FindGameObjectWithTag("CardDisplay");
        if (c is null)
        {
            
            GameObject ui = GameObject.FindGameObjectWithTag("Canvas");
            c = Object.Instantiate(Resources.Load<GameObject>("CardDisplay"), ui.transform);
            ui.GetComponent<RectTransform>().position = Vector3.zero;   
            
        }
        else
        {
            
            Debug.Log("RESET ANIM");
            c.GetComponent<Animator>().SetTrigger("Update");

        }
        c.GetComponent<CardDisplay>().SetCardEvent(this);
        GameManager.RemoveTodaysEvent(this);

    }
}
