using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FightRecapUI : MonoBehaviour
{
    private Canvas c;

    public TextMeshProUGUI enemyStats;
    public TextMeshProUGUI kingdomStats;

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

    public void OpenMenu(string whowon,int loseAll,int loseEn)
    {

        string won = whowon == "Enemies" ? "Won!" : "Lost!";

        string enemies = FightManager.woundedEnemies.Count == 0 ? "no" : FightManager.woundedEnemies.Count.ToString();
        enemyStats.text = $"ENEMY \n\n Lost {enemies} soldiers. \n\n {won} ";
         
        won = whowon == "Allies" ? "Won!" : "Lost!";
        
        string player = FightManager.woundedAllies.Count == 0 ? "no" : (FightManager.woundedAllies.Count+FightManager.fullDeadAllies.Count).ToString();
        kingdomStats.text = $"OUR KINGDOM \n\n Lost {player} soldiers. \n\n {won} \n\n - {loseAll} military power";

        c.enabled = true;
    }

    public void PlayBtnSFX()
    {
        
        SoundPlayer.instance.PlaySFX(Resources.Load<AudioClip>("SFX/SFX_Menu button"));
        
    }
}