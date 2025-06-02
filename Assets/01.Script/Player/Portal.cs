using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    [SerializeField]
    private Camera portalCamera;
    [SerializeField]
    private GameObject portalCameraContainer;
    [SerializeField]
    private Renderer portalTextureRenderer;

    public Material portalCameraMaterial;

    private PortalGun portalGun;
    private Transform playerPos;
    private Portal partnerPortal;

    Material originalMaterial;

    public bool IsActivated { get; private set; }
    private bool hasTransferred;

    private void Awake()
    {
        hasTransferred = false;
        portalCameraContainer.SetActive(false);
        IsActivated = false;
        originalMaterial = portalTextureRenderer.material;
    }

    private void Start()
    {
        // 무조건 플레이어가 쏘기 때문에 null이 되면 넌센스
        playerPos = Stage.Instance.player.transform;
    }

    void Update()
    {
        if (IsActivated)
        {
            Vector3 posDiff = playerPos.position - transform.position;
            portalCamera.transform.position = posDiff;
            portalCamera.nearClipPlane = posDiff.magnitude + 0.3f;
        }
    }

    public void Init(PortalGun _portalGun, Portal anotherPortal)
    {
        portalGun = _portalGun;
        partnerPortal = anotherPortal;
    }

    public void SetRenderTexture(RenderTexture renderTexture, Material cameraMaterial)
    {
        portalCamera.targetTexture = renderTexture;
        partnerPortal.portalCameraMaterial = cameraMaterial;
    }

    public void ActivatePortal()
    {
        portalCameraContainer.SetActive(true);
        portalTextureRenderer.material = portalCameraMaterial;
    }

    public void DeactivatePortal()
    {
        portalCameraContainer.SetActive(false);
        portalTextureRenderer.material = originalMaterial;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (portalGun.hasTransferred)
            {
                portalGun.hasTransferred = false;
                return;
            }

            other.transform.position = partnerPortal.transform.position + (other.transform.position - transform.position);

            Quaternion oppositeRotation = Quaternion.Euler(0, 180, 0) * transform.rotation; // 포탈의 뒷면방향
            Quaternion portalRotDiff = partnerPortal.transform.rotation * Quaternion.Inverse(oppositeRotation); // 상대 포탈의 앞방향과 각도 차이
            
            other.transform.rotation= portalRotDiff * other.transform.rotation;
            
            other.GetComponent<PlayerController>().ChangeLookDirection(portalRotDiff);

            portalGun.hasTransferred = true;
        }
    }

    // private void OnTriggerExit(Collider other)
    // {
    //     if (other.CompareTag("Player") && portalGun.hasTransferred)
    //     {
    //         portalGun.hasTransferred = false;
    //     }
    // }
}