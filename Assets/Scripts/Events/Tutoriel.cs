using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutoriel : CardEvent
{
    public Tutoriel()
    {
        
        Name = "How to play";
        Description = " Here you will find various events that you will have to choose on, and make difficult decisions to rule your land. Are you up for it?";

        getChoices.Add(new Choice(0,0,0,"Hell yea!",()=> {
            GameManager.AddEventForToday(new Message("Contact accepted","Prepare yourself, you have a kingdom to manage.","I'm ready!"));
            return false;
        }));

        getChoices.Add(new Choice(0,0,0,"No, get me out!",()=> {
            GameManager.AddEventForToday(new Message("Out","Okay, have a great day sir!","See ya"));
            Application.Quit();
            return false;
        }));
       
    }
}
