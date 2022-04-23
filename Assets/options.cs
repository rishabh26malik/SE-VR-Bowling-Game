using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class options : MonoBehaviour
{
    public AudioMixer audioMixer;

    public void BackFunction()
    {
        SceneManager.LoadScene(0);
    }

    public void SetVolume(float volume)
    {
        Debug.Log(volume);
        audioMixer.SetFloat("volume", volume);
    }

    public void SetGraphics(int quality)
    {
        Debug.Log(quality);
        QualitySettings.SetQualityLevel(quality);
    }
}
