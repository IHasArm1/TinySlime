using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class InteractableObject : MonoBehaviour
{
    Camera _camera;
    MasterControls plControls;

    public float interactRange;

    Vector2 mousePos;

    public UnityEvent OnInRange;

    private void Awake()
    {
        plControls = new MasterControls();
        _camera = Camera.main;
    }

    private void OnEnable()
    {
        plControls.Enable();
    }

    private void OnDisable()
    {
        plControls.Disable();
    }

    void Update()
    {
        // gets mouseposition in the actual world not in screen view
        mousePos = _camera.ScreenToWorldPoint(plControls.Player.MousePosition.ReadValue<Vector2>());

        // manually creates a range the mouse has to be in to execute something
        if (mousePos.x > transform.position.x - interactRange && mousePos.x < transform.position.x + interactRange &&
            mousePos.y > transform.position.y - interactRange && mousePos.y < transform.position.y + interactRange)
        {
            OnInRange.Invoke();
        }
    }

    public void DestroyObject()
    {
        Debug.Log("IN RANGE");
        Destroy(gameObject);
    }

}
