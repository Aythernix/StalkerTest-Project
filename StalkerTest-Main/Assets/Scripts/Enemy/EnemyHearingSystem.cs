using UnityEngine;

public class EnemyHearingSystem : EnemySystem
{
    
    
    [Tooltip("Lower values make the sound travel further before dropping off")]
    [Range(0f,1f)]
    [SerializeField] private float FalloffRate = 1f;
    [SerializeField] private AnimationCurve FalloffVisualizer;

    #if UNITY_EDITOR
    private void OnValidate()
    {
        // 1. Wipe the curve clean every time you change a value
        FalloffVisualizer = new AnimationCurve();

        // 2. Plot the math for the first 100 meters
        for (float dist = 0; dist <= 100; dist += 5f)
        {
            // Calculate just the distance modifier part of your formula
            float multiplier = 1f / ((dist * FalloffRate) + 1f);
            
            // Add a point to the graph: X is distance, Y is the multiplier
            FalloffVisualizer.AddKey(new Keyframe(dist, multiplier));
        }

        // 3. Smooth the line out so it doesn't look jagged
        for (int i = 0; i < FalloffVisualizer.length; i++)
        {
            UnityEditor.AnimationUtility.SetKeyLeftTangentMode(FalloffVisualizer, i, UnityEditor.AnimationUtility.TangentMode.ClampedAuto);
            UnityEditor.AnimationUtility.SetKeyRightTangentMode(FalloffVisualizer, i, UnityEditor.AnimationUtility.TangentMode.ClampedAuto);
        }
    }
    #endif

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
        if (distance > enemy.Data.MaxHearingRange || distance > soundData.MaxDistance) return;

        CalculateSoundDesire(distance, soundData.Priority);

    }

    private void CalculateSoundDesire(float distance, int Priority)
    {
        var distanceFactor = 1f / ((distance * FalloffRate) + 1f);
        var desire = Priority * distanceFactor * enemy.CurrentFearMultiplier;

        Debug.Log($"distance: {distance}, priority: {Priority}, desire: {desire}");
    }
    
}