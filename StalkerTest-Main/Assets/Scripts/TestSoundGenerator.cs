using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class TestSoundGenerator : MonoBehaviour
{
    [SerializeField] private SoundProfile sound;
    [SerializeField] private AudioSource source;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            SoundManager.Instance.PlaySound(sound, transform.position, source);
        }
    }
}
