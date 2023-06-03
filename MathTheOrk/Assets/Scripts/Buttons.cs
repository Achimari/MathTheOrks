using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour, IButton
{
    public bool isPressed = false;

    public TaskGenerator taskGenerator;
    public GameManager gameManager;
    public Timer timer;

    public void Press(int index)
    {
        isPressed = true;
        taskGenerator.checkAnwser();
    }

    public void Press()
    {
      
    }
}
