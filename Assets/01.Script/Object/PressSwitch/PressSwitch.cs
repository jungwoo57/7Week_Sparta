using UnityEngine;

namespace _01.Script.Object.PressSwitch
{
    public abstract class PressSwitch : MonoBehaviour
    {
        [SerializeField] protected GameObject targetObject;
        
        protected abstract void OnCollisionEnter(Collision collision);

        protected abstract void OnCollisionExit(Collision collision);
    }
}
