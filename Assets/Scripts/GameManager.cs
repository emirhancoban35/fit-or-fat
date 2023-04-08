using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public void LoseGame()
    {
        Time.timeScale = 0;
    }

    public void FinishLevel()
    {
        Time.timeScale = 0;

    }
}