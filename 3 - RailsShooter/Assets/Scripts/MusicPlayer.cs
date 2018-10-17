using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    void Awake()
    {
        int players = FindObjectsOfType<MusicPlayer>().Length;
        if(players > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}
