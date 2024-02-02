using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class HitSoundsv2 : MonoBehaviour
{
    public AudioClip[] Water, stone, tree, grass, metal, glass, snow, dirt, carpet, wood;
    public AudioSource audioSource;
    public bool LeftController;
    private float hapticWaitSeconds = 0.05f;
    Dictionary<string, AudioClip[]> audio;
    
    void Start() { 
        audio = new Dictionary<string, AudioClip[]> {
            { "Water", Water },
            { "Stone", stone },
            { "Tree", tree },
            { "Grass", grass },
            { "Metal", metal },
            { "Glass", glass },
            { "Snow", snow },
            { "Dirt", dirt },
            { "Carpet", carpet },
            { "Wood", wood },
            
        };
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayRandomSound(audio[other.gameObject.tag], audioSource);
        StartVibration(LeftController, 0.15f, 0.15f);
    }

    void PlayRandomSound(AudioClip[] audioClips, AudioSource audioSource)
    {
        audioSource.clip = audioClips[Random.Range(0, audioClips.Length)];
        audioSource.Play();
    }

    public void StartVibration(bool forLeftController, float amplitude, float duration)
    {
        StartCoroutine(HapticPulses(forLeftController, amplitude, duration));
    }

    private IEnumerator HapticPulses(bool forLeftController, float amplitude, float duration)
    {
        float startTime = Time.time;
        uint channel = 0u;
        InputDevice device = ((!forLeftController) ? InputDevices.GetDeviceAtXRNode(XRNode.RightHand) : InputDevices.GetDeviceAtXRNode(XRNode.LeftHand));
        while (Time.time < startTime + duration)
        {
            device.SendHapticImpulse(channel, amplitude, hapticWaitSeconds);
            yield return new WaitForSeconds(hapticWaitSeconds * 0.9f);
        }
    }
}