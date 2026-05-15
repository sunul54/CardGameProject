using UnityEngine;

[CreateAssetMenu(menuName ="Card")]
public class CardData : ScriptableObject 
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public string CardName; // 카드 이름
    public int CardID; //카드 ID
    public string CardType; //카드 종류
    public int damage; //카드 공격력
    public Sprite cardImage; //카드 이미지
    [TextArea]
    public string CardDesc; //카드 설명
}
