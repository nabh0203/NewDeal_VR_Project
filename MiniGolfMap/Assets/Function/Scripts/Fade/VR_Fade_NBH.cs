using UnityEngine;
using System.Collections;

public class VR_Fade_NBH : MonoBehaviour
{
    public static VR_Fade_NBH instance { get; private set; } // 싱글톤 인스턴스

    public float fadeTime = 2.0f; // 페이드 시간
    public Color fadeColor = new Color(0.01f, 0.01f, 0.01f, 1.0f); // 페이드 색상
    public bool fadeOnStart = true; // 시작 시 페이드 인지 여부
    public int renderQueue = 5000; // 렌더링 순서

    private float explicitFadeAlpha = 0.0f; // 명시적 알파 값
    private float animatedFadeAlpha = 0.0f; // 애니메이션 알파 값
    private float uiFadeAlpha = 0.0f; // UI 알파 값

    private MeshRenderer fadeRenderer; // 메시 렌더러
    private MeshFilter fadeMesh; // 메시 필터
    private Material fadeMaterial = null; // 페이드에 사용할 재질

    void Start()
    {
        if (gameObject.name.StartsWith("OculusMRC_"))
        {
            Destroy(this); // OculusMRC_로 시작하는 이름이면 스크립트 제거
            return;
        }

        // 재질 생성
        fadeMaterial = new Material(Shader.Find("Oculus/Unlit Transparent Color"));
        fadeMesh = gameObject.AddComponent<MeshFilter>();
        fadeRenderer = gameObject.AddComponent<MeshRenderer>();

        var mesh = new Mesh();
        fadeMesh.mesh = mesh;

        Vector3[] vertices = new Vector3[4];
        float width = 5f;
        float height = 5f;
        float depth = 1f;

        // 메시 생성
        vertices[0] = new Vector3(-width, -height, depth);
        vertices[1] = new Vector3(width, -height, depth);
        vertices[2] = new Vector3(-width, height, depth);
        vertices[3] = new Vector3(width, height, depth);

        mesh.vertices = vertices;

        int[] tri = new int[6];

        // 삼각형 생성
        tri[0] = 0;
        tri[1] = 2;
        tri[2] = 1;
        tri[3] = 2;
        tri[4] = 3;
        tri[5] = 1;

        mesh.triangles = tri;

        Vector3[] normals = new Vector3[4];
        normals[0] = -Vector3.forward;
        normals[1] = -Vector3.forward;
        normals[2] = -Vector3.forward;
        normals[3] = -Vector3.forward;

        mesh.normals = normals;

        Vector2[] uv = new Vector2[4];
        uv[0] = new Vector2(0, 0);
        uv[1] = new Vector2(1, 0);
        uv[2] = new Vector2(0, 1);
        uv[3] = new Vector2(1, 1);

        mesh.uv = uv;

        // 시작 시 페이드 인
        if (fadeOnStart)
        {
            FadeIn();
        }

        // 싱글톤 인스턴스 설정
        instance = this;
    }

    // 페이드 인
    public void FadeIn()
    {
        StartCoroutine(Fade(1.0f, 0.0f));
    }

    // 페이드 아웃
    public void FadeOut()
    {
        StartCoroutine(Fade(0, 1));
    }

    void OnEnable()
    {
        // 시작 시 페이드가 아니라면 알파값 초기화
        if (!fadeOnStart)
        {
            explicitFadeAlpha = 0.0f;
            animatedFadeAlpha = 0.0f;
            uiFadeAlpha = 0.0f;
        }
    }

    void OnDestroy()
    {
        instance = null;

        // 메시 렌더러, 재질, 메시 필터 제거
        if (fadeRenderer != null)
            Destroy(fadeRenderer);
        if (fadeMaterial != null)
            Destroy(fadeMaterial);
        if (fadeMesh != null)
            Destroy(fadeMesh);
    }

    // UI 알파 값 설정
    public void SetUIFade(float level)
    {
        uiFadeAlpha = Mathf.Clamp01(level);
        SetMaterialAlpha();
    }

    // 명시적 알파 값 설정
    public void SetExplicitFade(float level)
    {
        explicitFadeAlpha = level;
        SetMaterialAlpha();
    }

    // 페이드 코루틴
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

    // 재질 알파 값 설정
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
    }
}
