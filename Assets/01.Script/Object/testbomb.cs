using System.Collections;
using System.Collections.Generic;
using _01.Script.Object;
using UnityEngine;

public class testbomb : MonoBehaviour
{
    [SerializeField] private float radius = 5f;
    [SerializeField] private float force = 700f;
    [SerializeField] private BombType bombType;
    public void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);

        foreach (Collider hit in colliders)
        {
            IAffected[] reactables = hit.GetComponents<IAffected>();

            foreach (var reactable in reactables)
            {
                reactable.OnAffected(transform.position, force, radius, bombType);
            }
        }
    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
