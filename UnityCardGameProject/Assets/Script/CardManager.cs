using UnityEngine;

public class CardManager : MonoBehaviour
{
    public CardData[] allCards;

    public CardSlot[] cardSlots;

    void Start()
    {
        

        for (int i = 0; i < cardSlots.Length; i++)
        {
           

            int randomIndex = Random.Range(0, allCards.Length);

            

            CardData selectedCard = allCards[randomIndex];

            

            cardSlots[i].SetCard(selectedCard);

            
        }

       
    }
}