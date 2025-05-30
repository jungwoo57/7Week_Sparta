using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerReactionThroughForce : MonoBehaviour, ITriggerable
{
    [SerializeField]
    private ForceMode forceMode;
 
    [SerializeField]
    private Vector3 direction;
    
    [SerializeField]
    private float power;

    
	Rigidbody rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    [ContextMenu("React")]
    public void TriggerReact()
    {
        rb.AddForce(direction.normalized * power, forceMode);
    }
}
