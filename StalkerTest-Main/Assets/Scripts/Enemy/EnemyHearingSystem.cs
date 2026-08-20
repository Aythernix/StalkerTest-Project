using UnityEngine;

public class EnemyHearingSystem : EnemySystem
{
    
    
    [SerializeField] private int distanceWeight = 100;

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
        if (distance > enemy.Data.MaxHearingRange) return;

        CalculateSoundDesire(distance, soundData.Priority);

    }

    private void CalculateSoundDesire(float distance, int Priority)
    {
        var normalizedDistance = distance / enemy.Data.MaxHearingRange;
        var desire = enemy.Data.HearingFallOff.Evaluate(normalizedDistance) * distanceWeight + Priority;
        Debug.Log($"distance: {distance}, max hearing range: {enemy.Data.MaxHearingRange}, priority: {Priority}, graph eval: {enemy.Data.HearingFallOff.Evaluate(normalizedDistance)} ,desire = {desire}");
    }
    
}