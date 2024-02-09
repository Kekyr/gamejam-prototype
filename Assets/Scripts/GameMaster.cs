using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    public static GameMaster Instance;

    [SerializeField] private float volume = 0.25f;
    [SerializeField] public bool paused { get; private set; }

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;

        AudioListener.volume = volume;

        DontDestroyOnLoad(gameObject);
    }

    public void ChangeVolume(float newValue)
    {
        volume               = newValue;
        AudioListener.volume = newValue;
    }

    public bool Pause()
    {
        paused = !paused;
        Time.timeScale = paused ? 0 : 1;
        return paused;
    }
}
