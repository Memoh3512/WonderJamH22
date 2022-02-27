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
        while (true)
        {
            //GameManager.playerKingdom = new Kingdom();
           
            if (goldUI < GameManager.playerKingdom?.Gold)
            {
                gold.color = Color.green;
                goldUI ++;
            }
            else if (goldUI > GameManager.playerKingdom?.Gold)
            {
                gold.color = Color.red;
                goldUI--;
            }
            else
            {
                gold.color = Color.white;
            }
            gold.text = goldUI.ToString();
            //
            if (mpUI < GameManager.playerKingdom?.MilitaryPower)
            {
                atk.color = Color.green;
                mpUI++;
            }
            else if (mpUI > GameManager.playerKingdom?.MilitaryPower)
            {
                atk.color = Color.red;
                mpUI--;
            }
            else
            {
                atk.color = Color.white;
            }
            atk.text = mpUI.ToString();
            //
            if (hpUI < GameManager.playerKingdom?.KingdomLife)
            {
                health.color = Color.green;
                hpUI++;
            }
            else if (hpUI > GameManager.playerKingdom?.KingdomLife)
            {
                health.color = Color.red;
                hpUI--;
            }
            else
            {
                health.color = Color.white;
            }
            health.text = hpUI.ToString();



            string k = GameManager.playerKingdom == null ? "" : GameManager.playerKingdom.Name;
            if (!k.Contains("Kingdom")) k += " Kingdom";
            days.text =  k + "\nDay " + GameManager.day;
            kingdomUIs.RefreshKingdomsUI();
            yield return new WaitForSeconds(0.025f);
        }

    }

    public void PlayBtnSnd()
    {
        
        SoundPlayer.instance.PlaySFX(Resources.Load<AudioClip>("SFX/SFX_Menu button"));
        
    }
    
}
