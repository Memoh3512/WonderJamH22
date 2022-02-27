using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorseRace : CardEvent
{
    public HorseRace()
    {
        
        Name = "Taking bets!";
        Description = "The greatest horse stable in the Kingdom decided to organize a horse race event. The bests riders from here and the Cowboy village are going to run for the win."
        + " On which horse would you like to bet 25 bucks? If you win you double your bet. ";

        getChoices.Add(new Choice(25,0,-0,"Crindombre",()=> {
            GameManager.addPlannedEvent(new Message("Horse race","Crindombre, from the Cowboy village saw a flock of birds in the sky and started to run for it."
                + " It never arrived to the finish line.","Well... too bad!"));
            return false;//TODO donne des bonnes relations avec les cowboys.
        }));

        getChoices.Add(new Choice(25,0,0,"Durillon",()=> {
            GameManager.AddEventForToday(new Message("Horse race","This horse was so tired that it was walking like a zombie. Sorry, it ended up last of them.","Poor beast..."));
            return false;
        }));
        getChoices.Add(new Choice(-50,0,0,"Roach",()=> {
            GameManager.AddEventForToday(new Message("Horse race","Being the horse of a witch, it was granted with some spell that made it teleport to the finish line. You won!","Yeah! "));
            return false;
        }));
        getChoices.Add(new Choice(0,-0,-0,"Epona",()=> {
            GameManager.AddEventForToday(new Message("Horse race","This horse, also called The Legend in the Cowboy village, made the link between the beginning and the end so fast!"
                + "Not fast enough tho, it ended 2nd place.","Yeeha"));
            return false;//TODO donne des bonnes relations avec les cowboys
        }));
    }
}

