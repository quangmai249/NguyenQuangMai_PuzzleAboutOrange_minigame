using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] int startMinutes = 0;
    [SerializeField] int startSeconds = 45;

    [SerializeField] TextMeshProUGUI txtTime;

    [SerializeField] Sprite[] arrImgStar;
    [SerializeField] Sprite[] arrImgEndGame;
    [SerializeField] Image imgEndGame;

    [SerializeField] GameObject endGamePanel;
    [SerializeField] GameObject panelStart;

    private bool isRunning = true;
    private float timeRemaining;
    private float timeRemainingDefault;
    private void Start()
    {


        timeRemaining = startMinutes * 60 + startSeconds;
        timeRemainingDefault = timeRemaining;

        endGamePanel.SetActive(false);
        panelStart.SetActive(false);
    }

    private void Update()
    {
        if (!isRunning)
        {
            return;
        }

        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            UpdateTimerUI();
        }
        else
        {
            timeRemaining = 0;
            isRunning = false;
            UpdateTimerUI();
            EndGame(1);
        }
    }

    public void EndGame(int imgIndex)
    {
        endGamePanel.SetActive(true);

        imgEndGame.sprite = arrImgEndGame[imgIndex];

        panelStart.SetActive(true);

        if (imgIndex == 0)
        {
            SetStarPanelWin();
        }
        else
        {
            SetStarPanelLose();
        }

        PlayerPrefs.SetInt("Level " + SceneManager.GetActiveScene().buildIndex, 1);
        PlayerPrefs.Save();

        Debug.Log("Level " + SceneManager.GetActiveScene().buildIndex);

        Time.timeScale = 0;

        DOTween.Clear();
    }

    private void SetStarPanelLose()
    {
        foreach (Transform item in panelStart.transform)
        {
            item.GetComponent<Image>().sprite = arrImgStar[0];
        }
    }

    private void SetStarPanelWin()
    {
        foreach (Transform item in panelStart.transform)
            item.GetComponent<Image>().sprite = arrImgStar[1];

        if (timeRemaining < timeRemainingDefault / 2)
        {
            panelStart.transform.GetChild(2).gameObject.GetComponent<Image>().sprite = arrImgStar[0];
        }

        if (timeRemaining < timeRemainingDefault / 3)
        {
            panelStart.transform.GetChild(1).gameObject.GetComponent<Image>().sprite = arrImgStar[0];
        }
    }

    private void UpdateTimerUI()
    {
        int minutes = Mathf.FloorToInt(timeRemaining / 60);
        int seconds = Mathf.FloorToInt(timeRemaining % 60);
        txtTime.text = $"{minutes:00}:{seconds:00}";
    }
}
