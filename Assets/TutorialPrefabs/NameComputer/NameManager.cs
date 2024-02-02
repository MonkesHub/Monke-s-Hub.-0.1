using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;
using Photon.VR;

public class NameManager : MonoBehaviour
{
    [Header("made by joshh, please give credits")]
    public bool isChar;
    public bool isBack;
    public bool isEnter;
    [Header("Only fill in the string if isChar is on")]
    public string charKey;
    public TextMeshPro nameText;
    public int maxNameLength = 15;
    public string HandTag = "HandTag";

    private void Start()
    {
        if (PlayerPrefs.GetString("username") == null)
        {
            PlayerPrefs.SetString("username", "Monke" + Random.Range(1000, 9999));
            nameText.text = PlayerPrefs.GetString("username");
            PhotonVRManager.SetUsername(nameText.text);
        }
        else
        {
            nameText.text = PlayerPrefs.GetString("username");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(HandTag))
        {
            if (isChar)
            {
                if (nameText.text.Length >= maxNameLength)
                {
                    Debug.Log("Max limt reached!");
                }
                else
                {
                    nameText.text = nameText.text + charKey;
                }
            }

            if (isBack)
            {
                nameText.text = nameText.text.Remove(nameText.text.Length - 1);
            }
            if (isEnter)
            {
                PhotonVRManager.SetUsername(nameText.text);
                PlayerPrefs.SetString("username", nameText.text);
            }
        }
    }
}
