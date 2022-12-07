using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class gameOver : MonoBehaviour
{
    [SerializeField] private Text scoreText;
    [SerializeField] private Button _replay;
    [SerializeField] private Button _mainScreen;
    private static int reloadLevel;
    private static int scoreCount;
    private void Start() {
        scoreText.text = "Collected Melons: "+scoreCount;
    }
    private void Awake() {
        _replay.Select();
    }
    private void Update() {
        if(Input.GetButtonDown("Jump"))
        {
            if(EventSystem.current.currentSelectedGameObject == _replay.gameObject)
            {
                restartLevel();
            }
            else if(EventSystem.current.currentSelectedGameObject == _mainScreen.gameObject)
            {
                startScreen();
            }
        }
    }
    public void restartLevel()
    {
        SceneManager.LoadScene(reloadLevel);
    }
    public void startScreen()
    {
        SceneManager.LoadScene("Main Menu");
    }
    public static void setLevel(int level)
    {
        reloadLevel = level;
    }
    public static void setScore(int score)
    {
        scoreCount = score;
    }
}
