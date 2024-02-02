using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorButton : MonoBehaviour
{
    
    public ColorManager scipt;
    public string Key;
 

    public void OnTriggerEnter(Collider other) {
         if (other.gameObject.tag == "HandTag") 
         {
            if (scipt.Option1 == true) {
            
                if (Key == "Key0") {
                   scipt.Red = 0f;
                }
                if (Key == "Key1") {
                   scipt.Red = 0.1f;
                }
                if (Key == "Key2") {
                   scipt.Red = 0.2f;
                }
                if (Key == "Key3") {
                   scipt.Red = 0.3f;
                }
                if (Key == "Key4") {
                   scipt.Red = 0.4f;
                }
                if (Key == "Key5") {
                   scipt.Red = 0.5f;
                }
                if (Key == "Key6") {
                   scipt.Red = 0.6f;
                }
                if (Key == "Key7") {
                   scipt.Red = 0.7f;
                }
                if (Key == "Key8") {
                   scipt.Red = 0.8f;
                }
                if (Key == "Key9") {
                   scipt.Red = 0.9f;
                }
            }


            if (scipt.Option3 == true) {
                if (Key == "Key0") {
                   scipt.Blue = 0f;
                }
                if (Key == "Key1") {
                   scipt.Blue = 0.1f;
                }
                if (Key == "Key2") {
                   scipt.Blue = 0.2f;
                }
                if (Key == "Key3") {
                   scipt.Blue = 0.3f;
                }
                if (Key == "Key4") {
                   scipt.Blue = 0.4f;
                }
                if (Key == "Key5") {
                   scipt.Blue = 0.5f;
                }
                if (Key == "Key6") {
                   scipt.Blue = 0.6f;
                }
                if (Key == "Key7") {
                   scipt.Blue = 0.7f;
                }
                if (Key == "Key8") {
                   scipt.Blue = 0.8f;
                }
                if (Key == "Key9") {
                   scipt.Blue = 0.9f;
                }
            }
               
            if (scipt.Option2 == true) {
                if (Key == "Key0") {
                   scipt.Green = 0f;
                }
                if (Key == "Key1") {
                   scipt.Green = 0.1f;
                }
                if (Key == "Key2") {
                   scipt.Green = 0.2f;
                }
                if (Key == "Key3") {
                   scipt.Green = 0.3f;
                }
                if (Key == "Key4") {
                   scipt.Green = 0.4f;
                }
                if (Key == "Key5") {
                   scipt.Green = 0.5f;
                }
                if (Key == "Key6") {
                   scipt.Green = 0.6f;
                }
                if (Key == "Key7") {
                   scipt.Green = 0.7f;
                }
                if (Key == "Key8") {
                   scipt.Green = 0.8f;
                }
                if (Key == "Key9") {
                   scipt.Green = 0.9f;
                }
            }

            if (Key == "Option1") {
               scipt.Option1 = true; scipt.Option2 = false; scipt.Option3 = false;
               }
            if (Key == "Option2") {
               scipt.Option1 = false; scipt.Option2 = true; scipt.Option3 = false;
            }
            if (Key == "Option3") {
               scipt.Option1 = false; scipt.Option2 = false; scipt.Option3 = true;
            }
         }

    }
}
