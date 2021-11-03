using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightmap : MonoBehaviour
{
    public static Lightmap instance;
    public Camera LightCam;

    private Vector2Int textureScale;
    public Texture2D tex;
    void Awake()
    {
        instance = this;
        textureScale = new Vector2Int(LightCam.targetTexture.width, LightCam.targetTexture.height);
    }

    void Update()
    {
        DestroyImmediate(tex);
        tex = toTexture2D(LightCam.targetTexture);

        print(GetLight(Input.mousePosition, true));
    }
    public float GetLight(Vector2 point)
    {
        Vector2 screenPoint = LightCam.WorldToScreenPoint(point);
        Vector2 screenToImageScale = new Vector2(LightCam.pixelWidth * 1f / textureScale.x, LightCam.pixelHeight * 1f / textureScale.y);
        Vector2Int imagePoint = new Vector2Int(Mathf.RoundToInt(screenPoint.x / screenToImageScale.x), Mathf.RoundToInt(screenPoint.y / screenToImageScale.y));
        if (imagePoint.x < 0 | imagePoint.y < 0 | imagePoint.x > textureScale.x | imagePoint.y > textureScale.y) Debug.LogError("Point " + point + " outside Lightcanvas");
        Color pixel = tex.GetPixel(imagePoint.x, imagePoint.y);
        return (pixel.r + pixel.g + pixel.b) / 3;
    }
    public float GetLight(Vector2 point, bool screenSpace)
    {
        if (screenSpace) point = Camera.main.ScreenToWorldPoint(point);
        Vector2 screenPoint = LightCam.WorldToScreenPoint(point);
        Vector2 screenToImageScale = new Vector2(LightCam.pixelWidth * 1f / textureScale.x, LightCam.pixelHeight * 1f / textureScale.y);
        Vector2Int imagePoint = new Vector2Int(Mathf.RoundToInt(screenPoint.x / screenToImageScale.x), Mathf.RoundToInt(screenPoint.y / screenToImageScale.y));
        if (imagePoint.x < 0 | imagePoint.y < 0 | imagePoint.x > textureScale.x | imagePoint.y > textureScale.y) Debug.LogError("Point " + point + " outside Lightcanvas");
        Color pixel = tex.GetPixel(imagePoint.x, imagePoint.y);
        return (pixel.r + pixel.g + pixel.b) / 3;
    }

    Texture2D toTexture2D(RenderTexture rTex)
    {
        Texture2D tex = new Texture2D(textureScale.x, textureScale.y, TextureFormat.RGB24, false);
        // ReadPixels looks at the active RenderTexture.
        RenderTexture.active = rTex;
        tex.ReadPixels(new Rect(0, 0, rTex.width, rTex.height), 0, 0);
        tex.Apply();
        return tex;
    }
}
