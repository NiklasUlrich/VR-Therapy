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

    public override void StartAction()
    {
        LoadScene();
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
    }
}
