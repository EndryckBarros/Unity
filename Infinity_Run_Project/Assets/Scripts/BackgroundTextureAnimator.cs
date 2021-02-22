using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundTextureAnimator : MonoBehaviour
{
    private Material material;
    private Vector2 offset;

    public float factor = 40f;

    public GameConfigurator config;

    // Start is called before the first frame update
    void Start()
    {
        material = gameObject.GetComponent<Renderer>().material;
        offset = material.GetTextureOffset("_MainTex");
    }

    // Update is called once per frame
    void Update()
    {
        offset.x += ((config.speed / factor) * Time.deltaTime);
        material.SetTextureOffset("_MainTex", offset);
    }
}
