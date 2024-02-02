using UnityEngine;

public class OpenURLOnTouch : MonoBehaviour
{
    public string urlToOpen = "https://www.example.com"; // Replace this with your desired URL

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("HandTag"))
        {
            OpenURL();
        }
    }

    private void OpenURL()
    {
        Application.OpenURL(urlToOpen);
    }
}
