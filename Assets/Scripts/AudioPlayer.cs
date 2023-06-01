using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{// Used Singleton to keep playing the game theme audio clip
    // After AddressiblesManager.cs, old codes switched with new codes

    //[Header("Explode")]  -> old code.
    //[SerializeField] AudioClip explosionClip; -> old code.
    [HideInInspector] public AudioClip explosionClip; // new
    [SerializeField][Range(0f, 1f)] float explosionVolume = 1f;

    //[Header("Coin")]  -> old code.
    //[SerializeField] AudioClip coinClip; -> old code.
    [HideInInspector] public AudioClip coinClip;// new
    [SerializeField][Range(0f, 1f)] float coinVolume = 1f;

    //[Header("Magic")]  -> old code.
    //[SerializeField] AudioClip magicClip; -> old code.
    [HideInInspector] public AudioClip magicClip;// new
    [SerializeField][Range(0f, 1f)] float magicVolume = 0.3f;

    void Awake()
    {
        ManageSingleton();
    }

    void ManageSingleton()
    {
        int instance = FindObjectsOfType(GetType()).Length;
        if (instance > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    public void PlayExplosionClip()
    {
        PlayClip(explosionClip, explosionVolume);
    }

    public void PlayCoinClip()
    {
        PlayClip(coinClip, coinVolume);
    }

    public void PlayMagicClip()
    {
        PlayClip(magicClip, magicVolume);
    }

    void PlayClip(AudioClip clip, float volume)
    {
        if (clip != null)
        {
            Vector3 cameraPos = Camera.main.transform.position;
            AudioSource.PlayClipAtPoint(clip, cameraPos, volume);
        }
    }
}
