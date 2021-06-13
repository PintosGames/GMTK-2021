using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    public void Restart()
    {
        SceneManager.LoadScene("Menu");
    }
    
    public void Exit()
    {
        Application.Quit();
    }
}
