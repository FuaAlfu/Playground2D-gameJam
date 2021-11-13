using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 2021.11.12
/// </summary>

public class TimePickUp : MonoBehaviour
{
    [Header("main")]
    [Tooltip("adjust all")]
    [SerializeField]
    private float timeToAdd = 5;

    [SerializeField]
    private float timeStamp;

    [SerializeField]
    private AudioClip timePikUpSFX;

    [SerializeField]
    private GameObject parcPrefab;

    private Rigidbody2D rb;

    private GameObject playerControler;

    private Vector2 playerDirection;


    private bool flyToPlayer;

    private Camera camera;

    private void Start()
    {
        camera = FindObjectOfType<Camera>(); //Camera.main

        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (flyToPlayer)
        {
            playerDirection = -(transform.position - playerControler.transform.position).normalized;
            rb.velocity = new Vector2(playerDirection.x, playerDirection.y) * 10f * (Time.time / timeStamp);

        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            print("yo0");
            GameSession.Instance.IncreaseTime(timeToAdd);
            // playerSvx.CoinPickUpSfx();

            AudioSource.PlayClipAtPoint(timePikUpSFX, camera.transform.position);
         //   GameObject parc = Instantiate(parcPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

        //Notice.. Need To add rigidbody to the coin object
        //if (other.gameObject.CompareTag("coinMagnet"))
        //{
        //    print("yo");
        //    timeStamp = Time.time;
        //    playerControler = GameObject.Find("Player");
        //    flyToPlayer = true;
        //}
    }

   
}
