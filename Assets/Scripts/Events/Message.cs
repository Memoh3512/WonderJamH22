using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Message : CardEvent
{
  public Message(string title, string description, string buttonDescription)
    {
        this.Name = title;
        this.Description = description;
        getChoices.Add(new Choice(0, 0, 0, buttonDescription, () => { return false;}));
    }

    public Message(string title, string description, string buttonDescription, Choice.ChooseEventHandler onChoose)
    {
        this.Name = title;
        this.Description = description;
        getChoices.Add(new Choice(0, 0, 0, buttonDescription, onChoose));
    }

}
