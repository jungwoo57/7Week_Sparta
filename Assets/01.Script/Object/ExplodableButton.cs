using UnityEngine;

namespace _01.Script.Object
{
    public class ExplodableButton : ActivateSwitch, IAffected
    {
        public void OnAffected(Vector3 explosionPos, float power, float radius, BombType type)
        {
            if(type != BombType.Demolition) return;
            Trigger(); 
        }

        protected override void Trigger()
        {
            Debug.Log("폭탄으로 활성화");
        }
    }
}

