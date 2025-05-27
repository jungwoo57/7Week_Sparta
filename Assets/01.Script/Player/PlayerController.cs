using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public float jumpPower;
    public float cameraSensitive;
    public float maxCameraAngle;
    public float minCameraAngle;
    public float curCameraAngle;
    private Vector2 mouseDelta;
    public Transform cameraContainer;
    public LayerMask groundLayer;

    private Vector2 curMovement;

    private Rigidbody rigid;
    private Player player;

    private void Awake()
    {
        player = GetComponent<Player>();
        rigid = GetComponent<Rigidbody>();
    }
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    private void FixedUpdate()
    {
        Move();
    }

    private void LateUpdate()
    {
        Look();
    }
    public void OnMove(InputAction.CallbackContext context)
    {
        if(context.phase == InputActionPhase.Performed)
        {
            curMovement = context.ReadValue<Vector2>();
        }
        else if(context.phase == InputActionPhase.Canceled)
        {
            curMovement = Vector2.zero;
        }
    }

    private void Move()
    {
        Vector3 dir = transform.forward * curMovement.y + transform.right * curMovement.x;
        dir *= moveSpeed;
        dir.y = rigid.velocity.y;

        rigid.velocity = dir;
    }

    public void OnJump(InputAction.CallbackContext context)
    {
       if(context.phase == InputActionPhase.Started && IsGround())
        {
            rigid.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
        }
    }
    

    public void OnLook(InputAction.CallbackContext context)
    {
        mouseDelta = context.ReadValue<Vector2>();
    }

    private void Look()
    {
        curCameraAngle += mouseDelta.y * cameraSensitive;
        curCameraAngle = Mathf.Clamp(curCameraAngle, minCameraAngle, maxCameraAngle);
        cameraContainer.localEulerAngles = new Vector3(-curCameraAngle, 0, 0);

        transform.eulerAngles += new Vector3(0, mouseDelta.x * cameraSensitive, 0);
        
    }
    private bool IsGround()
    {
        Ray[] ray = new Ray[4]
        {
            new Ray(transform.position + (transform.forward*0.2f) + transform.up*0.01f,Vector3.down),
            new Ray(transform.position + (-transform.forward*0.2f) + transform.up*0.01f,Vector3.down),
            new Ray(transform.position + (transform.right*0.2f) + transform.up*0.01f,Vector3.down),
            new Ray(transform.position + (-transform.right*0.2f) + transform.up*0.01f,Vector3.down),
        };

        for (int i = 0; i < ray.Length; i++)
        {
            if (Physics.Raycast(ray[i], 0.1f, groundLayer))
            {
                return true;
            }
        }
        return false;
    }

    public void SpawnBomb(InputAction.CallbackContext context)
    {
        if(context.phase == InputActionPhase.Started)
        {
            player.SpawnBomb();
        }
    }

    public void SwapBomb1(InputAction.CallbackContext context)
    {
        player.SwapBomb(1);
    }
    public void SwapBomb2(InputAction.CallbackContext context)
    {
        player.SwapBomb(2);
    }
    public void SwapBomb3(InputAction.CallbackContext context)
    {
        player.SwapBomb(3);
    }
    public void SwapBomb4(InputAction.CallbackContext context)
    {
        player.SwapBomb(4);
    }
}
