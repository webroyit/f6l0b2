using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;       // For text

// Required Text
[RequireComponent(typeof(Text))]
public class HighscoreText : MonoBehaviour
{
    Text highscore;

    void OnEnable()
    {
        highscore = GetComponent<Text>();

        // Get the highscore from local device
        highscore.text = PlayerPrefs.GetInt("HighScore").ToString();
    }
}
