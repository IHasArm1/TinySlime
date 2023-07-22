using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAll : MonoBehaviour
{
    public bool isHolding;

    private bool isDragging;

    private Transform dragging = null;
    private Vector3 offset;

    private Transform HeldObject;

    [SerializeField] private LayerMask moveableLayers;

    RaycastHit2D hit;

    RaycastHit2D lastHit;


    public Transform ObjectMenu;

    private Transform CurrentTarget;

    // Update is called once per frame
    void Update()
    {

        if (!isHolding && !isDragging)
        {
            if (Input.GetMouseButtonDown(1))
            {
                //do a raycast
                hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero,
                float.PositiveInfinity, moveableLayers);
                OpenObjectMenu(hit.transform);
            }
        }

        //Dragging Code

        if (!isHolding)
        {
            if (Input.GetMouseButtonDown(0))
            {
                //do a raycast
                hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero,
                float.PositiveInfinity, moveableLayers);
                if (hit)
                {
                    isDragging = true;
                    //if I hit then record the transform of the object it hits
                    lastHit = hit;
                    dragging = hit.transform;
                    //then record the offset;
                    offset = dragging.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
                }

            }
            else if (Input.GetMouseButtonUp(0))
            {
                //stop dragging
                isDragging = false;
                dragging = null;
                if (lastHit)
                {
                    lastHit.transform.GetComponent<SlimeScript>().canMove = true;
                }

            }

            if (dragging != null)
            {
                //move object taking into account original offset

                dragging.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;
                if (lastHit)
                {
                    lastHit.transform.GetComponent<SlimeScript>().canMove = false;
                }
            }
        }

        //Holding Code
        if (isHolding)
        {
            HeldObject.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;
        }


    }

    public void HoldObject(Transform ObjectTransform)
    {
        if(isDragging) { Debug.Log("Returned"); return; }
        isHolding = true;
        HeldObject = ObjectTransform;

    }

    public void OpenObjectMenu(Transform TargetTransform)
    {
        CurrentTarget = TargetTransform;
        ObjectMenu.gameObject.SetActive(true);
        ObjectMenu.position = Camera.main.WorldToScreenPoint(TargetTransform.position);
    }

    public void CloseObjectMenu()
    {
        ObjectMenu.gameObject.SetActive(false);
    }

    public void DeleteObjectWithMenu()
    {
        Destroy(CurrentTarget);
    }

}
