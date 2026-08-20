using UnityEngine;

[CreateAssetMenu(fileName = "New Sound Profile", menuName = "Scriptable Objects/SoundProfile")]
public class SoundProfile : ScriptableObject
{
    public string SoundName;

    public AudioClip[] Clips;

    [Range(0,1f)]
    public float Volume = 1f;

    public int Priority = 10;

    public float MaxDistance = 100f;

    // Select random Clip
    public AudioClip GetRandomAudioClip
    {
        get
        {
            var randomIndex = Random.Range(0, Clips.Length);
            return Clips[randomIndex];
        }
    }
}
