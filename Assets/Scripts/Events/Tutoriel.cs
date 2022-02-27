using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutoriel : CardEvent
{
    public Tutoriel()
    {
        
        Name = "How to play";
        Description = "Sur le parchemin, vous retrouverez des évènements auxquelles vous devrez choisir votre action";

        getChoices.Add(new Choice(0,0,0,"J'accepte",()=> {
            GameManager.AddEventForToday(new Message("L'offre est acceptée","Préparez-vous à défendre votre royaume","Je suis prêt"));
            return false;
        }));

        getChoices.Add(new Choice(0,0,0,"Je refuse",()=> {
            GameManager.AddEventForToday(new Message("L'offre est refusée","Bonne journée!","Bye bye"));
            Application.Quit();
            return false;
        }));
       
    }
}
