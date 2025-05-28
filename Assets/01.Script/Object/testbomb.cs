using _01.Script.Bomb.BombData;
using UnityEngine;

namespace _01.Script.Object
{
    public class testbomb : MonoBehaviour
    {
        //ScriptableObject에서 불러올 것들
        [SerializeField] private float radius;
        [SerializeField] private float force;
        [SerializeField] private BombType bombType;
        
        public void Explode()
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, radius);

            foreach (Collider hit in colliders)
            {
                IAffected[] reactables = hit.GetComponents<IAffected>();

                foreach (var reactable in reactables)
                {
                   //reactable.OnAffected(transform.position, force, radius, bombType);
                }
            }
        }
        void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, radius);
        }
    }
}
