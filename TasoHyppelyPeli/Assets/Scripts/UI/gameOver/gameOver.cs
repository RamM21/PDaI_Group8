using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class gameOver : MonoBehaviour
{
    [SerializeField] private Text scoreText;
    private static int reloadLevel;
    private static int scoreCount;
    private void Start() {
        scoreText.text = "Collected Melons: "+scoreCount;
    }
    public void restartLevel()
    {
        SceneManager.LoadScene(reloadLevel);
    }
    public void startScreen()
    {
        print("startLoaded");
        //SceneManager.LoadScene("startScreen");
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
