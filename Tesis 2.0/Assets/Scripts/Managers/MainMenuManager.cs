using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private string sceneToLoad;
    [SerializeField] private Button playButton;
    [SerializeField] private Button creditsButton;
    [SerializeField] private Button exitButton;
    [SerializeField] private Button backButton;
    [SerializeField] private GameObject creditsScreen;
    

    private void Awake()
    {
        creditsScreen.SetActive(false);
        
        playButton.onClick.AddListener(OnPlayButtonClicked);
        creditsButton.onClick.AddListener(OnCreditsButtonClicked);
        backButton.onClick.AddListener(OnBackButtonClicked);
        exitButton.onClick.AddListener(OnExitButtonClicked);
    }

    private void OnPlayButtonClicked()
    {
        SceneManager.LoadScene(sceneToLoad);
    }

    private void OnCreditsButtonClicked()
    {
        creditsScreen.SetActive(true);
    }

    private void OnBackButtonClicked()
    {
        creditsScreen.SetActive(false);
    }

    private void OnExitButtonClicked()
    {
        Application.Quit();
    }
}