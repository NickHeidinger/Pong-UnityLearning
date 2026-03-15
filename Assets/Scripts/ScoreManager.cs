using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    public TMP_Text player1ScoreText;
    public TMP_Text player2ScoreText;

    private int player1Score = 0;
    private int player2Score = 0;

    void Awake()
    {
        Instance = this;
    }

    public void Player1Scores()
    {
        player1Score++;
        player1ScoreText.text = player1Score.ToString();
    }

    public void Player2Scores()
    {
        player2Score++;
        player2ScoreText.text = player2Score.ToString();
    }
}