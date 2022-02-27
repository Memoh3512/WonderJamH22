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

    public void OpenMenu(string whowon)
    {
        UpdateText(whowon);
    }

    public void EndFight()
    {
        
        LevelLoader.instance.LoadScene("GameplayScene", TransitionTypes.CrossFade);
        
    }

    private void UpdateText(string whowon)
    {

        string won = whowon == "Enemies" ? "Won!" : "Lost!";

        string enemies = FightManager.enemiesDead == 0 ? "no" : FightManager.enemiesDead.ToString();
        enemyStats.text = $"ENEMY \n\n Lost {enemies} soldiers. \n\n {won}";
         
        won = whowon == "Allies" ? "Won!" : "Lost!";
        
        string player = FightManager.soldiersDead == 0 ? "no" : FightManager.soldiersDead.ToString();
        kingdomStats.text = $"OUR KINGDOM \n\n Lost {player} soldiers. \n\n {won}";

        c.enabled = true;

    }

    public void PlayBtnSFX()
    {
        
        //TODO FLO bouton sfx
        
    }
}