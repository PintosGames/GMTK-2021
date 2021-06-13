using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour
{
    public Player player;

    //You can use a slider or a text
    public TMP_Text scoreText;
    public Slider scoreSlider;

    public int redParts;
    public int blueParts;

    public void CountBodyParts()
    {
        FindObjectOfType<AudioManager>().Play("Chomp");

        redParts = 0;
        blueParts = 0;

        foreach (Bodypart b in player.body)
        {
            if (b.blue)
            {
                blueParts++;
            }
            else
            {
                redParts++;
            }
        }

        scoreSlider.maxValue = player.body.Count;

        scoreSlider.value = blueParts;
    }
}
