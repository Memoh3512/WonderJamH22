using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager
{
    public static Kingdom playerKingdom;
    public static List<Kingdom> aiKingdoms;
    public static int day = 1;
    private static EventDeck currentDeck;
    private static List<CardEvent> queudEvents;

    private static List<CardEvent> todaysEventsToPlay;

    public static void nextDay()
    {
        day++;
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
            cardEvent.removeDays(1);
            if (cardEvent.DaysToPlay <= 0)
            {
                todaysEventsToPlay.Add(cardEvent);
                queudEvents.Remove(cardEvent);
            }
        }
        // Random nombre d'events 
        for (int i = Random.Range(0, 3); i < 3; i++)
        {
            todaysEventsToPlay.Add(currentDeck.getEvent());
        }
        playNextEvent();
    }
    public static void playNextEvent()
    {
        if (todaysEventsToPlay.Count > 0)
        {
            todaysEventsToPlay[0].drawEvent();
            todaysEventsToPlay.RemoveAt(0);
        }
        else
        {
            drawNextDay();
        }
        
    }
    public static void drawNextDay()
    {
        //TODO draw le bouton dans le bas
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
