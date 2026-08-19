using Unity.VisualScripting;
using UnityEngine;

public class EnemyHearingSystem : EnemySystem
{
    private void OnEnable()
    {
        SoundManager.Instance.OnSoundEmitted += ListenToIncomingSounds;
    }

    private void OnDisable()
    {
        SoundManager.Instance.OnSoundEmitted -= ListenToIncomingSounds;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ListenToIncomingSounds(SoundData soundData)
    {
        var distance = Vector3.Distance(soundData.origin, transform.position);

        // Sound isn't audible
        if (distance > soundData.soundProfile.MaxDistance) return;
    }
    
}