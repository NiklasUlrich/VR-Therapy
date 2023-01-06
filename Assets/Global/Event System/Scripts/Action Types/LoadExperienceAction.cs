using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.SceneManagement;

public class LoadExperienceAction : EventAction
{
    public string experienceKey;

    public LoadingScreen loadingScreen;

    private bool startedLoading = false;

    public void Update()
    {
        if (startedLoading)
        {
            if (loadingScreen == null || loadingScreen.IsOpaque())
            {
                startedLoading = false;
                LoadScene();
            }
        }
    }

    public override void StartAction()
    {
        if (loadingScreen != null)
        {
            loadingScreen.StartLoading();
        }
        gameObject.GetComponent<MeshRenderer>().enabled = false;
        startedLoading = true;
    }

    private void LoadScene()
    {
        Addressables.LoadSceneAsync(experienceKey, LoadSceneMode.Single).Completed += SceneLoadComplete;
    }

    private void SceneLoadComplete(AsyncOperationHandle<SceneInstance> obj)
    {
        if (obj.Status == AsyncOperationStatus.Succeeded)
        {
            Debug.Log(obj.Result.Scene.name + " successfully loaded");
        }
        finished = true;

        if (loadingScreen != null)
        {
            loadingScreen.Unload();
        }

        Destroy(gameObject);
    }
}
