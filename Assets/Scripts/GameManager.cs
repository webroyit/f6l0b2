using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;       // For text

public class GameManager : MonoBehaviour
{
    // Create events for other scripts to be used
    public delegate void GameDelegate();
    public static event GameDelegate OnGameStarted;
    public static event GameDelegate OnGameOverConfirmed;

    public static GameManager Instance;

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

    void Awake()
    {
        Instance = this;
    }

    void OnEnable()
    {
        CountdownText.OnCountdownFinished += OnCountdownFinished;
    }

    void OnDisable()
    {
        CountdownText.OnCountdownFinished -= OnCountdownFinished;
    }

    // Start the game
    void OnCountdownFinished()
    {
        SetPageState(PageState.None);
        OnGameStarted();
        score = 0;
        gameOver = false;
    }

    // Show target page
    void SetPageState(PageState state)
    {
        switch(state)
        {
            case PageState.None:
                startPage.SetActive(false);
                gameOverPage.SetActive(false);
                countdownPage.SetActive(false);
                break;
            case PageState.Start:
                startPage.SetActive(true);
                gameOverPage.SetActive(false);
                countdownPage.SetActive(false);
                break;
            case PageState.GameOver:
                startPage.SetActive(false);
                gameOverPage.SetActive(true);
                countdownPage.SetActive(false);
                break;
            case PageState.Countdown:
                startPage.SetActive(false);
                gameOverPage.SetActive(false);
                countdownPage.SetActive(true);
                break;

        }
    }

    public void ConfirmGameOver()
    {
        OnGameOverConfirmed();

        // Reset the score
        scoreText.text = "0";

        // Go back to start page
        SetPageState(PageState.Start);
    }

    public void StartGame()
    {
        // Start the count down
        SetPageState(PageState.Countdown);
    }
}
