using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Outlines : MonoBehaviour
{
    public Shader outliner;
    public Color outlineColor;
    private Color[] omitColors;
    private Material edgeMat;
    public float outlineDistance = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        edgeMat ??= new Material(outliner);
        edgeMat.hideFlags = HideFlags.HideAndDontSave;
        omitColors = new Color[4];
        omitColors[0] = Color.red;
        omitColors[1] = Color.green;
        omitColors[2] = Color.blue;
        omitColors[3] = Color.black;

        Camera cam = GetComponent<Camera>();
        cam.depthTextureMode = cam.depthTextureMode | DepthTextureMode.Depth;
    }

    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        edgeMat.SetColor("_OutlineColor", outlineColor);
        edgeMat.SetFloat("_OutlineDist", outlineDistance);
        Graphics.Blit(source, destination, edgeMat);
    }
}
