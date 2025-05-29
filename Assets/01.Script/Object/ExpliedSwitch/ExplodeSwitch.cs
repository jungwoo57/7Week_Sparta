using UnityEngine;

namespace _01.Script.Object.ExpliedSwitch
{
    public abstract class ExplodeSwitch : MonoBehaviour
    {
        [SerializeField] protected GameObject targetObject;

        protected abstract void Trigger();
    }
}

