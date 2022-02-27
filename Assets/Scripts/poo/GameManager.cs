using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;

public class GameManager
{
    public static Kingdom playerKingdom;
    public static List<Kingdom> aiKingdoms;
    public static Kingdom fightOpponent;
    public static int day = 1;
    public static string deathNote = "None";
    private static EventDeck currentDeck = new EventDeck();
    private static List<CardEvent> queudEvents = new List<CardEvent>();

    private static List<CardEvent> todaysEventsToPlay = new List<CardEvent>();

    public static bool firstPlay = true;

    public static async void nextDay()
    {
        day++;
        foreach (var kingdom in aiKingdoms)
        {
            kingdom.next();
            Debug.Log(kingdom.Name + " | MP : " + kingdom.MilitaryPower);
            
            if (kingdom.Relation == 1)
            {
                playerKingdom.removeGold(-10);
            }
        }
        
        Object.FindObjectOfType<Parallax>().TransitionTo(new List<Sprite>()
        {

            Resources.Load<Sprite>("Parallax/Day1"),
            Resources.Load<Sprite>("Parallax/Day2"),
            Resources.Load<Sprite>("Parallax/Day3")

        });

        await Task.Delay(1500);
        
        CanvasGroup endDay = GameObject.FindGameObjectWithTag("EndDay").GetComponent<CanvasGroup>();
        endDay.alpha = 0;
        endDay.interactable = false;
        endDay.blocksRaycasts = false;
        
        Debug.Log("TODAYEVENT DAY2");
        Object.FindObjectOfType<GameUI>().UpdateUIValues();
        CardDisplay c = Object.FindObjectOfType<CardDisplay>();
        if (c != null) MonoBehaviour.Destroy(c.gameObject);
        await Task.Delay(100);
        playTodaysEvents();
        
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
        playerKingdom = new Kingdom(Resources.Load<Sprite>("Icon/Human"),true);
        
        playerKingdom.Name = name;
        
        firstPlay = false;
        
        day = 1;
        
        Object.FindObjectOfType<GameUI>().UpdateUIValues();
        
        
        //TODO reset decks/queud
        queudEvents.Clear();
        
        playTodaysEvents();
        
        //GameManager.AddEventForToday(new WarCounselor(1, 0));
        
    }
    public static void endGame()
    {
        
    }
    public static bool addCardIfRandom(float pourcentageDeChance,CardEvent happenned = null,CardEvent didntHappen = null)
    {
        bool playedRandom = Random.Range(0f, 100f) < pourcentageDeChance;

        if (playedRandom && happenned != null)
        {
            addPlannedEvent(happenned);
        }else if (!playedRandom && didntHappen != null)
        {
            addPlannedEvent(didntHappen);
        }

        return playedRandom;
    }

    public static void addPlannedEvent(CardEvent cardEvent)
    {
        if (cardEvent.DaysToPlay>0)
        {
            queudEvents.Add(cardEvent);
        }
        else
        {
            AddEventForToday(cardEvent);
        }
        
    }
    public static void addEvent(CardEvent cardEvent)
    {
        currentDeck.addEvent(cardEvent);
    }
    public static void playTodaysEvents()
    {
        foreach (var cardEvent in queudEvents.ToList())
        {
            cardEvent.removeDays(1);
            if (cardEvent.DaysToPlay <= 0)
            {
                todaysEventsToPlay.Add(cardEvent);
                queudEvents.Remove(cardEvent);
            }
        }
        // Random nombre d'events 
        for (int i = Random.Range(1, 3); i < 3; i++)
        {
            if(currentDeck.Count() > 0)
            {
                todaysEventsToPlay.Add(currentDeck.getEvent());
            }
            else
            {
                if (todaysEventsToPlay.Count == 0)
                {
                    Debug.Log("DECK EMPTY!!!! AND TODAYS EVENTS");
                    todaysEventsToPlay.Add(new Message("An uneventful day", "Today, nothing happened. The weather was good, the people were happy. All was well!", "That's all fine and dandy!"));
                }
            }
           
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
        
        todaysEventsToPlay.Insert(0,e);
        //test
        //playTodaysEvents();
        
    }
    public static void drawNextDay()
    {
        //TODO draw le bouton dans le bas et bybye scroll
        CardDisplay c = Object.FindObjectOfType<CardDisplay>();
        if (c != null)
        {
            
            c.DeleteButtons();
            c.SetCardEvent(null);
            c.GetComponent<Animator>().SetTrigger("Bebye");   
            
        }
        CanvasGroup endDay = GameObject.FindGameObjectWithTag("EndDay").GetComponent<CanvasGroup>();
        endDay.alpha = 1;
        endDay.interactable = true;
        endDay.blocksRaycasts = true;
        
        //start transition to moon
        Object.FindObjectOfType<Parallax>().TransitionTo(new List<Sprite>()
        {

            Resources.Load<Sprite>("Parallax/Night1"),
            Resources.Load<Sprite>("Parallax/Night2"),
            Resources.Load<Sprite>("Parallax/Night3")

        });

    }

    public static void RemoveTodaysEvent(CardEvent e)
    {

        todaysEventsToPlay.Remove(e);

    }
    
    public static void getDeck()
    {
        
    }
}
