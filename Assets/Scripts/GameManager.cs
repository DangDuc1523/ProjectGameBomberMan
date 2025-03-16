﻿using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

[DefaultExecutionOrder(-1)]
public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public GameObject winGame;
    public GameObject messengerGame;
    public GameObject restartGame;
    public GameObject ButtonExit;
    public GameObject ButtonConfirm;
    public GameObject nextState;

    public string nameState;
    public int score = 0;
    public TextMeshProUGUI scoreText;

    private GameObject[] players;

    private void Awake()
    {
        if (Instance != null)
        {
            DestroyImmediate(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    private void OnDestroy()
    {
        if (Instance == this)
        {
            Instance = null;
        }
    }

    private void Start()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
        ButtonExit.SetActive(true);
        ButtonConfirm.SetActive(false);
        restartGame.SetActive(false);
        winGame.SetActive(false);
        messengerGame.SetActive(false);
        nextState.SetActive(false);

        UpdateScoreUI();
    }

    public void AddScore(int points)
    {
        score += points;
        Debug.Log("Điểm sau khi cộng: " + score);
        UpdateScoreUI();
    }

    private void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score;
            Debug.Log("Cập nhật UI: " + scoreText.text);
        }
    }

    public void CheckWinState()
    {
        int aliveCount = 0;

        for (int i = 0; i < players.Length; i++)
        {
            if (players[i].activeSelf)
            {
                aliveCount++;
            }
        }

        if (aliveCount <= 1)
        {

            restartGame.SetActive(true);
        }
    }

    private void NewRound()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


    public void QuitGame()
    {
        ButtonExit.SetActive(false);
        ButtonConfirm.SetActive(true);
    }

    public void ButtonYes()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void ButtonNo()
    {
        ButtonExit.SetActive(true);
        ButtonConfirm.SetActive(false);
    }

    public void RestartGame()
    {
        Invoke(nameof(NewRound), 3f);
    }

    public void changeState()
    {
        SceneManager.LoadScene(nameState);
    }

}
