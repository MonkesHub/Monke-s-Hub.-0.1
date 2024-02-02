using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonmanager : MonoBehaviour
{
    public int Buttons;
    public int ButtonsPressed;
    public GameObject[] enable;
    public GameObject[] disable;

    void Update()
    {
        if(ButtonsPressed == Buttons)
        {
            foreach (GameObject obj in enable)
            {
                obj.SetActive(true);
            }
            foreach (GameObject obj in disable)
            {
                obj.SetActive(false);
            }
        }
    }

    public void PressedButton()
    {
        ButtonsPressed += 1;
    }
}
