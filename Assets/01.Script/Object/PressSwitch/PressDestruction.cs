using UnityEngine;

namespace _01.Script.Object.PressSwitch
{
    public class PressDestruction : PressSwitch
    {
        protected override void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Cube"))
            {
                Destroy(targetObject);
            }
        }

        protected override void OnCollisionExit(Collision collision)
        {
            //다음에 작업 할때는  필요없는 메서드는 안쓰도록 다른 방법을 찾아야겠다.
        }
    }
}
