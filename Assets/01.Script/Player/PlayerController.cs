using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public float jumpPower;
    public float cameraSensitive;
    public float maxCameraAngle;
    public float minCameraAngle;
    public float curCameraAngle;
    private Vector3 destAngle;
    private Vector2 mouseDelta;
    public Transform cameraContainer;
    public LayerMask groundLayer;

    private Vector2 curMovement;

    private Rigidbody rigid;
    private Player player;
    private PortalGun portalGun;

    private const float rotateSmoothCoef = 20f;

    StageManager stageManager;

    private void Awake()
    {
        player = GetComponent<Player>();
        rigid = GetComponent<Rigidbody>();
        portalGun = GetComponent<PortalGun>();
        destAngle = cameraContainer.transform.eulerAngles;
    }

    private void Start()
    {
        stageManager = GameManager.Instance.StageManager;
        //Cursor.lockState = CursorLockMode.Locked;
    }

    private void FixedUpdate()
    {
        Move();
        Stand();
    }

    private void Stand()
    {
        // 현재 회전을 오일러 각도로 변환
        Vector3 currentEuler = transform.eulerAngles;

        // 목표 회전: X축은 유지, YZ는 0
        Vector3 targetEuler = new Vector3(0, currentEuler.y, 0f);
        
        // 오일러 -> 쿼터니언으로 변환해서 보간
        Quaternion currentRotation = transform.rotation;
        Quaternion targetRotation = Quaternion.Euler(targetEuler);

        // Lerp로 부드럽게 회전
        transform.rotation = Quaternion.Lerp(currentRotation, targetRotation, Time.deltaTime * 15);
    }

    private void LateUpdate()
    {
        if (Stage.Instance.IsPaused) return;
        Look();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            curMovement = context.ReadValue<Vector2>();
        }
        else if (context.phase == InputActionPhase.Canceled)
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
        if (context.phase == InputActionPhase.Started && IsGround())
        {
            rigid.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
        }
    }


    public void OnLook(InputAction.CallbackContext context)
    {
        //if (stageManager.IsCleared) return;
        mouseDelta = context.ReadValue<Vector2>();
    }

    private void Look()
    {
        Vector3 cameraAngle = cameraContainer.localEulerAngles;
        Vector3 transformAngle = transform.eulerAngles;

        destAngle.x -= mouseDelta.y * cameraSensitive;
        destAngle.x = Mathf.Clamp(destAngle.x, -90f, 90f);
        cameraAngle.x = Mathf.LerpAngle(cameraAngle.x, destAngle.x, rotateSmoothCoef * Time.deltaTime);

        destAngle.y += mouseDelta.x * cameraSensitive;
        destAngle.y = AngleCalculator.NormalizeAngle360(destAngle.y);
        transformAngle.y = Mathf.LerpAngle(transformAngle.y, destAngle.y, rotateSmoothCoef * Time.deltaTime);

        cameraContainer.localEulerAngles = cameraAngle;
        transform.eulerAngles = transformAngle;
    }

    private bool IsGround()
    {
        Ray[] ray = new Ray[4]
        {
            new Ray(transform.position + (transform.forward * 0.2f) + transform.up * 0.01f, Vector3.down),
            new Ray(transform.position + (-transform.forward * 0.2f) + transform.up * 0.01f, Vector3.down),
            new Ray(transform.position + (transform.right * 0.2f) + transform.up * 0.01f, Vector3.down),
            new Ray(transform.position + (-transform.right * 0.2f) + transform.up * 0.01f, Vector3.down),
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
        if (context.phase == InputActionPhase.Started)
        {
            player.SpawnBomb();
        }
    }

    public void SwapBomb1(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)
        {
            player.SwapBomb(1);
        }
    }

    public void SwapBomb2(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)
        {
            player.SwapBomb(2);
        }
    }

    public void SwapBomb3(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)
        {
            player.SwapBomb(3);
        }
    }

    public void SwapBomb4(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)
        {
            player.SwapBomb(4);
        }
    }

    public void SwapBomb5(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)
        {
            player.SwapBomb(5);
        }
    }



    public void KeyDownEsc(InputAction.CallbackContext context)
    {
        if (Stage.Instance.IsCleared) return;
        if (context.phase == InputActionPhase.Started)
        {
            if (Stage.Instance.IsPaused)
                Stage.Instance.ResumeStage();
            else
                Stage.Instance.PauseStage();
        }
    }

    public void ShotPortal(InputAction.CallbackContext context)
    {
        if (Stage.Instance.IsCleared) return;
        if (context.phase == InputActionPhase.Started)
        {
            if(portalGun)
                portalGun.Shot();
        }
    }

    public void ChangeLookDirection(Quaternion portalRotDiff)
    {
        Quaternion currentRotation = Quaternion.Euler(destAngle);  // 오일러 → 쿼터니언
        Quaternion newRotation = portalRotDiff * currentRotation;  // 회전 적용
        destAngle = newRotation.eulerAngles;                       // 다시 오일러로 저장
    }
}