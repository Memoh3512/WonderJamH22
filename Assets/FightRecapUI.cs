using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FightRecapUI : MonoBehaviour
{
    private Canvas c;

    public TextMeshProUGUI kingdomStats;
    public TextMeshProUGUI title;
    public Image seal;

    // Start is called before the first frame update
    void Start()
    {
        c = GetComponent<Canvas>();
        c.enabled = false;
    }

    public void EndFight()
    {
        SoundPlayer.instance.SetMusic(Songs.Village, 1f, TransitionBehavior.Stop);
        LevelLoader.instance.LoadScene("GameplayScene", TransitionTypes.CrossFade);
        
    }

    public void OpenMenu(string whowon,int loseAll,int loseEn,int goldGained)
    {
        var won = whowon == "Allies" ? "Victory!" : "Defeat...";

        title.text = won;

        if (won == "Victory!") seal.sprite = Resources.Load<Sprite>("seal");
        else seal.color = new Color(0, 0, 0, 0);
        
        string player = FightManager.woundedAllies.Count == 0 ? "no" : (FightManager.woundedAllies.Count+FightManager.fullDeadAllies.Count).ToString();
        string life = "";
        string gold = "";
        if (whowon != "Allies")
        {
            life = " and life..";
        }
        else
        {
            gold = "\nYou have gained " + goldGained + " gold";
        }
        kingdomStats.text = $"We lost {loseAll} military power "+life+gold;

        c.enabled = true;
    }

    public void PlayBtnSFX()
    {
        
        SoundPlayer.instance.PlaySFX(Resources.Load<AudioClip>("SFX/SFX_Menu button"));
        
    }
}