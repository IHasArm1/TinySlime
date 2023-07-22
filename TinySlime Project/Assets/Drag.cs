using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag : MonoBehaviour
{
    private bool dragging = false;
    private Vector3 offset;

    private float orgZ;

    private void Start()
    {
        orgZ = transform.position.z;
    }

    private void Update()
    {
        if(dragging)
        {
            //Move object, taking into account original offset
            Vector2 mousePoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(mousePoint.x, mousePoint.y, orgZ);
        }
    }

    private void OnMouseDown()
    {
        //Record the difference between the objects center and then clicked point on the camera plane
        offset = transform.position + Camera.main.ScreenToWorldPoint(Input.mousePosition);
        dragging = true;
    }

    private void OnMouseUp()
    {
        //stop dragging
        dragging = false;
    }
}
