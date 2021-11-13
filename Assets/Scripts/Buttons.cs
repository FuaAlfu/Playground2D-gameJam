using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 2021.11.13
/// </summary>

public class Buttons : MonoBehaviour
{

    [SerializeField]
    AudioClip hover, click;

    AudioSource audioSource;

    private void Start()
    {
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
}
