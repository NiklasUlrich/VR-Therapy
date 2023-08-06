using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PermanentObject : MonoBehaviour
{
    public static PermanentObject me;
    private void Awake()
    {

            DontDestroyOnLoad(gameObject);

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
