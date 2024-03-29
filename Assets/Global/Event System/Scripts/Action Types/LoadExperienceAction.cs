using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.SceneManagement;

public class LoadExperienceAction : EventAction
{
    [Tooltip("Key for the Experience to be loaded (NOT 'experience')]")]
    public string experienceKey;

    [Tooltip("The loading screen whoch will be used. Leave empty to just load without a loading screen.")]
    private LoadingScreen loadingScreen;

    public Color loadingScreenColor;

    private bool startedLoading = false;

    private AsyncOperationHandle<SceneInstance> sceneLoadingHandle;


    //kicks off the scene loading by loading the loading screen, so the player does not see the loading
    public override void StartAction()
    {
        loadingScreen = LoadingScreen.loadingScreen;

        DontDestroyOnLoad(gameObject);
        if (loadingScreen != null)
        {
            loadingScreen.StartPreloading(loadingScreenColor);
        }

        MeshRenderer meshRenderer = gameObject.GetComponent<MeshRenderer>();
        if (meshRenderer)
        {
            gameObject.GetComponent<MeshRenderer>().enabled = false;

        }

        int childCount = transform.childCount;

        for (int i = childCount - 1; i >= 0; i--)
        {
            Transform child = transform.GetChild(i);
            Destroy(child.gameObject);
        }

        startedLoading = true;
    }

    //waits for the loading screen to load, then starts to load the scene proper
    public void Update()
    {
        if (startedLoading)
        {
            if (loadingScreen == null || loadingScreen.GetStatus() == LoadingScreen.Status.preloaded)
            {
                startedLoading = false;
                LoadScene();
            }
        }
    }

    //starts loading the scene
    private void LoadScene()
    {
        sceneLoadingHandle = Addressables.LoadSceneAsync(experienceKey, LoadSceneMode.Single);
        sceneLoadingHandle.Completed += SceneLoadComplete;
        if(loadingScreen != null)
        {
            loadingScreen.StartLoading(sceneLoadingHandle);
        }
    }

    //destroys the object once the scene has fully loaded
    private void SceneLoadComplete(AsyncOperationHandle<SceneInstance> obj)
    {
        if (obj.Status == AsyncOperationStatus.Succeeded)
        {
            Debug.Log(obj.Result.Scene.name + " successfully loaded");
        }
        finished = true;

        Destroy(gameObject);
    }

}
