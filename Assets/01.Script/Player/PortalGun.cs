using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalGun : MonoBehaviour
{
    [SerializeField]
    private GameObject portalPrefab;
    private Vector3 portalColliderSize;
    private Portal portal1;
    private Portal portal2;

    [SerializeField]
    private RenderTexture portalView1;
    [SerializeField]
    private Material portalView1Material;
    [SerializeField]
    private RenderTexture portalView2;
    [SerializeField]
    private Material portalView2Material;

    Portal currentPortal;
    private const float RayLength = 25;
    
    public bool hasTransferred = false;

    private void Awake()
    {
        GameObject portalContainer = new GameObject("PortalContainer");
        portal1 = Instantiate(portalPrefab, portalContainer.transform).GetComponent<Portal>();
        portal2 = Instantiate(portalPrefab, portalContainer.transform).GetComponent<Portal>();
        portal1.GetComponentInChildren<Renderer>().material.color = Color.blue;
        portal2.GetComponentInChildren<Renderer>().material.color = Color.yellow;
        
        portal1.gameObject.SetActive(false);
        portal2.gameObject.SetActive(false);

        portal1.Init(this, portal2);
        portal2.Init(this, portal1);
        
        portal1.SetRenderTexture(portalView1, portalView1Material);
        portal2.SetRenderTexture(portalView2, portalView2Material);
        
        currentPortal = portal1;
        portalColliderSize = portal1.GetComponent<BoxCollider>().size;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void Shot()
    {
        Ray ray = Camera.main.ScreenPointToRay(new Vector2((float)Screen.width / 2, (float)Screen.height / 2));
        RaycastHit hit;

        // if (Physics.BoxCast(Camera.main.transform.position, portalColliderSize / 2, Camera.main.transform.forward,
        //         out hit, Quaternion.identity, rayLength))

        if (Physics.Raycast(ray, out hit, RayLength, LayerMask.GetMask("Wall")))
        {
            currentPortal.transform.position = hit.point;
            currentPortal.transform.rotation = Quaternion.LookRotation(-hit.normal);

            currentPortal.gameObject.SetActive(true);

            currentPortal = currentPortal == portal1 ? portal2 : portal1;

            if (portal1.gameObject.activeInHierarchy && portal2.gameObject.activeInHierarchy)
            {
                portal1.ActivatePortal();
                portal2.ActivatePortal();
            }
        }
    }
}