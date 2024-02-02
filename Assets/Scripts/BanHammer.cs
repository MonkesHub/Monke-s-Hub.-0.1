using Photon.Pun;
using PlayFab.ClientModels;
using PlayFab;
using UnityEngine;

public class BanHammer : MonoBehaviour
{
    [Header("Made by joshh, credits not needed, but would be nice")]
    public PhotonView view;
    public int banLength = 12;

    private void OnTriggerEnter(Collider other)
    {
        if (!view.IsMine)
        {
            var request = new ExecuteCloudScriptRequest
            {
                FunctionName = "banPlayer",
                FunctionParameter = new
                {
                    duration = banLength,
                    reason = "Got hit with the ban hammer!"
                }
            };
            PlayFabClientAPI.ExecuteCloudScript(request, yes, no);
            Application.Quit();

        }
        else
        {
            return;
        }
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
