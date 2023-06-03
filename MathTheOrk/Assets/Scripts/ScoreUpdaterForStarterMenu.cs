using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreUpdaterForStarterMenu : MonoBehaviour
{
    public Score score;


    public void Start()
    {
        score.UpdateHighScore();
    }
}
