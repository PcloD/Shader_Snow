using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class ScreenSpaceSnow : MonoBehaviour {

    public Texture2D SnowTexture;

    public Color SnowColor = Color.white;

    public float SnowTextureScale = 0.1f;

    [Range(0, 1)] public float BottomThreshold = 0f;
    [Range(0, 1)] public float TopThreshold = 1f;

    private Material _material;

    private void OnEnable()
    {
        _material = new Material(Shader.Find("dreambuffer/ScreenSpaceSnow"));

        GetComponent<Camera>().depthTextureMode |= DepthTextureMode.DepthNormals;
    }

    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        _material.SetMatrix("_CamToWorld", GetComponent<Camera>().cameraToWorldMatrix);
        _material.SetColor("_SnowColor", SnowColor);
        _material.SetFloat("_BottomThreshold", BottomThreshold);
        _material.SetFloat("_TopThreshold", TopThreshold);
        _material.SetTexture("_SnowTex", SnowTexture);
        _material.SetFloat("_SnowTexScale", SnowTextureScale);

        Graphics.Blit(source, destination, _material);
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
