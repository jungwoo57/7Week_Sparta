using UnityEngine;
using UnityEngine.UI;

namespace _01.Script.Audio
{
    public class SoundSettingManager : MonoBehaviour
    {
        [Header("컴포넌트 바인딩")]
        [SerializeField] private Slider masterVolume;
        [SerializeField] private Slider bgmVolume;
        [SerializeField] private Slider sfxVolume;
    
        public void Start()
        {
            LoadSliderSet();
        }
        
        public void OnMasterVolumeChange(float value)
        {
            AudioManager.Instance.MasterVolume = value;
            Debug.Log($"마스터 볼륨: {value:F2}");
        }

        
        public void OnBGMVolumeChange(float value)
        {
            AudioManager.Instance.BGMVolume = value;
            Debug.Log($"배경음 볼륨: {value:F2}");
        }

        
        public void OnSFXVolumeChange(float value)
        {
            AudioManager.Instance.SFXVolume = value;
            Debug.Log($"효과음 볼륨: {value:F2}");
        }
        
        
        private void LoadSliderSet()
        {
            masterVolume.value = AudioManager.Instance.MasterVolume;
            bgmVolume.value = AudioManager.Instance.BGMVolume;
            sfxVolume.value = AudioManager.Instance.SFXVolume;
        }
    }
}
