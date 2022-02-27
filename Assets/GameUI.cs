using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameUI : MonoBehaviour
{

    public TextMeshProUGUI gold, atk, health, days;
    public KingdomsUISpawner kingdomUIs;

    private int goldUI = 0;
    private int mpUI = 0;
    private int hpUI = 0;
    
    // Start is called before the first frame update
    void Start()
    {

        StartCoroutine(UpdateUIValues());

    }

    public IEnumerator UpdateUIValues()
    {

        //GameManager.playerKingdom = new Kingdom();
        yield return new WaitForSeconds(0.05f);
        int sign = 1;
        if(goldUI < GameManager.playerKingdom?.Gold)
        {
            gold.color = Color.green;
            sign = 1;
        }else if (goldUI > GameManager.playerKingdom?.Gold)
        {
            gold.color = Color.red;
            sign = -1;
        }
        else
        {
            gold.color = Color.white;
        }
        goldUI += sign;
        gold.text = goldUI.ToString();
        //
        if (mpUI < GameManager.playerKingdom?.MilitaryPower)
        {
            atk.color = Color.green;
            sign = 1;
        }
        else if (mpUI > GameManager.playerKingdom?.MilitaryPower)
        {
            atk.color = Color.red;
            sign = -1;
        }
        else
        {
            atk.color = Color.white;
        }
        mpUI += sign;
        atk.text = mpUI.ToString();
        //
        if (hpUI < GameManager.playerKingdom?.KingdomLife)
        {
            health.color = Color.green;
            sign = 1;
        }
        else if (hpUI > GameManager.playerKingdom?.KingdomLife)
        {
            health.color = Color.red;
            sign = -1;
        }
        else
        {
            health.color = Color.white;
        }
        hpUI += sign;
        health.text = hpUI.ToString();
        


        days.text = "Day " + GameManager.day;
        kingdomUIs.RefreshKingdomsUI();

    }

    public void PlayBtnSnd()
    {
        
        //TODO FLO play son bouton
        
    }
    
}
