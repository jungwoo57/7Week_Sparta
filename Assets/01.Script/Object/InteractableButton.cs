using UnityEngine;

namespace _01.Script.Object
{
    public class InteractableButton : ActivateSwitch
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

        protected override void Trigger()
        {
            Debug.Log("플레이어가 활성화");
        }
    }
}
