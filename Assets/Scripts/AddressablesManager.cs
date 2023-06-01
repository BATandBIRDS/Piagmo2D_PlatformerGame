using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.AddressableAssets.ResourceLocators;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[Serializable]
public class AssetReferenceAudioClip : AssetReferenceT<AudioClip>
{
    public AssetReferenceAudioClip(string guid): base(guid) { }
}

public class AddressablesManager : MonoBehaviour
{
    #region SERIALIZE FIELDS

    [Header("Audio Clips")]

    [SerializeField] private AudioPlayer audioPlayer;
    [SerializeField] private AssetReferenceAudioClip exposionSFX;
    [SerializeField] private AssetReferenceAudioClip coinSFX;
    [SerializeField] private AssetReferenceAudioClip magicSFX;

    [Header("Sprites")]

    [SerializeField] private AssetReferenceSprite coinSprite;
    [SerializeField] private SpriteRenderer coinRenderer;

    [SerializeField] private AssetReferenceSprite gem3Sprite;
    [SerializeField] private SpriteRenderer gem3Renderer;
    
    [SerializeField] private AssetReferenceSprite gem4Sprite;
    [SerializeField] private SpriteRenderer gem4Renderer;

    [SerializeField] private AssetReferenceSprite forest2Sprite;
    [SerializeField] private SpriteRenderer forest2Renderer;

    [SerializeField] private AssetReferenceSprite forest3Sprite;
    [SerializeField] private SpriteRenderer forest3Renderer;

    [SerializeField] private AssetReferenceSprite forest4Sprite;
    [SerializeField] private SpriteRenderer forest4Renderer;

    [SerializeField] private AssetReferenceSprite forest5Sprite;
    [SerializeField] private SpriteRenderer forest5Renderer;

    [SerializeField] private AssetReferenceSprite particle6Sprite;
    [SerializeField] private SpriteRenderer particle6Renderer;

    [SerializeField] private AssetReferenceSprite forest7Sprite;
    [SerializeField] private SpriteRenderer forest7Renderer;

    [SerializeField] private AssetReferenceSprite particle8Sprite;
    [SerializeField] private SpriteRenderer particle8Renderer;

    [SerializeField] private AssetReferenceSprite bushes9Sprite;
    [SerializeField] private SpriteRenderer bushes9Renderer;

    [SerializeField] private AssetReferenceTexture2D coinTexture;
    [SerializeField] private RawImage coinImg;

    #endregion

    void Start()
    {
        //Caching.ClearCache();
        Addressables.InitializeAsync().Completed += AddressablesManager_Completed;
    }

    void AddressablesManager_Completed(AsyncOperationHandle<IResourceLocator> obj)
    {

        #region AUDIO

        exposionSFX.LoadAssetAsync<AudioClip>().Completed += (clip) =>
        {
            audioPlayer.explosionClip = clip.Result;
        };

        coinSFX.LoadAssetAsync<AudioClip>().Completed += (clip) =>
        {
            audioPlayer.coinClip = clip.Result;
        };

        magicSFX.LoadAssetAsync<AudioClip>().Completed += (clip) =>
        {
            audioPlayer.magicClip = clip.Result;
        };

        #endregion
        
        #region SPRITES

        coinSprite.LoadAssetAsync<Sprite>().Completed += (sprite) =>
        {
            coinRenderer.sprite = sprite.Result;
        };

        coinTexture.LoadAssetAsync<Texture2D>().Completed += (img) =>
        {
            coinImg.texture = img.Result;
        };

        gem3Sprite.LoadAssetAsync<Sprite>().Completed += (sprite) =>
        {
            gem3Renderer.sprite = sprite.Result;
        };

        gem4Sprite.LoadAssetAsync<Sprite>().Completed += (sprite) =>
        {
            gem4Renderer.sprite = sprite.Result;
        };

        forest2Sprite.LoadAssetAsync<Sprite>().Completed += (sprite) =>
        {
            forest2Renderer.sprite = sprite.Result;
        };

        forest3Sprite.LoadAssetAsync<Sprite>().Completed += (sprite) =>
        {
            forest3Renderer.sprite = sprite.Result;
        };

        forest4Sprite.LoadAssetAsync<Sprite>().Completed += (sprite) =>
        {
            forest4Renderer.sprite = sprite.Result;
        };

        forest5Sprite.LoadAssetAsync<Sprite>().Completed += (sprite) =>
        {
            forest5Renderer.sprite = sprite.Result;
        };

        forest7Sprite.LoadAssetAsync<Sprite>().Completed += (sprite) =>
        {
            forest7Renderer.sprite = sprite.Result;
        };

        particle6Sprite.LoadAssetAsync<Sprite>().Completed += (sprite) =>
        {
            particle6Renderer.sprite = sprite.Result;
        };

        particle8Sprite.LoadAssetAsync<Sprite>().Completed += (sprite) =>
        {
            particle8Renderer.sprite = sprite.Result;
        };

        bushes9Sprite.LoadAssetAsync<Sprite>().Completed += (sprite) =>
        {
            bushes9Renderer.sprite = sprite.Result;
        };

        #endregion
    }

    private void Scene_Complete(AsyncOperationHandle<SceneInstance> sceneHandle)
    {
        //Load complete do something
    }

    void ReleaseGameObjects()
    {
        coinSprite.ReleaseAsset();
        gem3Sprite.ReleaseAsset();
        gem4Sprite.ReleaseAsset();
        forest2Sprite.ReleaseAsset();
        forest3Sprite.ReleaseAsset();
        forest4Sprite.ReleaseAsset();
        forest5Sprite.ReleaseAsset();
        forest7Sprite.ReleaseAsset();
        particle6Sprite.ReleaseAsset();
        particle8Sprite.ReleaseAsset();
        bushes9Sprite.ReleaseAsset();
        exposionSFX.ReleaseAsset();
        coinSFX.ReleaseAsset();
        magicSFX.ReleaseAsset();
        coinTexture.ReleaseAsset();
    }

    void OnDestroy()
    {
        if (SceneManager.GetActiveScene().ToString() == "Game") { return; }
        ReleaseGameObjects();
    }
}
