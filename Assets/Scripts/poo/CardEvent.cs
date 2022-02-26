using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardEvent 
{
    private List<Choice> choices = new List<Choice>();
    private int daysToPlay;
    private int weight;
    private string name = "Card Event";
    private string description = "This is a default card event description. Have fun debugging!";
    
    
    public int DaysToPlay { get => daysToPlay; private set => daysToPlay=value; }
    public int Weight { get => weight; set => weight = value; }
    public string Name { get => name; set => name = value; }
    public string Description { get => description; set => description = value; }
    
    public int getNbChoices => choices?.Count ?? 0;
    public List<Choice> getChoices => choices;

    public CardEvent()
    {
        daysToPlay = -10;
        Weight = 1;
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

        GameObject ui = GameObject.FindGameObjectWithTag("Canvas");
        GameObject card = Object.Instantiate(Resources.Load<GameObject>("CardDisplay"), ui.transform);
        card.GetComponent<CardDisplay>().SetCardEvent(this);
        ui.GetComponent<RectTransform>().position = Vector3.zero;

    }
}
