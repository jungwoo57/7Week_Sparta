using UnityEngine;

namespace _01.Script.Object
{
    public class PressSwitchTrigger : MonoBehaviour
    {
        [SerializeField] private GameObject targetObject;
        [SerializeField] private Vector3 targetPosition;
        [SerializeField] private float moveSpeed;
        
        private Vector3 targetPos;
        private bool Move = false;
        private int pressCount = 0;

        void Start()
        {
            if (targetObject != null)
            {
                targetPos = targetObject.transform.position;
            }
        }
        
        void Update()
        {
            if (targetObject == null) return;

            Vector3 destination = Move ? targetPosition : targetPos;
            targetObject.transform.position = Vector3.MoveTowards(targetObject.transform.position, destination, moveSpeed * Time.deltaTime);
        }
        
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Player"))//폭탄, 박스등 추가하여 올라가게 가능
            {
                foreach (var contact in collision.contacts)
                {
                    if (contact.point.y > transform.position.y + 0.1f)
                    {
                        if (++pressCount == 1)
                        {
                            Debug.Log("올라감");
                            Move = true;
                        }
                        break;
                    }
                }
            }
        }

        private void OnCollisionExit(Collision collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                if (--pressCount <= 0)
                {
                    pressCount = 0;
                    Debug.Log("내려감");
                    Move = false;
                }
            }
        }
    }
}
