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
    
    private Transform playerPos;
    private Portal partnerPortal;
    
    Material originalMaterial;
    
    public bool IsActivated { get; private set; }

    private void Awake()
    {
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

    public void SetPortalPair(Portal anotherPortal)
    {
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
}
