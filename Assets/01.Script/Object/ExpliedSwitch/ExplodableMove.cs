using System.Collections;
using UnityEngine;

namespace _01.Script.Object.ExpliedSwitch
{
    public class ExplodableButton : ExplodeSwitch, IAffected
    {
        [SerializeField] private Vector3 targetPosition;
        [SerializeField] private float moveSpeed;

        private Vector3 startPosition;
        private Coroutine moveroutine;
        bool isMoving = false;
        void Start()
        {
            if (targetObject != null)
            {
                startPosition = targetObject.transform.position;
            }
        }
        public void OnAffected(Vector3 explosionPos, float power, float radius, BombType type)
        {
            if (type != BombType.Demolition) return;
            Trigger();
        }

        protected override void Trigger()
        {
            isMoving = !isMoving;
            OnMove(isMoving);
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


