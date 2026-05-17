using UnityEngine;

public class CardManager : MonoBehaviour
{
    public CardData[] allCards;

    public CardSlot[] cardSlots;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < cardSlots.Length; i++)
        {
            int randomIndex = Random.Range(0, allCards.Length);

            cardSlots[i].currentCard = allCards[randomIndex];

            Debug.Log(cardSlots[i].currentCard.CardName);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
