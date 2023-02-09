using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.UI;

public class LoadingScreen : MonoBehaviour
{
    private Image loadingImage;


    private Color tempColor;
    private AsyncOperationHandle<SceneInstance> sceneLoadingHandle;

    public float loadingFadeSpeed;
    public float unloadingFadeSpeed;

    public enum Status {none, preloading, preloaded, loading, unloading}
    private Status status = Status.none;

    // Start is called before the first frame update
    void Start()
    {
        loadingImage = gameObject.GetComponentInChildren<Image>();
        tempColor = loadingImage.color;
    }

    // Update is called once per frame
    void Update()
    {
        //fills the view with the loadingscreen while preloading
        if (status == Status.preloading)
        {
            tempColor.a += Time.deltaTime * loadingFadeSpeed;
            loadingImage.color = tempColor;
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
            loadingImage.color = tempColor;
            if (tempColor.a <= 0)
            {
                Destroy(gameObject);
            }
        }
    }

    public void StartLoading(AsyncOperationHandle<SceneInstance> obj)
    {
        sceneLoadingHandle = obj;
        status = Status.loading;
    }

    public void StartPreloading()
    {
        status = Status.preloading;
    }

    public Status GetStatus()
    {
        return status;
    }
}