using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSession : MonoBehaviour
{
    [SerializeField] int playerLive = 3;
    [SerializeField] int Score = 0; 
    [SerializeField] TextMeshProUGUI livesText;
    [SerializeField] TextMeshProUGUI scoreText;
    // Start is called before the first frame update
    void Awake()
    {
        int numGameSessions = FindObjectsOfType<GameSession>().Length;
        if (numGameSessions > 1)
        {
            Destroy(gameObject);
        }
        else{
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        livesText.text = playerLive.ToString();
        scoreText.text = Score.ToString();
    }

    public void ProcessPlayerDeath()
    {
        if(playerLive > 1){
            TakeLife();

        }
        else{
            ResetGameSession();
        }
    }

    public void AddToScore(int pointsToAdd)
    {
        Score += pointsToAdd;
        scoreText.text = Score.ToString();
    }

    void TakeLife()
    {
       playerLive--;
       int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
       SceneManager.LoadScene(currentSceneIndex);
       livesText.text = playerLive.ToString();
    }

    void ResetGameSession()
    {
        SceneManager.LoadScene(0);
        Destroy(gameObject);
    }
}
