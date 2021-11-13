using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 2021.11.13
/// </summary>
public class Enemy : MonoBehaviour
{
    [SerializeField]
    private Transform hand;

    [SerializeField]
    private GameObject rock;

    [SerializeField]
    private float rockSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Throw()
    {
        GameObject g = Instantiate(rock, hand.position, Quaternion.identity) as GameObject;
        g.GetComponent<Rigidbody2D>().velocity = new Vector2(-rockSpeed, 3.2f);
    }
}
