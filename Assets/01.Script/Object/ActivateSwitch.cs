using UnityEngine;

namespace _01.Script.Object
{
    public abstract class ActivateSwitch : MonoBehaviour
    {
        [SerializeField] protected GameObject targetObject;

        protected abstract void Trigger();
    }
}

