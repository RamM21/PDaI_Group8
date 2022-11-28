using UnityEngine;
using UnityEngine.SceneManagement;
public class gameOver : MonoBehaviour
{
    private int reloadLevel;
    private void Start() {
        reloadLevel = SceneManager.GetActiveScene().buildIndex - 1;
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
}
