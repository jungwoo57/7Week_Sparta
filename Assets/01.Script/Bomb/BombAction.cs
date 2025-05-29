
using _01.Script.Audio;
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

    public ParticleSystem particleSystem;

    private void Awake()
    {
        _collider = this.gameObject.GetComponent<BoxCollider>();
        particleSystem = GetComponentInChildren<ParticleSystem>();
    }

    private void Start()
    {
        Init();
        StartCoroutine(Explode());
        Invoke("PlayEffect", _data.explodeTime-0.15f);
    }
    public IEnumerator Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, _data.explodeRange);
        yield return new WaitForSeconds(_data.explodeTime);
        foreach (Collider hit in colliders)
        {
            IAffected[] reactables = hit.GetComponents<IAffected>();
            if(reactables == null) { Debug.Log("error"); }
            foreach (var reactable in reactables)
            {
                reactable.OnAffected(transform.position, _data.explodePower, _data.explodeRange, _data.bombType);
                //reactable.OnAffected(transform.position, force, radius, bombType);
            }
        }
        AudioManager.Instance.PlaySFX(SoundType.None);
        float time = 0f;
        while (time < 1f)
        {
            
            _collider.enabled = false;
            transform.localScale = Vector3.Lerp(Vector3.one * _data.explodeRange, Vector3.zero, time);
            time += Time.deltaTime;
            AudioManager.Instance.PlaySFX(SoundType.Explosion);
            yield return null;
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

    void PlayEffect()
    {
        if(particleSystem != null)
        {
            particleSystem.Play();
        }
    }
}
