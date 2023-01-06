using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingScreen : MonoBehaviour
{
    private Image loadingImage;
    private bool loading = false;
    private bool unloading = false;

    public float loadingFadeSpeed;
    public float unloadingFadeSpeed;



    // Start is called before the first frame update
    void Start()
    {
        loadingImage = gameObject.GetComponentInChildren<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (loading)
        {
            Color tempColor = loadingImage.color;
            tempColor.a += Time.deltaTime * loadingFadeSpeed;
            Debug.Log("Transparency: " + tempColor.a);
            loadingImage.color = tempColor;
            return;
        }

        if(unloading)
        {
            Destroy(gameObject);
        }
    }

    public void StartLoading()
    {
        loading = true;
        unloading = false;
        Debug.Log("Loading Screen starting");
    }

    public void Unload()
    {
        unloading = true;
        loading = false;
    }
}
