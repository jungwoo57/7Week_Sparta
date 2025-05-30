
using _01.Script.Audio;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Debug = UnityEngine.Debug;

public class BombAction : MonoBehaviour
{
    private Collider _collider;
    private BombStatus _status;
    private Rigidbody _rigid;
    protected BombBase _data;
    //ScriptableObject에서 불러올 것들
    [SerializeField] private float radius;
    [SerializeField] private float force;
    [SerializeField] private BombType bombType;

    List<IAffected> reactabless = new();
    public ParticleSystem ps;

    private void Awake()
    {
        _collider = this.gameObject.GetComponent<BoxCollider>();
        ps = GetComponentInChildren<ParticleSystem>();
    }

    private void Start()
    {
        Init();
        StartCoroutine(Explode());
        Invoke("PlayEffect", _data.explodeTime-0.15f);
    }
    public IEnumerator Explode()
    {
        yield return new WaitForSeconds(_data.explodeTime);
        Collider[] colliders = Physics.OverlapSphere(transform.position, _data.explodeRange);  
        foreach (Collider hit in colliders)
        {
            reactabless.Clear();
            IAffected[] reactables = hit.GetComponents<IAffected>();
            if (reactables.Length == 0) 
            { 
            }
            else
            {
                foreach (var reactable in reactables)
                {
                    reactable.OnAffected(transform.position, _data.explodePower, _data.explodeRange, _data.bombType);
                    //reactable.OnAffected(transform.position, force, radius, bombType);
                }
            }
        }
        AudioManager.Instance.PlaySFX(SoundType.Explosion);
        float time = 0f;
        while (time < 1f)
        {
            
            _collider.enabled = false;
            _rigid.useGravity = false;
            transform.localScale = Vector3.Lerp(Vector3.one * _data.explodeRange, Vector3.zero, time);
            time += Time.deltaTime;
            //AudioManager.Instance.PlaySFX(SoundType.Explosion);
            yield return null;
        }
        Destroy(gameObject);

    }

    private void Init()
    {
        _status = this.gameObject.GetComponent<BombStatus>();
        _data = _status.data;
        _rigid = GetComponent<Rigidbody>();
    }
    
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

    void PlayEffect()
    {
        if(ps != null)
        {
            ps.Play();
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _data.explodeRange); // 에디터에서도 항상 보임
        
    }
}
