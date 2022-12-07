using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndMenu : MonoBehaviour
{
    [SerializeField] private Button _quit;
    private void Awake() {
        _quit.Select();
    }
    private void Update() {
        if(Input.GetButtonDown("Jump"))
        {
            quit();
        }
    }
    public void quit()
    {
        Application.Quit();
    }
    
}
