using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;       // For text

public class GameManager : MonoBehaviour
{
    public GameObject startPage;
    public GameObject gameOverPage;
    public GameObject countdownPage;
    public Text scoreText;

    enum PageState
    {
        None,
        Start,
        GameOver,
        Countdown
    }

    int score = 0;
    bool gameOver = false;

    // To prevent other script from changing this value
    public bool GameOver { get { return gameOver; }}
}
