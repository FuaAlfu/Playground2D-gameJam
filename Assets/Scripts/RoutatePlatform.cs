using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 2021.11.12
/// </summary>

public class RoutatePlatform : MonoBehaviour
{
    [Header("Routate Speed")]
    [Tooltip("speed of rotation")]
    [SerializeField]
    private float rotationSpeed;

    private GameObject player;
    private bool isContact;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Rotation();
    }

    void Rotation()
    {
        transform.Rotate(Vector3.back * rotationSpeed * Time.deltaTime);

        if (isContact == true)
        {
            player.transform.eulerAngles = new Vector3(0, 0, 0);
        }
    }
}
