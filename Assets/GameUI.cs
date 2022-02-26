using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameUI : MonoBehaviour
{

    public TextMeshProUGUI gold, atk, health, days;
    public KingdomsUISpawner kingdomUIs;
    
    // Start is called before the first frame update
    void Start()
    {
        UpdateUIValues();

    }

    public void UpdateUIValues()
    {

        //GameManager.playerKingdom = new Kingdom();
        gold.text = GameManager.playerKingdom?.Gold.ToString();
        atk.text = GameManager.playerKingdom?.MilitaryPower.ToString();
        health.text = GameManager.playerKingdom?.KingdomLife.ToString();
        days.text = "Day " + GameManager.day;

    }
    
}
