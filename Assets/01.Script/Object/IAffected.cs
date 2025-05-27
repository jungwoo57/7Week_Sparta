
using _01.Script.Object;
using UnityEngine;

public interface IAffected
{
    void OnAffected(Vector3 pos, float force, float radius, TestBombType type);
}
