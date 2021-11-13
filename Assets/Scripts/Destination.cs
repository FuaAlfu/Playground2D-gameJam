using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Destination : MonoBehaviour
{
    /*
      Test script...
     using for racing levels
      */

    // Reference to checkpoint position
    [SerializeField]
    Transform checkpoint;

    [SerializeField]
    GameObject[] points;

    [SerializeField]
    Transform[] checkpoints;

    // Reference to UI text that shows the distance value
    [SerializeField]
    Text distanceText;

    // Calculated distance value
    private float distance;

    public bool distansY;
    public bool distansX;

    // Update is called once per frame
    private void Update()
    {
        //  distance = (checkpoint.transform.position.y - transform.position.y);
        DistanceX();
        DistanceY();
    }

    private void DistanceY()
    {
        if (distansY == true)
        {
            foreach (GameObject point in points)
                // Calculate distance value by y axis
                distance = (checkpoint.transform.position.y - transform.position.y);

            // Display distance value via UI text
            // distance.ToString("F1") shows value with 1 digit after period
            // so 12.234 will be shown as 12.2 for example
            // distance.ToString("F2") will show 12.23 in this case
            distanceText.text = "Goal: " + distance.ToString("F1") + " m";
            //------------------------------------------------------------------()Test
            //if (distance < 1000)
            //{
            //    distanceText.text = "Distance: " + distance.ToString("F1") + " meters";
            //}
            //  distanceText.text = "Distance: " + distance.ToString("F1") + " k";
            //--------------------------------------------------------------------()Test
            // If Cat reaches checkpoint then distance text shows "Finish!" word
            if (distance <= 0)
            {
                distanceText.text = "yes!";
            }
        }
    }

    private void DistanceX()
    {
        if (distansX == true)
        {
            // Calculate distance value by x axis
            distance = (checkpoint.transform.position.x - transform.position.x);

            // Display distance value via UI text
            // distance.ToString("F1") shows value with 1 digit after period
            // so 12.234 will be shown as 12.2 for example
            // distance.ToString("F2") will show 12.23 in this case
            distanceText.text = "Goal: " + distance.ToString("F1") + " m";
            //------------------------------------------------------------------()Test
            //if (distance < 1000)
            //{
            //    distanceText.text = "Distance: " + distance.ToString("F1") + " meters";
            //}
            //  distanceText.text = "Distance: " + distance.ToString("F1") + " k";
            //--------------------------------------------------------------------()Test
            // If Cat reaches checkpoint then distance text shows "Finish!" word
            if (distance <= 0)
            {
                distanceText.text = "yes!";
            }
        }
    }

    //--------------------------------------------------------(experiment)
    /*
       private void DistanceY()
    {
        if (distansY == true)
        {
            foreach(GameObject point in points)
            // Calculate distance value by y axis
            distance = (point..position.y - transform.position.y);

            // Display distance value via UI text
            // distance.ToString("F1") shows value with 1 digit after period
            // so 12.234 will be shown as 12.2 for example
            // distance.ToString("F2") will show 12.23 in this case
            distanceText.text = "Distance: " + distance.ToString("F1") + " meters";
            //------------------------------------------------------------------()Test
            //if (distance < 1000)
            //{
            //    distanceText.text = "Distance: " + distance.ToString("F1") + " meters";
            //}
            //  distanceText.text = "Distance: " + distance.ToString("F1") + " k";
            //--------------------------------------------------------------------()Test
            // If Cat reaches checkpoint then distance text shows "Finish!" word
            if (distance <= 0)
            {
                distanceText.text = "Finish!";
            }
        }
     */
}
