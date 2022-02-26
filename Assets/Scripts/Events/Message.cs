using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Message : CardEvent
{
  public Message(string title, string description, string buttonDescription)
    {
        this.Name = title;
        this.Description = description;
        getChoices.Add(new Choice(0, 0, 0, buttonDescription, new List<CardEvent>(), () => { return false;}));
    }
}
