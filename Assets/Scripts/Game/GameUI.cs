using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    public void Restart()
    {
        string scene = SceneManager.GetActiveScene().name;

        SceneManager.LoadScene(scene);
    }
    
    public void Exit()
    {
        SceneManager.LoadScene("Menu");
    }
}
