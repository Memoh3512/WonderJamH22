using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class CardDisplay : MonoBehaviour
{

    private CardEvent currentCard;

    public GameObject choicePrefab;
    public GameObject buttonContainer;
    
    public TextMeshProUGUI title, desc;

    public float btnPadding = 10f;
    public float xOffset = 50f;

    private static bool opened = false;
    
    // Start is called before the first frame update
    void Start()
    {
        //SetCardEvent(new CardEvent());
        UpdateUI();
    }

    public void SetCardEvent(CardEvent card)
    {

        currentCard = card;

    }

    public void DeleteButtons()
    {
        
        //update choices
        foreach (Button b in buttonContainer.transform.GetComponentsInChildren<Button>())
        {
            
            Destroy(b.gameObject);
            
        }
        
    }

    private void PlaySound()
    {
        
        opened = !opened;
        if (opened)
        {
            
            SoundPlayer.instance.PlaySFX(Resources.Load<AudioClip>("SFX/SFX_Cllose parchemin"), 2f);
            
        }
        else
        {
            
            SoundPlayer.instance.PlaySFX(Resources.Load<AudioClip>("SFX/SFX_Open parchemin"), 2f);
            
        }

    }
    
    private void UpdateUI()
    {

        //update text

        DeleteButtons();
        
        if (choicePrefab == null || currentCard == null) return;
        
        currentCard.checkIfChoiceBuyable();
        
        title.text = currentCard.Name;
        desc.text = currentCard.Description;

        int nb = currentCard.getNbChoices;
        float width = GetComponent<RectTransform>().sizeDelta.x * 0.65f;

        if (nb <= 0) return;

        float btnWidth = width - ((nb - 1) * btnPadding);
        btnWidth /= (float)nb;

        float startPos = -(width / 2f) + btnWidth / 2f;
        startPos += xOffset;
        
        foreach (Choice c in currentCard.getChoices)
        {

            GameObject choice = Instantiate(choicePrefab, buttonContainer.transform);
            choice.GetComponent<RectTransform>().sizeDelta = new Vector2(btnWidth, choice.GetComponent<RectTransform>().sizeDelta.y);
            choice.GetComponent<RectTransform>().localPosition = new Vector3(startPos, -400);
            choice.GetComponentInChildren<TextMeshProUGUI>().text = c.Description;
            
            choice.GetComponent<Button>().onClick.AddListener((() => c.process()));
            choice.GetComponent<Button>().onClick.AddListener((() => FindObjectOfType<GameUI>().PlayBtnSnd()));
            
            startPos += btnPadding + (btnWidth);

        }

    }

    public void CloseEvents()
    {
        
        Destroy(gameObject);
        
    }
}
