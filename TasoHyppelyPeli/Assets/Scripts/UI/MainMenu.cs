using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Button playGame;
    [SerializeField] private Button quitGame;
    private void Awake() {
        playGame.Select();
    }
    private void Update() {
        if(Input.GetButtonDown("Jump"))
        {
            if(EventSystem.current.currentSelectedGameObject == playGame.gameObject)
            {
                PlayGame();
            }
            else if(EventSystem.current.currentSelectedGameObject == quitGame.gameObject)
            {
                print("quitting");
                QuitGame();
            }
        }
    }
    public void PlayGame()
    {
        SceneManager.LoadScene("Level 1");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
