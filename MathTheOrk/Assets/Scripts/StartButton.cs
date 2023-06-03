using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton  : MonoBehaviour, IButton 
{
    public void Press()
    {
        GameManager.score = 0;
        SceneManager.LoadScene("Game");
    }

    public void PressShop()
    {
        SceneManager.LoadScene("Shop");
    }
}
