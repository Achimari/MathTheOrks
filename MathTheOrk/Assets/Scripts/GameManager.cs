using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private Ork ork;
    private string[] names = new string[] { "Grakar", "Fima", "Jakov", "Gorruk", "Drakthar", "Zogar", "Brug", "Brug", "Brug", "Nazgul" };

    public TaskGenerator taskGenerator;
    public Timer timer;

    public static int score = 0;
    public static int highScore = 0;
    public static int money = 0;

    public Text enemyName;
    public Text scoreText;
    public Text endScoreText;



    public void Start()
    {
        Raund();
    }



    public void Raund()
    {
        timer.count = 0;
        CreateEnemy();
        taskGenerator.GetTask(score);
        taskGenerator.FillList();
        taskGenerator.checkAnwser();
    }

    public void ShowScore()
    {
        scoreText.text = $"score: {score}";
    }


    private void CreateEnemy()
    {
        string randomName = names[Random.Range(0, names.Length)]; 
        ork = new Ork(randomName);
        enemyName.text = ork.orkName;
    }
}
