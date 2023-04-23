using System.Collections;
using UnityEngine;

public class LightController : MonoBehaviour
{
    public float intensityMin = 0.0f;
    public float intensityMax = 1.0f;
    public float intensitySpeed = 1.0f;
    public float timeAtMaxIntensity = 1.0f;
    public float timeAtMinIntensity = 1.0f;

    private Light[] childLights;

    private void Start()
    {
        childLights = GetComponentsInChildren<Light>();
        StartCoroutine(ChangeIntensity());
    }

    private IEnumerator ChangeIntensity()
    {
        while (true)
        {
            // Increase intensity
            while (childLights[0].intensity < intensityMax)
            {
                SetIntensity(intensitySpeed * Time.deltaTime);
                yield return null;
            }

            // Stay at max intensity
            SetIntensity(intensityMax);
            yield return new WaitForSeconds(timeAtMaxIntensity);

            // Decrease intensity
            while (childLights[0].intensity > intensityMin)
            {
                SetIntensity(-intensitySpeed * Time.deltaTime);
                yield return null;
            }

            // Stay at min intensity
            SetIntensity(intensityMin);
            yield return new WaitForSeconds(timeAtMinIntensity);
        }
    }

    private void SetIntensity(float deltaIntensity)
    {
        for (int i = 0; i < childLights.Length; i++)
        {
            childLights[i].intensity = Mathf.Clamp(childLights[i].intensity + deltaIntensity, intensityMin, intensityMax);
        }
    }
}
