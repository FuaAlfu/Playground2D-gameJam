using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 2021.11.13
/// </summary>

public class CleanUp : MonoBehaviour
{
    [SerializeField]
    private float timer = 2.1f;

    [Tooltip("harm pushing))")]
    [SerializeField]
    Vector2 pushAway = new Vector2(3.7f, 0);
    // Start is called before the first frame update

    PlayerController player;
    void Start()
    {
        player = FindObjectOfType<PlayerController>();
        Destroy(this.gameObject, timer);
    }

    private void OnCollisionEnter2D(Collision2D c)
    {
        if (c.gameObject.CompareTag("Player"))
        {
            player.rb2D.velocity = pushAway;
        }
    }
}
