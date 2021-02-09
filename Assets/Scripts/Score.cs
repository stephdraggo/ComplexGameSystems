using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Score : MonoBehaviour
{
    List<Joint> joints;
    float forceBeingApplied=0;
    float maxForce;
    [SerializeField]Text scoreText;
    int points;

    void Start()
    {
        joints = new List<Joint>(GetComponentsInChildren<Joint>());

        
    }


    void FixedUpdate()
    {

        forceBeingApplied = 0;
        foreach (Joint joint in joints)
        {
             forceBeingApplied += joint.currentForce.magnitude;
        }

        if (forceBeingApplied > 1000)
        {
            maxForce += forceBeingApplied;

            points = (int)maxForce / 10;

        }
        scoreText.text = points.ToString() + " points";
    }
}
