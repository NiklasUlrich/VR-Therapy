using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.UI;

public class LoadingScreen : MonoBehaviour
{
    private Color tempColor;
    private AsyncOperationHandle<SceneInstance> sceneLoadingHandle;

    private Material material;

    public float loadingFadeSpeed;
    public float unloadingFadeSpeed;

    public GameObject[] objectsToHide;

    public enum Status {none, preloading, preloaded, loading, unloading}
    private Status status = Status.none;

    public static LoadingScreen loadingScreen;

    private void Awake()
    {
        if (!loadingScreen)
        {
            loadingScreen = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        material = GetComponent<Renderer>().material;
        tempColor = material.color;
    }

    // Update is called once per frame
    void Update()
    {
        //fills the view with the loadingscreen while preloading
        if (status == Status.preloading)
        {
            Debug.Log("DEBUG: loading screen " + tempColor.a);
            tempColor.a += Time.deltaTime * loadingFadeSpeed;
            material.color = tempColor;
            if (tempColor.a >= 1)
            {
                status = Status.preloaded;
            }
            return;
        }

        //access to the completion of the scene load. not implemented yet.
        if (status == Status.loading)
        {
            //Debug.Log("loading " + sceneLoadingHandle.PercentComplete + "% done");
            if (sceneLoadingHandle.Status == AsyncOperationStatus.Succeeded)
            {
                status = Status.unloading;
            }
            return;
        }

        if(status == Status.unloading)
        {
            tempColor.a -= Time.deltaTime * unloadingFadeSpeed;
            material.color = tempColor;
            if (tempColor.a <= 0)
            {
                //Destroy(gameObject);
                status = Status.none;
          
            }
        }
    }

    public void StartLoading(AsyncOperationHandle<SceneInstance> obj)
    {
        sceneLoadingHandle = obj;
        status = Status.loading;
    }

    public void StartPreloading(Color color)
    {
        
        status = Status.preloading;
        tempColor = color;


    }

    public Status GetStatus()
    {
        return status;
    }
}
