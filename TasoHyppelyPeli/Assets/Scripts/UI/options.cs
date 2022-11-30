using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class options : MonoBehaviour
{
    [SerializeField] private Canvas background;

    private void Awake() {
        background.enabled = false;
    }
    public void selectOptions()
     {
        background.enabled = true;
        Time.timeScale = 0;
        AudioListener.pause = true;
     }
    public void closeOptions()
    {
        background.enabled = false;
        Time.timeScale = 1;
        AudioListener.pause = false;
    }
}
