using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventDeck
{
    CardEvent cEvent;
    private List<CardEvent> eventList;

    public List<CardEvent> EventList()
    {
        return eventList;
    }
    
    public EventDeck()
    {
        eventList = new List<CardEvent>();
        ResetEventList();

    }

    public void ResetEventList()
    {
        
        eventList.Clear();
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
        eventList.Add(new Carnaval());
        eventList.Add(new HorseRace());
        eventList.Add(new Gardener());
        eventList.Add(new Monkey());
        eventList.Add(new Hair());
        eventList.Add(new Dragon());
        eventList.Add(new Joute());
        eventList.Add(new Fishing());
        eventList.Add(new Trees());
        eventList.Add(new MilitaryOffers());
        eventList.Add(new Author());
        eventList.Add(new Fossils());
        
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
