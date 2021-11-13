using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// 2021.11.13
/// </summary>

public class Splash : MonoBehaviour
{
    [SerializeField]
    int sceneIndex;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(PlayScene());
    }


    IEnumerator PlayScene()
    {
        yield return new WaitForSeconds(1f);
        Play();
    }

    private void Play()
    {
        SceneManager.LoadScene(sceneIndex);
    }
}
