using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.VR.Testing;
using Photon.VR;
using UnityEngine.UI;

public class ColorManager : MonoBehaviour
  {
    
    void Update()
    {
      RedText.text = Red.ToString();
      GreenText.text = Green.ToString();
      BlueText.text = Blue.ToString();

      BaseColor = new Color(Red, Green, Blue);
      PhotonVRManager.SetColour(BaseColor);
    }
    
    [SerializeField]
    public Color BaseColor;
    public float Red, Green, Blue;
    public bool Option1, Option2, Option3;
    public Text RedText, GreenText, BlueText;
  }