using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicRoutine : MonoBehaviour
{// Using by magic object with particle effect in ranged enemy units.

    [SerializeField] float magicRate = 3f;
    [SerializeField] GameObject magic;

    AudioPlayer audioPlayer;
    CapsuleCollider2D capsuleCollider;


    void Awake()
    {
        audioPlayer = FindObjectOfType<AudioPlayer>();
    }

    void Start()
    {
        capsuleCollider = GetComponent<CapsuleCollider2D>();
        capsuleCollider.enabled = false;
        StartCoroutine(DoMagic());
    }

    IEnumerator DoMagic()
    {
        var emissionModule = magic.GetComponent<ParticleSystem>().emission;
        emissionModule.enabled = false;

        while (true)
        {
            audioPlayer.PlayMagicClip();
            capsuleCollider.enabled = true;
            emissionModule.enabled = true;

            yield return new WaitForSeconds(magicRate);

            capsuleCollider.enabled = false;
            emissionModule.enabled = false;

            yield return new WaitForSeconds(magicRate);
        }
    }
}
