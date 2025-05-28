using UnityEngine;

namespace _01.Script.Audio
{
    public class SoundTest : MonoBehaviour
    {
        public void PlayMainBGM()
        {
            AudioManager.Instance.PlayBGM(SoundType.MainBGM);
            Debug.Log("메인");
        }

        public void PlayBossBGM()
        {
            AudioManager.Instance.PlayBGM(SoundType.BossBGM);
            Debug.Log("보스");
        }
    }
}

