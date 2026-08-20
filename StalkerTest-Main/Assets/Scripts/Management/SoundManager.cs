using System;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    #region Singleton Setup
    private static SoundManager _instance;
    public static SoundManager Instance // Public getter for the singleton
    {
        get
        {
            if (_instance == null)
            {
                // Error if singleton doesn't exist
                throw new System.NullReferenceException("SoundManager singleton does not exist in this current context");
            }
            else
            {
                return _instance;
            }
        }
    }
    #endregion

    public Action<SoundData> OnSoundEmitted;

     void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Debug.LogWarning("These is already a SoundManager in this scene");
            Destroy(this);
        }
        else
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlaySound(SoundProfile sound, Vector3 origin, AudioSource source)
    {
        if (sound ==  null || sound.Clips.Length == 0 || source == null) return;

        source.clip = sound.GetRandomAudioClip;
        source.volume = sound.Volume;
        source.Play();

        SoundData newSoundData = new SoundData
        {
            soundProfile = sound,
            origin = origin,
            Priority = sound.Priority
        };

        OnSoundEmitted?.Invoke(newSoundData);
    }
}

public struct SoundData
{
    public SoundProfile soundProfile;
    public Vector3 origin;
    public int Priority;
}
