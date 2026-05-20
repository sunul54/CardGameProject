using UnityEngine;
using System.Collections.Generic;

public class CardManager : MonoBehaviour
{
    public CardData[] allCards;
    public CardSlot[] cardSlots;

    void Start()
    {
        if (allCards == null || allCards.Length == 0 || cardSlots.Length == 0) return;

        // 1. 결과물을 담을 리스트 생성
        List<CardData> finalSelection = new List<CardData>();

        // 2. 먼저 모든 카드를 한 번씩 순서대로 넣음 (5개 이하일 때 전부 등장 보장)
        // 만약 카드가 슬롯보다 많다면 슬롯 개수까지만 넣음
        int firstPassCount = Mathf.Min(allCards.Length, cardSlots.Length);
        for (int i = 0; i < firstPassCount; i++)
        {
            finalSelection.Add(allCards[i]);
        }

        // 3. 남은 슬롯이 있다면(카드가 5개 미만일 때), 무작위 중복 카드로 채움
        while (finalSelection.Count < cardSlots.Length)
        {
            int randomIndex = Random.Range(0, allCards.Length);
            finalSelection.Add(allCards[randomIndex]);
        }

        // 4. (선택 사항) 결과 리스트를 한 번 더 섞어줍니다. 
        // 이렇게 해야 항상 앞의 슬롯에만 고정된 카드가 나오는 것을 방지합니다.
        for (int i = 0; i < finalSelection.Count; i++)
        {
            int randomIndex = Random.Range(i, finalSelection.Count);
            CardData temp = finalSelection[i];
            finalSelection[i] = finalSelection[randomIndex];
            finalSelection[randomIndex] = temp;
        }

        // 5. 최종 결정된 카드들을 슬롯에 배치
        for (int i = 0; i < cardSlots.Length; i++)
        {
            cardSlots[i].SetCard(finalSelection[i]);
        }
    }
}