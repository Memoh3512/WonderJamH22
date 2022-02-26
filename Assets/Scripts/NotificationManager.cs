using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NotificationManager : MonoBehaviour
{
    [SerializeField] 
    public GameObject spriteSquare;
    public GameObject textAmount;
    private int state = 0;//0 inactif,1 monte,2 attend, 3 descend
    private float speed;
    private float baseCounter = 1.5f;
    private float counter = 0;

    private static List<Notification> toDisplay;
    // Start is called before the first frame update
    void Start()
    {
        toDisplay = new List<Notification>(){};
        //startNotification(0,200);
        state = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (state == 0)
        {
            if (toDisplay.Count>0)
            {
                spriteSquare.GetComponent<Image>().sprite = toDisplay[0].logo;
                textAmount.GetComponent<TextMeshProUGUI>().text = toDisplay[0].text;
                toDisplay.Remove(toDisplay[0]);
                state = 1;
                counter = 0;
            }
        }else if (state == 1)
        {
            RectTransform trans = GetComponent<RectTransform>();
            if (trans.anchoredPosition.y <= -472)
            {
                trans.anchoredPosition += Vector2.up * (150f * Time.deltaTime);
            }
            else
            {
                state = 2;
            }

        }else if (state == 2)
        {
            if (counter < baseCounter)
            {
                counter += Time.deltaTime;
            }
            else
            {
                state = 3;
            }

        }else if (state == 3)
        {
            RectTransform trans = GetComponent<RectTransform>();
            if (trans.anchoredPosition.y >= -605)
            {
                trans.anchoredPosition += -Vector2.up * (150f * Time.deltaTime);
            }
            else
            {
                state = 0;
            }
        }
        
        
    }
    public static void startNotification(int type, int amount)
    {//0 gold, 1 lif, 2 power

        Sprite ressourceSprite =Resources.Load<Sprite>("gold");
        string amountStr = amount.ToString();
        if (amount > 0)
        {
            amountStr = "+" + amountStr;
        }
        switch (type)
        {
            case 0: ressourceSprite = Resources.Load<Sprite>("gold");
                break;
            case 1: ressourceSprite = Resources.Load<Sprite>("heart");
                break;
            case 2: ressourceSprite = Resources.Load<Sprite>("sword");
                break;
        }
        toDisplay.Add(new Notification(ressourceSprite,amountStr));
    }
}
