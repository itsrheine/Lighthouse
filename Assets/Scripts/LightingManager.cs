using UnityEngine;

public class LightingManager : MonoBehaviour
{
    public Light directionalLight;
    public float transitionSpeed = 1f;

    private Color targetLightColor;
    private float targetIntensity;
    private Quaternion targetRotation;
    private Color targetFogColor;

    void Start()
    {
        SetMorningImmediate();
    }

    void Update()
    {
        if (directionalLight != null)
        {
            directionalLight.color = Color.Lerp(directionalLight.color, targetLightColor, Time.deltaTime * transitionSpeed);
            directionalLight.intensity = Mathf.Lerp(directionalLight.intensity, targetIntensity, Time.deltaTime * transitionSpeed);
            directionalLight.transform.rotation = Quaternion.Slerp(directionalLight.transform.rotation, targetRotation, Time.deltaTime * transitionSpeed);
        }

        RenderSettings.fogColor = Color.Lerp(RenderSettings.fogColor, targetFogColor, Time.deltaTime * transitionSpeed);
    }

    public void SetMorning()
    {
        targetLightColor = new Color(0.8f, 0.85f, 1f);
        targetIntensity = 0.5f;
        targetRotation = Quaternion.Euler(20f, -30f, 0f);
        targetFogColor = new Color(0.7f, 0.8f, 0.9f);
    }

    public void SetNoon()
    {
        targetLightColor = Color.white;
        targetIntensity = 1f;
        targetRotation = Quaternion.Euler(60f, 0f, 0f);
        targetFogColor = new Color(0.8f, 0.85f, 0.9f);
    }

    public void SetEvening()
    {
        targetLightColor = new Color(1f, 0.6f, 0.4f);
        targetIntensity = 0.6f;
        targetRotation = Quaternion.Euler(10f, 30f, 0f);
        targetFogColor = new Color(0.9f, 0.5f, 0.4f);
    }

    private void SetMorningImmediate()
    {
        targetLightColor = new Color(0.8f, 0.85f, 1f);
        targetIntensity = 0.5f;
        targetRotation = Quaternion.Euler(20f, -30f, 0f);
        targetFogColor = new Color(0.7f, 0.8f, 0.9f);

        if (directionalLight != null)
        {
            directionalLight.color = targetLightColor;
            directionalLight.intensity = targetIntensity;
            directionalLight.transform.rotation = targetRotation;
        }

        RenderSettings.fogColor = targetFogColor;
    }
}