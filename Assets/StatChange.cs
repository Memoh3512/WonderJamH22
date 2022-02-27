using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StatChange : MonoBehaviour
{
    public float time = 0.5f;
    public float yOffset = 100f;

    public void SetStat(Stat stat, int variance)
    {

        Sprite spr = spr = Resources.Load<Sprite>("gold") ;

        switch (stat)
        {
            
            case Stat.Gold:
                spr = Resources.Load<Sprite>("gold");
                break;
            case Stat.KingHealth:
                spr = Resources.Load<Sprite>("heart");
                break;
            case Stat.MilitaryPower:
                spr = Resources.Load<Sprite>("sword");
                break;
            
        }

        if (variance > 0)
        {
            
            transform.Find("Variance").GetComponent<TextMeshProUGUI>().text = "+";
            transform.Find("Variance").GetComponent<TextMeshProUGUI>().color = Color.green;

        }
        else
        {
            
            transform.Find("Variance").GetComponent<TextMeshProUGUI>().text = "-";
            transform.Find("Variance").GetComponent<TextMeshProUGUI>().color = Color.red;
            
        }

        transform.Find("Icon").GetComponent<Image>().sprite = spr;

        StartCoroutine(statCor());

    }

    private IEnumerator statCor()
    {

        Vector3 pos = GetComponent<RectTransform>().position;
        float t = 0;
        while (t < time)
        {

            float i = t / time;
            GetComponent<RectTransform>().position = new Vector3(GetComponent<RectTransform>().position.x,
                Mathf.Lerp(GetComponent<RectTransform>().position.y, GetComponent<RectTransform>().position.y + yOffset,
                    i));
            t += Time.deltaTime;
            yield return null;

        }
        
        //fade out
        float a = 1f;
        while (a > 0)
        {

            GetComponent<CanvasGroup>().alpha = a;
            a -= 1f / 20f;
            yield return null;

        }
        
        Destroy(gameObject);

    }
    
}
