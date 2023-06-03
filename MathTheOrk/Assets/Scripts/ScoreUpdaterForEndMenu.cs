using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUpdaterForEndMenu : MonoBehaviour
{
    public Score score;
    public Text moneyText;



    public void Start()
    {
        score.ShowEndScore();
        score.UpdateMoney(moneyText);
    }
}
