using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TaskGenerator : MonoBehaviour
{
    public GameManager gameManager;
    public Timer timer;
    public Save save;

    public List<double> answers = new List<double>();
   

    private int FirstValue;
    private int SecondValue;

    private int OperationVariation;

    public double ans;

    public Text taskText;
    public Text button1Text;
    public Text button2Text;
    public Text button3Text;
    public Text button4Text;
    public Buttons[] Buttons;

    private int GenRandomValue(int dificult)
    {
        if (dificult <= 10)
        {
            OperationVariation = Random.Range(1, 3);
            return Random.Range(0, 10);
        }
        else if (dificult <= 100)
        {
            OperationVariation = Random.Range(1, 4);
            return Random.Range(0, 100);
        }
        else
        {
            OperationVariation = Random.Range(1, 5);
            return Random.Range(0, 1000);
        }
    } 

    public void GetTask(int difficulty)
    {
        FirstValue = GenRandomValue(difficulty);
        SecondValue = GenRandomValue(difficulty);

        switch (OperationVariation)
        {
            case 1:
                ans = FirstValue + SecondValue;
                taskText.text = $"{FirstValue} + {SecondValue} =  ?";
                break;

            case 2:
                ans = FirstValue - SecondValue;
                taskText.text = $"{FirstValue} - {SecondValue} =  ?";
                break;


            case 3:
                ans = FirstValue * SecondValue;
                taskText.text = $"{FirstValue} * {SecondValue} =  ?";
                break;


            case 4:
                while (SecondValue == 0)
                {
                    SecondValue = GenRandomValue(difficulty);
                }
                ans = FirstValue / SecondValue;
                taskText.text = $"{FirstValue} / {SecondValue} =  ?";
                break;
        }
    }
   
    public double GenAnsOptionValue()
    {
        int mathOperation = Random.Range(1, 5);
        switch (mathOperation)
        {
            case 1:
                return (ans - Random.Range(2, 11));

            case 2:
                return (ans + Random.Range(2, 11));

            case 3:
                if (ans != 0) return (ans * Random.Range(2, 11));
                else return (ans - Random.Range(11, 15));

            case 4:
                if (ans != 0) return (ans / Random.Range(2, 11));
                else return (ans - Random.Range(11, 15));
        }
        return (ans + Random.Range(2, 11));
    }

    public void FillList()
    {
        answers.Clear();
        answers.Add(0);
        answers.Add(0);
        answers.Add(0);
        answers.Add(0);

        int ansPosition = Random.Range(0, 4);
        while (answers.Distinct().Count() != 4)
        {
            for (int i = 0; i <= 3; i++)
            {
                answers[i] = GenAnsOptionValue();
            }
        }

        answers[ansPosition] = ans;
        button1Text.text = answers[0].ToString("F2");
        button2Text.text = answers[1].ToString("F2");
        button3Text.text = answers[2].ToString("F2");
        button4Text.text = answers[3].ToString("F2");
    }

    public void checkAnwser()
    {
        for (int i = 0; i < 4; i++)
        {
            if (Buttons[i].isPressed && answers[i] == ans && timer.isRunning) 
            {
                GameManager.score++;
                GameManager.money++;
                Buttons[i].isPressed = false;
                gameManager.ShowScore();
                gameManager.Raund();
                break;
            } else if (Buttons[i].isPressed && answers[i] != ans)
            {
                Buttons[i].isPressed = false;
                timer.count = 250;
                if (GameManager.highScore < GameManager.score)
                {
                    GameManager.highScore = GameManager.score;
                }
                save.SaveData();
                SceneManager.LoadScene("EndMenu");
                break;
            }
        }
    }
}
