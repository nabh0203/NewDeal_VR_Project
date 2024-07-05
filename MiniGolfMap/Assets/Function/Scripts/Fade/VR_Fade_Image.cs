using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VR_Fade_Image : MonoBehaviour
{
    public static VR_Fade_Image Fadeinstance { get; private set; }
    public float fadeTime = 2.0f;
    public Color fadeColor = new Color(0.01f, 0.01f, 0.01f, 1.0f);
    public bool fadeOnStart = true;
    public int renderQueue = 5000;

    private float explicitFadeAlpha = 0.0f;
    private float animatedFadeAlpha = 0.0f;
    private float uiFadeAlpha = 0.0f;

    private MeshRenderer fadeRenderer;
    private MeshFilter fadeMesh;
    private Material fadeMaterial = null;

    public Image targetImage; // 페이드 효과를 적용할 이미지
    public Text targetText;   // 페이드 효과를 적용할 텍스트

    void Start()
    {
        if (gameObject.name.StartsWith("OculusMRC_"))
        {
            Destroy(this);
            return;
        }

        fadeMaterial = new Material(Shader.Find("Oculus/Unlit Transparent Color"));
        fadeMesh = gameObject.AddComponent<MeshFilter>();
        fadeRenderer = gameObject.AddComponent<MeshRenderer>();

        var mesh = new Mesh();
        fadeMesh.mesh = mesh;

        Vector3[] vertices = {
            new Vector3(-5f, -5f, 1f),
            new Vector3(5f, -5f, 1f),
            new Vector3(-5f, 5f, 1f),
            new Vector3(5f, 5f, 1f)
        };
        mesh.vertices = vertices;

        int[] tri = { 0, 2, 1, 2, 3, 1 };
        mesh.triangles = tri;

        Vector3[] normals = { -Vector3.forward, -Vector3.forward, -Vector3.forward, -Vector3.forward };
        mesh.normals = normals;

        Vector2[] uv = { new Vector2(0, 0), new Vector2(1, 0), new Vector2(0, 1), new Vector2(1, 1) };
        mesh.uv = uv;

        if (fadeOnStart)
        {
            FadeIn();
        }

        Fadeinstance = this;
    }

    public void FadeIn()
    {
        StartCoroutine(Fade(1.0f, 0.0f));
    }

    public void FadeOut()
    {
        StartCoroutine(Fade(0, 1));
    }

    void OnEnable()
    {
        if (!fadeOnStart)
        {
            explicitFadeAlpha = 0.0f;
            animatedFadeAlpha = 0.0f;
            uiFadeAlpha = 0.0f;
        }
    }

    void OnDestroy()
    {
        Fadeinstance = null;
        if (fadeRenderer != null) Destroy(fadeRenderer);
        if (fadeMaterial != null) Destroy(fadeMaterial);
        if (fadeMesh != null) Destroy(fadeMesh);
    }

    public void SetUIFade(float level)
    {
        uiFadeAlpha = Mathf.Clamp01(level);
        SetMaterialAlpha();
    }

    public void SetExplicitFade(float level)
    {
        explicitFadeAlpha = level;
        SetMaterialAlpha();
    }

    IEnumerator Fade(float startAlpha, float endAlpha)
    {
        float elapsedTime = 0.0f;
        while (elapsedTime < fadeTime)
        {
            elapsedTime += Time.deltaTime;
            animatedFadeAlpha = Mathf.Lerp(startAlpha, endAlpha, Mathf.Clamp01(elapsedTime / fadeTime));
            SetMaterialAlpha();
            yield return new WaitForEndOfFrame();
        }
        animatedFadeAlpha = endAlpha;
        SetMaterialAlpha();
    }

    private void SetMaterialAlpha()
    {
        Color color = fadeColor;
        color.a = Mathf.Max(explicitFadeAlpha, animatedFadeAlpha, uiFadeAlpha);
        if (fadeMaterial != null)
        {
            fadeMaterial.color = color;
            fadeMaterial.renderQueue = renderQueue;
            fadeRenderer.material = fadeMaterial;
            fadeRenderer.enabled = color.a > 0;
        }

        if (targetImage != null)
        {
            Color imageColor = targetImage.color;
            imageColor.a = animatedFadeAlpha; // 또는 explicitFadeAlpha, uiFadeAlpha 중 하나 사용
            targetImage.color = imageColor;
        }

        if (targetText != null)
        {
            Color textColor = targetText.color;
            textColor.a = animatedFadeAlpha; // 또는 explicitFadeAlpha, uiFadeAlpha 중 하나 사용
            targetText.color = textColor;
        }
    }
}
