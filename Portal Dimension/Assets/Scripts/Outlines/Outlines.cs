using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Outlines : MonoBehaviour
{
    public Shader outliner;
    public Color outlineColor;
    private Material edgeMat;
    public int outlineSamples = 1;

    // Start is called before the first frame update
    void Start()
    {
        edgeMat ??= new Material(outliner);
        edgeMat.hideFlags = HideFlags.HideAndDontSave;

        Camera cam = GetComponent<Camera>();
        cam.depthTextureMode = cam.depthTextureMode | DepthTextureMode.Depth;
    }

    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        edgeMat.SetColor("_OutlineColor", outlineColor);
        Graphics.Blit(source, destination, edgeMat);
    }
}
