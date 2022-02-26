using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            d += kingdomSpacing;


        }
        
    }
    
}
