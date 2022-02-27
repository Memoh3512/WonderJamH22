using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventDeck
{
    CardEvent cEvent;
    private List<CardEvent> eventList;

    public EventDeck()
    {
        eventList = new List<CardEvent>();
        eventList.Add(new AlienSeries1());
        eventList.Add(new WarCounselor(1, -10));
        eventList.Add(new HugeEgg());
        eventList.Add(new Waiter());
        eventList.Add(new Meteorite1());
        eventList.Add(new Classes1());
        eventList.Add(new Communist1());
        eventList.Add(new Pigeon());
        eventList.Add(new Deserters());
        eventList.Add(new Drug());
    }

    public CardEvent getEvent()
    {
        int totalWeight = 0;
        foreach(CardEvent c in eventList)
        {
            totalWeight += c.Weight;
        }

        int eventChosen = Random.Range(0, totalWeight-1);
        totalWeight = 0;
        foreach (CardEvent c in eventList)
        {
            totalWeight += c.Weight;
            if(totalWeight > eventChosen)
            {
                cEvent = c;
                break;
            }
        }
        eventList.Remove(cEvent);
        return cEvent;


    }

    public void addEvent(CardEvent ce)
    {
        eventList.Add(ce);
    }

    public void removeEvent(CardEvent ce)
    {
        eventList.Remove(ce);
    }
  
    public int Count()
    {
        return eventList.Count;
    }
}
