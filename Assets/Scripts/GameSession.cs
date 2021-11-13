using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// 2021.11.12
/// </summary>

public class GameSession : MonoBehaviour
{
    public static GameSession Instance;
    //-----------------------------------------(time)

    [SerializeField]
    GameObject player;

    [SerializeField]
    private Transform goal;

    [SerializeField]
    private GameObject winParticle;

    public GameObject gameOverUI,winUI, pasuedMenu;

    public bool gameIsPaused;
    [SerializeField]
    float timeAmount;

    [SerializeField]
    float secondToSub;

    [SerializeField] 
    private float timeToAdd = 0f;

    //catche
    public Text timeText;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    private void Start()
    {
        timeAmount = 30f;
        secondToSub = 1f;
        timeText.text = timeAmount.ToString();
    }

    private void Update()
    {
        timeText.text = (int)timeAmount + "";
        timeAmount -= secondToSub * Time.deltaTime;
        if (timeAmount <= 0)
        {
            Invoke("Timesout", .1f);
        }
    }

    public void IncreaseTime(float time)
    {
        timeAmount += time;
        timeText.text = timeAmount.ToString();
    }

    public void Timesout()
    {
        gameOverUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
        // player.SetActive(false);
    }

    public void NewGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
        gameIsPaused = false;
        //  player.SetActive(true);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Win()
    {
        GameObject g = Instantiate(winParticle, goal.position, Quaternion.identity) as GameObject;
         winUI.SetActive(true);
        StartCoroutine(Timing());


    }

    IEnumerator Timing()
    {
        yield return new WaitForSeconds(0.7f);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }

    public void PauseGame()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && gameIsPaused)
        {
            pasuedMenu.SetActive(false);
            Time.timeScale = 1;
            gameIsPaused = false;
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            pasuedMenu.SetActive(true);
            Time.timeScale = 0;
            gameIsPaused = true;
        }
    }
}
