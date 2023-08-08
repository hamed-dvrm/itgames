using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelManager : MonoBehaviour
{
    [SerializeField] TMP_Text goalText;
    [SerializeField] int m_numOfGoalAnars;
    [SerializeField] PlayerController m_player;
    [SerializeField] GameObject m_grayScreen;
    [SerializeField] GameObject m_resultMenu;
    [SerializeField] GameObject m_continueButton;
    [SerializeField] GameObject m_restartButton;
    [SerializeField] GameObject m_middleStar;
    [SerializeField] GameObject abiltxt;
    public static LevelManager m_instance;
    public AudioSource catchscore, win;

    private int m_numOfAchievedAnars;
    public int m_obstgen;
    public void Start()
    {

        if (m_instance == null)
        {
            m_instance = this;
        }
        else if (m_instance != this)
        {
            Destroy(this.gameObject);
        }

        UpdateGoalUi();
    }

    private void UpdateGoalUi()
    {
        goalText.text = m_numOfAchievedAnars + "/" + m_numOfGoalAnars;
    }

    public void IncreaseAchievedAnar()
    {
        catchscore.Play();
        m_numOfAchievedAnars++;
        UpdateGoalUi();
        if (isLevelFinished())
        {
            PassLevel();
        }




    }
    //------------------------------------------------------------
    public bool isLevelFinished()
    {
        if (m_numOfAchievedAnars >= m_numOfGoalAnars)
        {
            return true;
        }
        return false;
    }
    public void endanars()
    {
        Time.timeScale = 0f;
        m_grayScreen.SetActive(true);
        m_resultMenu.SetActive(true);
        abiltxt.SetActive(true);
        m_continueButton.SetActive(true);
        m_restartButton.SetActive(false);
        TMP_Text resultText = m_resultMenu.GetComponentInChildren<TMP_Text>();
        if (resultText != null)
        {
            resultText.text = "Game Over";
        }
    }

    public void PassLevel()
    {
        win.Play();
        Time.timeScale = 0f;
        m_grayScreen.SetActive(true);
        m_resultMenu.SetActive(true);
        m_continueButton.SetActive(true);
        m_restartButton.SetActive(false);
        m_middleStar.SetActive(true);
        abiltxt.SetActive(true);


    }

    public void RestartLevel()
    {
        Time.timeScale = 1.0f;
        int currentLevelIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentLevelIndex);
    }

    public void PauseGame()
    {
        Time.timeScale = 0.0f;
    }

    public void Resume()
    {
        Time.timeScale = 1.0f;
    }

    public void QuitGame()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(0);
    }

    public void FailLevel()
    {
        Time.timeScale = 0f;
        m_grayScreen.SetActive(true);
        m_resultMenu.SetActive(true);
        m_continueButton.SetActive(true);
        abiltxt.SetActive(false);
        //---
        m_restartButton.SetActive(false);
        TMP_Text resultText = m_resultMenu.GetComponentInChildren<TMP_Text>();
        if (resultText != null)
        {
            resultText.text = "Failed";
        }

    }

    public void LoadNextLevel()
    {
        Time.timeScale = 1f;
        int currentLevelIndex = SceneManager.GetActiveScene().buildIndex;
        int nextLevelIndex = (currentLevelIndex + 1) % SceneManager.sceneCountInBuildSettings;
        SceneManager.LoadScene(nextLevelIndex);
    }
}
