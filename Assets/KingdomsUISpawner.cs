using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KingdomsUISpawner : MonoBehaviour
{

    public GameObject uiPrefab;
    public float kingdomSpacing = 150f;
    
    // Start is called before the first frame update
    void Start()
    {
     
        RefreshKingdomsUI();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RefreshKingdomsUI()
    {

        //clear children
        foreach (Transform ui in transform)
        {
            if (ui != this)Destroy(ui.gameObject);
        }
        
        float d = 0;
        if (GameManager.aiKingdoms == null) return;
        foreach (Kingdom k in GameManager.aiKingdoms)
        {

            GameObject ui = Instantiate(uiPrefab, transform);
            ui.GetComponent<RectTransform>().localPosition = new Vector3(0, -d);
            ui.transform.Find("kingdomIcon").GetComponent<Image>().sprite = k.icon;
            d += kingdomSpacing;

            switch (k.Relation)
            {
                
                case 1: ui.transform.Find("kingdomRelation").GetComponent<Image>().sprite = Resources.Load<Sprite>("happy"); break;
                case 0: ui.transform.Find("kingdomRelation").GetComponent<Image>().sprite = Resources.Load<Sprite>("neutral"); break;
                case -1: ui.transform.Find("kingdomRelation").GetComponent<Image>().sprite = Resources.Load<Sprite>("angry"); break;
                default: ui.transform.Find("kingdomRelation").GetComponent<Image>().sprite = Resources.Load<Sprite>("neutral"); break;
                
            }
            

        }
        
    }
    
}
