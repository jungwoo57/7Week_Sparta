using UnityEngine;

namespace _01.Script.Object
{
    public abstract class InteractableSwitch : MonoBehaviour
    {
        private bool onStay = false;

        private void Update()
        {
            if (onStay && Input.GetKeyDown(KeyCode.E))
            {
                Trigger();
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                onStay = true;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                onStay = false;
            }
        }

        protected abstract void Trigger();

    }
}
