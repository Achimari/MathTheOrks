
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{

    public Text scoreText;

    public void ShowEndScore()
    {
        scoreText.text = $"Your score: {GameManager.score}";
    }

    public void UpdateHighScore()
    {
        if (GameManager.score > GameManager.highScore) GameManager.highScore = GameManager.score;
        scoreText.text = $"High Score: {GameManager.highScore}";
    }

    public void UpdateMoney(Text text)
    {
        text.text = $"Earned money: {GameManager.score}";
    }
}
