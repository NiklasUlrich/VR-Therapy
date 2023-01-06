using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingScreen : MonoBehaviour
{
    private Image loadingImage;
    private bool loading = false;
    private bool unloading = false;
    private Color tempColor;

    public float loadingFadeSpeed;
    public float unloadingFadeSpeed;



    // Start is called before the first frame update
    void Start()
    {
        loadingImage = gameObject.GetComponentInChildren<Image>();
        tempColor = loadingImage.color;
    }

    // Update is called once per frame
    void Update()
    {
        if (loading)
        {
            tempColor.a += Time.deltaTime * loadingFadeSpeed;
            loadingImage.color = tempColor;
            if (IsOpaque())
            {
                loading = false;
            }
            return;
        }

        if(unloading)
        {
            tempColor.a -= Time.deltaTime * unloadingFadeSpeed;
            loadingImage.color = tempColor;
            if (tempColor.a <= 0)
            {
                Destroy(gameObject);
            }
        }
    }

    public void StartLoading()
    {
        loading = true;
        unloading = false;
    }

    public void Unload()
    {
        unloading = true;
        loading = false;
    }

    public bool IsOpaque()
    {
        if(tempColor.a >= 1)
        {
            return true;
        }
        return false;
    }
}
