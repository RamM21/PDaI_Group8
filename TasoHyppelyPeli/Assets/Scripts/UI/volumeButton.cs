using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class volumeButton : MonoBehaviour
{
    [SerializeField] private Sprite on;
    [SerializeField] private Sprite off;
    [SerializeField] private Button button;
    private bool selected=false;

    public void changeSprite()
    {
        if(selected==false)
        {
            button.image.sprite = off;
            selected=true;
        }else
        {
            button.image.sprite = on;
            selected=false;
        }
    }
}
