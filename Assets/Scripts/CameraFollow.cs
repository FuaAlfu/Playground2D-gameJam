using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 2021.11.12
/// </summary>
public class CameraFollow : MonoBehaviour
{
    /*
    Lerp allow us to trans from one point to another
    lerp is a build ui in unity

    a good quation
    How to make multiple boundaries for a game like megaman or metroid?
     if Using the same scene, you could add invisible trigger points,
   that when touched by the player will set new boundary values.
    */
    [SerializeField]
    private GameObject player;

    [SerializeField]
    private float timeOffset;  //speed control , of camera

    [SerializeField]
    private Vector2 posOffset;

    [SerializeField] private float leftLimit;
    [SerializeField] private float rightLimit;
    [SerializeField] private float bottomLimit;
    [SerializeField] private float topLimit;

    private Vector3 velocity;

    //extra :: for camera events
    [SerializeField]
    private float smoothTime = 0.3f;

    private Vector3 velocity_1 = Vector3.zero;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        //cameras current position
        Vector3 startPos = transform.position;

        //players current position 
        Vector3 endPos = player.transform.position;
        endPos.x += posOffset.x;
        endPos.y += posOffset.y;
        endPos.z = -10;

        //1: a regalur code to track the target..
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -10);

        //2: using lerp..
        transform.position = Vector3.Lerp(startPos, endPos, timeOffset * Time.deltaTime);

        //3: using smooth dampening
        //down here code start
        transform.position = Vector3.SmoothDamp(startPos, endPos, ref velocity, timeOffset);


        transform.position = new Vector3
        (
            Mathf.Clamp(transform.position.x, leftLimit, rightLimit),
            Mathf.Clamp(transform.position.y, bottomLimit, topLimit),
            transform.position.z
        );
    }

    private void OnDrawGizmos()
    {
        //draw a box around our camera boundary..
        Gizmos.color = Color.magenta;

        //top boundary line..
        Gizmos.DrawLine(new Vector2(leftLimit, topLimit), new Vector2(rightLimit, topLimit));
        //right boundary line...
        Gizmos.DrawLine(new Vector2(rightLimit, topLimit), new Vector2(rightLimit, bottomLimit));
        //bottom boundary line..
        Gizmos.DrawLine(new Vector2(rightLimit, bottomLimit), new Vector2(leftLimit, bottomLimit));
        //left boundary line..
        Gizmos.DrawLine(new Vector2(leftLimit, bottomLimit), new Vector2(leftLimit, topLimit));
    }
}
