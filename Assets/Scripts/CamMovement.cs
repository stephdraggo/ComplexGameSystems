using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMovement : MonoBehaviour
{
    [SerializeField,Tooltip("attach hips")] private GameObject ragdoll;
    [SerializeField] private Camera cam;
    void Start()
    {
        cam = GetComponent<Camera>();
    }

    void Update()
    {
        cam.transform.LookAt(ragdoll.transform);
    }
}
