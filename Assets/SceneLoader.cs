using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceLocations;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.SceneManagement;
public class SceneLoader : MonoBehaviour
{
    public string sceneKey;

    // Start is called before the first frame update
    public void Start()
    {
        
    }

    private void SceneLoadComplete(AsyncOperationHandle<SceneInstance> obj)
    {
        if(obj.Status == AsyncOperationStatus.Succeeded)
        {
            Debug.Log(obj.Result.Scene.name + " successfully loaded");
        }
    }

    private void LoadScene(string key)
    {
        Addressables.LoadSceneAsync(key, LoadSceneMode.Single).Completed += SceneLoadComplete;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
