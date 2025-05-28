
using System.Collections;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class BombAction : MonoBehaviour
{
    private Collider _collider;
    private BombStatus _status;
    protected BombBase _data;
    //ScriptableObject에서 불러올 것들
    [SerializeField] private float radius;
    [SerializeField] private float force;
    [SerializeField] private BombType bombType;
    
    public void Explode()
    {
        //Init();
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

    private void Init()
    {
        _status = this.gameObject.GetComponent<BombStatus>();
        _data = _status.data;
    }
    
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
