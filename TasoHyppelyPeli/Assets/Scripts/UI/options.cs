using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class options : MonoBehaviour
{
    public static float vol;
    [SerializeField] private Canvas background;
    [SerializeField] private Slider volumeSlider;
    [SerializeField] private PlayerMovement movement;
    [SerializeField] private PlayerCombat combat;
    [SerializeField] private PlayerAnimation anim;
    [SerializeField] private volumeButton button;
    private bool select;

    private void Awake() {
        if(AudioListener.pause)
        {
            button.changeSprite();
        }
        if(vol != 0)
        {
            AudioListener.volume=vol;
            volumeSlider.value=vol;
        }
        background.enabled = false;
        select=false;
    }
    private void Update() {
        if(Input.GetButtonDown("Submit") && select==false)
        {
            selectOptions();
        }
        else if(Input.GetButtonDown("Submit") && select==true)
        {
            closeOptions();
        }
        if(Input.GetButtonDown("Jump") && select==true)
        {
            mute();
        }
    }
    public void selectOptions()
     {
        volumeSlider.Select();
        select=true;
        movement.enabled=false;
        combat.enabled=false;
        anim.enabled=false;
        background.enabled = true;
        Time.timeScale = 0;
     }
    public void closeOptions()
    {
        select=false;
        movement.enabled=true;
        combat.enabled=true;
        anim.enabled=true;
        background.enabled = false;
        Time.timeScale = 1;
    }
    public void changeVolume()
    {
        AudioListener.volume=volumeSlider.value;
        vol = volumeSlider.value;
    }
    public void mute()
    {
        AudioListener.pause = !AudioListener.pause;
        button.changeSprite();
    }
}
