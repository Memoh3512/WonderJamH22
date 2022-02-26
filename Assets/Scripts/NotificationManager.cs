using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NotificationManager : MonoBehaviour
{
    [SerializeField] 
    public GameObject spriteSquare;
    public GameObject textAmount;
    public Sprite gold;
    public Sprite militaryP;
    public Sprite life;
    private int state = 0;//0 inactif,1 monte,2 attend, 3 descend
    private float speed;
    private float baseCounter = 1;
    private float counter = 0;

    private static List<Notification> toDisplay;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (state == 0)
        {
            if (toDisplay.Count>0)
            {
                spriteSquare.GetComponent<SpriteRenderer>().sprite = toDisplay[0].logo;
                textAmount.GetComponent<TextMeshPro>().text = toDisplay[0].text;
                toDisplay.Remove(toDisplay[0]);
                state = 1;
                counter = 0;
            }
        }else if (state == 1)
        {
            if (transform.position.y <= -500f)
            {
                transform.position += Vector3.up * (10f * Time.deltaTime);
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
            if (transform.position.y >= -580f)
            {
                transform.position += -Vector3.up * (10f * Time.deltaTime);
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
            case 1: ressourceSprite = Resources.Load<Sprite>("life");
                break;
            case 2: ressourceSprite = Resources.Load<Sprite>("power");
                break;
        }
        toDisplay.Add(new Notification(ressourceSprite,amountStr));
    }
}
