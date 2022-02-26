using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventDeck
{
    CardEvent cEvent;
    private List<CardEvent> eventList;

    public EventDeck(List<CardEvent> eventList)
    {
        this.eventList = eventList;
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
            }
        }

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
  
}
