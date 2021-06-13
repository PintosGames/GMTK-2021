using UnityEngine;

public class GameOver : MonoBehaviour 
{
    public void OnAnimationDone()
    {
        Time.timeScale = 0;
    }
}