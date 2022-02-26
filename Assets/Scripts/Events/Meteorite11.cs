using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteorite11 : CardEvent
{
    public Meteorite11()
    {
        DaysToPlay = 2;
        Name = "Meteorite failure!";
        Description = "Your scientifics and your army managed to move your castle, but it doesn't seem that the meteorite actually existed in the first place.";

        getChoices.Add(new Choice(0,0,0,"Good investment",()=> {
            return false;
        }));
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
