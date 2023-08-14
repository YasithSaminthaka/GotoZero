using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterShader : MonoBehaviour
{
    public float speed = 1f;
    public float strength = 0.1f;

    private Renderer renderer;
    private Vector2 offset;

    private void Start()
    {
        renderer = GetComponent<Renderer>();
    }

    private void Update()
    {
        offset += new Vector2(0f, speed * Time.deltaTime);
        renderer.material.SetTextureOffset("_MainTex", offset);
        renderer.material.SetFloat("_Strength", strength);
    }
}
