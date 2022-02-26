using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager
{
    public static Kingdom playerKingdom;
    public static List<Kingdom> aiKingdoms;
    public static Kingdom fightOpponent;
    public static int day = 1;
    private static EventDeck currentDeck = new EventDeck(new List<CardEvent>());
    private static List<CardEvent> queudEvents = new List<CardEvent>();

    private static List<CardEvent> todaysEventsToPlay = new List<CardEvent>();

    public static bool firstPlay = true;

    public static void nextDay()
    {
        day++;
        foreach (var kingdom in aiKingdoms)
        {
            kingdom.next();
            Debug.Log(kingdom.Name + " | MP : " + kingdom.MilitaryPower);
        }
    }
    public static void startGame(string name)
    {
        // Resets kingdoms
        aiKingdoms = new List<Kingdom>()
        {
            new KingdomCowboy(),
            new KingdomFurry(),
            new KingdomPirate()
        };
        playerKingdom = new Kingdom();
        
        playerKingdom.Name = name;
        
        firstPlay = false;
        
        day = 1;
        
        //TODO reset decks/queud
        queudEvents.Clear();
        
        GameManager.AddEventForToday(new WarCounselor(1, 0));
        
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
            //todaysEventsToPlay.Add(currentDeck.getEvent());
        }
        playNextEvent();
    }
    public static void playNextEvent()
    {
        if (todaysEventsToPlay.Count > 0)
        {
            todaysEventsToPlay[0].drawEvent();
        }
        else
        {
            drawNextDay();
        }
        
    }

    public static void AddEventForToday(CardEvent e)
    {
        
        todaysEventsToPlay.Add(e);
        //test
        playTodaysEvents();
        
    }
    public static void drawNextDay()
    {
        //TODO draw le bouton dans le bas
    }

    public static void RemoveTodaysEvent(CardEvent e)
    {

        todaysEventsToPlay.Remove(e);

    }
    
    public static void getDeck()
    {
        
    }
}
