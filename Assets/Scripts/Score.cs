using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Score : MonoBehaviour
{
    List<Joint> joints;
    float forceBeingApplied = 0;
    float maxForce;
    [SerializeField] Text scoreText;
    int points;
    private ClickDrag clickDrag;
    void Start()
    {
        joints = new List<Joint>(GetComponentsInChildren<Joint>());

        clickDrag = FindObjectOfType<ClickDrag>();
    }

    void FixedUpdate()
    {
        forceBeingApplied = 0;
        if (clickDrag.DragObject == null)
        {
            foreach (Joint joint in joints)
            {
                forceBeingApplied += joint.currentForce.magnitude;
            }
        }

        if (forceBeingApplied > 1000)
        {
            maxForce += forceBeingApplied;

            points = (int)maxForce / 10;


        }
        scoreText.text = points.ToString() + " points";
    }
}
