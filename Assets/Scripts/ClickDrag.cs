using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickDrag : MonoBehaviour
{
    Transform dragObject;
    Vector3 offset;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;

            if(Physics.Raycast(ray,out hit, Mathf.Infinity))
            {
                dragObject = hit.transform;
                offset = hit.transform.position - ray.origin;
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            dragObject = null;
        }
    }

    private void FixedUpdate()
    {
        if (dragObject)
        {
            Vector3 newOffset = new Vector3(offset.x, offset.y,-dragObject.position.z);
            dragObject.position += newOffset * Time.deltaTime;
        }
    }
}
