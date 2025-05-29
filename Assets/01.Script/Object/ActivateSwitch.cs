using UnityEngine;

public abstract class ActivateSwitch : MonoBehaviour
{
    [SerializeField] protected GameObject targetObject;

    protected abstract void Trigger();
}

