using System.Collections;
using UnityEngine;

namespace _01.Script.Object.PressSwitch
{
    public class PressMove : PressSwitch
    {
        [SerializeField] private Vector3 targetPosition;
        [SerializeField] private float moveSpeed;
        
        private Vector3 startPosition;
        private int pressCount = 0;
        private Coroutine moveroutine;
    
        void Start()
        {
            if (targetObject != null)
            {
                startPosition = targetObject.transform.position;
            }
        }
    
        protected override void OnCollisionEnter(Collision collision)
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
                            OnMove(true);
                        }
                        break;
                    }
                }
            }
        }

        protected override void OnCollisionExit(Collision collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                if (--pressCount <= 0)
                {
                    pressCount = 0;
                    Debug.Log("내려감");
                    OnMove(false);
                }
            }
        }
        private void OnMove(bool move)
        {
            if (moveroutine != null)
            {
                StopCoroutine(moveroutine);
            }
            moveroutine = StartCoroutine(Moveroutine(move ? targetPosition : startPosition));
        }

        private IEnumerator Moveroutine(Vector3 destination)
        {
            while (targetObject != null && Vector3.Distance(targetObject.transform.position, destination) > 0.01f)
            {
                targetObject.transform.position = Vector3.MoveTowards(targetObject.transform.position, destination, moveSpeed * Time.deltaTime
                );
                yield return null;
            }

            targetObject.transform.position = destination;
        }
    }
}
