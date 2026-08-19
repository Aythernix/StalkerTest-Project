using UnityEngine;

public class GameManager : MonoBehaviour
{

    #region Singleton Setup
    private static GameManager _instance;
    public static GameManager Instance // Public getter for the singleton
    {
        get
        {
            if (_instance == null)
            {
                // Error if singleton doesn't exist
                throw new System.NullReferenceException("GameManager singleton does not exist in this current context");
            }
            else
            {
                return _instance;
            }
        }
    }
    #endregion

    void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Debug.LogWarning("These is already a GameManager in this scene");
            Destroy(this);
        }
        else
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }


}
