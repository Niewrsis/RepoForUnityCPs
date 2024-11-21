using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "AudioDataSO", menuName = "SO/New AudioDataSO")]
    public class AudioDataSO : ScriptableObject
    {
        [SerializeField] private AudioType audioType;
        public AudioType AudioType => audioType;

        [SerializeField] private List<AudioData> audioNeutralData;
        [SerializeField] private List<AudioData> audioDangerousData;
        [SerializeField] private List<AudioData> audioFriendlyData;

        [SerializeField] private string id;
        [SerializeField, TextArea] private string description;
    }
    [System.Serializable]
    public class AudioData
    {
        [SerializeField] private AudioClip audioClip;
        [SerializeField, Range(0, 1)] private float volume;
    }
    public enum AudioType
    {
        Dangerous = 0,
        Friendly = 1,
        Neutral = 2
    }
}