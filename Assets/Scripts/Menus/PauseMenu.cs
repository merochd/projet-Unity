using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class PauseMenu : MonoBehaviour
{

    [SerializeField] private UIDocument _pauseMenu;
    [SerializeField] private UIDocument _HUD;

    private bool _isPaused = false;

    private void Start()
    {
        VisualElement root;
        Button buttonResume;
        Button buttonMainMenu;

        root = _pauseMenu.rootVisualElement;

        buttonResume = root.Q<Button>("ResumeBtn");
        if (buttonResume is not null)
        {
            buttonResume.RegisterCallback<ClickEvent>(OnClickedResume);
        }

        buttonMainMenu = root.Q<Button>("MainMenuBtn");
        if (buttonMainMenu is not null)
        {
            buttonMainMenu.RegisterCallback<ClickEvent>(OnClickedMain);
        }

        ExitPause();

    }

    private void OnClickedMain(ClickEvent evt)
    {
        Debug.Log("Main");
        ExitPause();
        SceneManager.LoadScene("MainMenu");
        Debug.Log("Main Menu");
        
    }



    private void OnClickedResume(ClickEvent evt)
    {
        Debug.Log("Resume");
        ExitPause();
    }


    private void OnPause(InputValue value)
    {

        Debug.Log("Pause Input");

        if (_isPaused)
        {
            // Plus la pause
            ExitPause();
        }
        else
        {
            // C'est la pause
            EnterPause();
        }
    }

    private void EnterPause()
    {
        _pauseMenu.rootVisualElement.style.display = DisplayStyle.Flex;
        _HUD.rootVisualElement.style.display = DisplayStyle.None;
        Time.timeScale = 0F;
        Debug.Log("Pause");
        _isPaused = true;
    }

    private void ExitPause()
    {
        _pauseMenu.rootVisualElement.style.display = DisplayStyle.None;
        _HUD.rootVisualElement.style.display = DisplayStyle.Flex;
        Time.timeScale = 1F;
        Debug.Log("Fin de la pause");
        _isPaused = false;
    }

}
