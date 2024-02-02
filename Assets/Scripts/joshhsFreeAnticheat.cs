using PlayFab;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class joshhsFreeAnticheat : MonoBehaviour
{
    [Header("Made by joshh, discord.gg/jungletag  Give credits!")]
    [Space]
    [SerializeField] private GameObject playfabLogin;
    [SerializeField] private Playfablogin login;
    [SerializeField] private string playfabTitleId = "Your title ID";
    [SerializeField] private string appName = "com.COMPANYNAME.GAMENAME";
    [SerializeField] private string FolderPath = "/storage/emulated/0/Android/data/com.YOURCOMPANY.YOURGAMENAME/files/Mods";

    private void Start()
    {


        if (login == null || playfabLogin == null)
        {
            Debug.Log("Playfab is missing! Quitting Game!");
            Application.Quit();
        }

        string CurrentPackageName = Application.identifier;

        if (CurrentPackageName != appName)
        {
            Debug.Log("Modded APK");
            Application.Quit();
        }

        if (Directory.Exists(FolderPath))
        {
            Debug.Log("Mods detected!");
            Application.Quit();
        }

        if (Application.internetReachability != NetworkReachability.NotReachable)
        {
            StartCoroutine(checkTitleID());
        }
        else
        {
            Debug.Log("Not connected to the internet!");
        }
    }
    private IEnumerator checkTitleID()
    {
        yield return new WaitForSeconds(10);
        if (PlayFabSettings.TitleId != playfabTitleId)
        {
            Debug.Log("Wrong title ID! Quitting Game!");
            Application.Quit();
        }
    }
}
