using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class options : MonoBehaviour
{
    [SerializeField] private Canvas background;
    [SerializeField] private Slider volumeSlider;

    private void Awake() {
        background.enabled = false;
    }
    public void selectOptions()
     {
        background.enabled = true;
        Time.timeScale = 0;
     }
    public void closeOptions()
    {
        background.enabled = false;
        Time.timeScale = 1;
    }
    public void changeVolume()
    {
        AudioListener.volume=volumeSlider.value;
    }
    public void mute()
    {
        AudioListener.pause = !AudioListener.pause;
    }
}
