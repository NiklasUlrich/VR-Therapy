using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ripple : MonoBehaviour
{
    //the time til the ripple reaches alpha 0
    public float decayTime;

    public float maxSize;

    bool animating = false;
    float scale = 0.0f;
    float lifeTime;
    Material material;
    Color color;

    // Start is called before the first frame update
    void Start()
    {
        material = GetComponent<Renderer>().material;
        color = material.color;
        SetScale(0);
        StartRipple();
    }

    // Update is called once per frame
    void Update()
    {
        if (animating)
        {
            float deltaTime = Time.deltaTime;
            lifeTime += deltaTime;
            scale += deltaTime * maxSize / decayTime;
            SetScale(scale);

            color.a -= deltaTime / decayTime;
            material.color = color;

            if (lifeTime >= decayTime)
            {
                animating = false;
                gameObject.SetActive(false);
            }
        }

    }

    void SetScale(float newScale)
    {
        gameObject.transform.localScale = new Vector3(newScale, newScale, 1);
    }

    public void StartRipple()
    {
        scale = 0;
        animating = true;
    }
}
