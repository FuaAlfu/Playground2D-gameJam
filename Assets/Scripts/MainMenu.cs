using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// 2021.11.13
/// </summary>
public class MainMenu : MonoBehaviour
{
    [SerializeField]
    int sceneIndex;

    [SerializeField]
    AudioClip hover, click;

    AudioSource audioSource;

    private void Start()
    {
        Time.timeScale = 1f;

        audioSource = GetComponent<AudioSource>();
    }

    public void PlayOnHaver()
    {
        audioSource.PlayOneShot(hover);
    }

    public void PlayOnClick()
    {
        audioSource.PlayOneShot(click);
    }

    public void Play()
    {
        SceneManager.LoadScene(sceneIndex);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
