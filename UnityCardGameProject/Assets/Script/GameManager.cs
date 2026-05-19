using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int GameTurnCount = 1;
    public int MaxPlayerHp = 50;
    public int MaxPlayerSp = 50;

    public int PlayerStr = 10;
    

    // 플레이어가 최종 선택한 카드
    public CardData selectedCard;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}