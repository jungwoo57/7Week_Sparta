using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchExplodeSensor : MonoBehaviour, IAffected
{
    [SerializeField]
    private Switch pairedSwitch;
    
    public void OnAffected(Vector3 pos, float force, float radius, BombType type)
    {
        pairedSwitch.Activate();
    }
}
