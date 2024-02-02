using Photon.Pun;
using PlayFab.ClientModels;
using PlayFab;
using UnityEngine;
using Photon.VR;
using System.Collections;

public class BanManager : MonoBehaviour
{
    [Header("Made by joshh")]

    [Space]
    [Header("Banned room codes, and names.  It will ban them if the room/name contains the banned word in it.")]
    public string[] bannedStuff;
    public int BanLengthRoom = 5;
    public int BanLengthName = 10;

    [Space]
    [Header("The ban lengths for the room codes and bad names")]
    private string CurrentRoom;
    private string CurrentName;
    public string roomReason = "Banned room code!";
    public string nameReason = "Banned name!";

    private void Update()
    {
        CurrentName = PlayerPrefs.GetString("username");
        if (PhotonNetwork.InRoom)
        {
            CurrentRoom = PhotonNetwork.CurrentRoom.Name;
            foreach (var bannedrooms in bannedStuff)
            {
                if (CurrentRoom.Contains(bannedrooms))
                {
                    StartCoroutine(Kick());
                    var request = new ExecuteCloudScriptRequest
                    {
                        FunctionName = "banPlayer",
                        FunctionParameter = new
                        {
                            duration = BanLengthRoom,
                            reason = roomReason
                        }
                    };
                    PlayFabClientAPI.ExecuteCloudScript(request, yes, no);
                }
            }
        }
        CurrentName = PhotonNetwork.LocalPlayer.NickName;
        foreach (var bannednames in bannedStuff)
        {
            if (CurrentName.Contains(bannednames))
            {
                StartCoroutine(Kick());
                var request = new ExecuteCloudScriptRequest
                {
                    FunctionName = "banPlayer",
                    FunctionParameter = new
                    {
                        duration = BanLengthName,
                        reason = nameReason
                    }
                };
                PlayFabClientAPI.ExecuteCloudScript(request, yes, no);
                
            }
        }
        
    }

    private IEnumerator Kick()
    {
        
        PlayerPrefs.SetString("username", "BANNEDBEFORE");
        if (PhotonNetwork.InRoom)
        {
            PhotonVRManager.SetUsername("BANNEDBEFORE");
        }
        yield return new WaitForSeconds(1f);
        string NameChangeTo = "BANNEDBEFORE";

        var request = new UpdateUserTitleDisplayNameRequest()
        {
            DisplayName = NameChangeTo,
        };
        PlayFabClientAPI.UpdateUserTitleDisplayName(request, UpdatedName, ErrorUpdatingName);
        PhotonNetwork.Disconnect();
        Application.Quit();
        yield return new WaitForSeconds(1f);
    }
    void UpdatedName(UpdateUserTitleDisplayNameResult result)
    {
        Debug.Log("Updated Playfab Display Name");
    }

    void ErrorUpdatingName(PlayFabError error)
    {
        Debug.Log("Error updating Playfab Display Name!");
    }


    private void yes(ExecuteCloudScriptResult result)
    {
        Debug.Log("Ban Successful: " + result.FunctionResult.ToString());
    }

    private void no(PlayFabError result)
    {
        Debug.LogError("Ban Unsuccessful: " + result.ErrorMessage.ToString());
    }
}
