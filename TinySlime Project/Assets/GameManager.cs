using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    public float cameraSpeed = 2;
    
    [SerializeField] Transform gameCamera;

    [HideInInspector]
    public MasterControls plControls;
    
    // INSTANCES
    public static GameManager instance = null;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        plControls = new MasterControls();

        plControls.Player.Movement.performed += context => MoveCamera(context);

        //joinAction.Enable();
        //joinAction.performed += context => JoinAction(context);

        //leaveAction.Enable();
        //leaveAction.performed += context => LeaveAction(context);

    }

    private void OnEnable()
    {
        plControls.Enable();
    }

    private void OnDisable()
    {
        plControls.Disable();
    }

    void Start()
    {
        Debug.Log("Finished loading singleton!");
    }

    void Update()
    {

        float moveX = plControls.Player.Movement.ReadValue<Vector2>().x;
        float moveY = plControls.Player.Movement.ReadValue<Vector2>().y;
        if (moveX > 0)
        {
            gameCamera.position += Vector3.right * Time.deltaTime * cameraSpeed;
        }
        if (moveX < 0)
        {
            gameCamera.position += Vector3.left * Time.deltaTime * cameraSpeed;
        }
        if (moveY > 0)
        {
            gameCamera.position += Vector3.up * Time.deltaTime * cameraSpeed;
        }
        if (moveY < 0)
        {
            gameCamera.position += Vector3.down * Time.deltaTime * cameraSpeed;
        }

    }

    void MoveCamera(InputAction.CallbackContext context)
    {
        

    }

}
