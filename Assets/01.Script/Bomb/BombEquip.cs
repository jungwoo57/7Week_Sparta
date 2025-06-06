using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInstallable
{
    public void OnInstall();
}

public class BombEquip : MonoBehaviour, IInstallable
{
    public Vector3 installDistance;
    public float installDelay;
    public float bombCooldown;
    private bool _isInstalling;
    private bool _isCooldown;
    
    private Animator _animator;
    private Camera _camera;

    public void OnInstall()
    {
        
    }
}
