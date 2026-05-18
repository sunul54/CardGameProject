using UnityEngine;

public class CardSlot : MonoBehaviour
{
    public int cardSlotNum;

    public CardData currentCard;

    public CardTooltipUI tooltipUI;

    private SpriteRenderer sr;

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    public void SetCard(CardData cardData)
    {
        currentCard = cardData;

        sr.sprite = cardData.cardImage;
    }

    void OnMouseEnter()
    {
        tooltipUI.Show(currentCard);
    }

    void OnMouseExit()
    {
        tooltipUI.Hide();
    }
}