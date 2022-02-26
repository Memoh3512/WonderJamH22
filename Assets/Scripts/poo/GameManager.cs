using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager
{
    public static Kingdom playerKingdom;
    public static List<Kingdom> aiKingdoms;
    private static int day = 0;
    private static EventDeck currentDeck;
    private static List<CardEvent> queudEvents;

    public static void nextDay()
    {
        day++;
        day--;
    }
    public static void startGame()
    {
        day = 1;
        //TODO reset decks/queud
        queudEvents = null;
    }
    public static void endGame()
    {
        
    }
    public static void addEvent(CardEvent cardEvent)
    {
        currentDeck.addEvent(cardEvent);
    }
    public static void playTodaysEvents()
    {
        foreach (var cardEvent in queudEvents)
        {
            //cardEvent.
        }
    }
    public static void getDeck()
    {
        
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
