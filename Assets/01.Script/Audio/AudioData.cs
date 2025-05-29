using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace _01.Script.Audio
{
    [CreateAssetMenu(fileName = "NewSoundData", menuName = "Sound/SoundData")]
    public class AudioData : ScriptableObject
    {
        public SoundType soundType;
        public AudioClip clip;
        
        public static List<AudioData> LoadAllSoundData()
        {
            return Resources.LoadAll<AudioData>("SoundData").ToList();
        }
    }
    
    public enum SoundType
    {
        None,
        MainBGM,
        BossBGM,
        Explosion
    }
}