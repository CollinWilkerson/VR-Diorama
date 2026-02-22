using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LightControl : MonoBehaviour
{
    public Slider directionalAngleSlider;
    public Slider directionalIntensitySlider;
    public Slider spotIntensitySlider;
    public Toggle bulbEmissionToggle;

    public Light directionalLight;
    public Light spotLight;

    private TextMeshProUGUI directionalAngleText;
    private TextMeshProUGUI directionalIntensityText;
    private TextMeshProUGUI spotIntensityText;

    public float DirectionalAngle
    {
        get => directionalLight.transform.localEulerAngles.x;
        set
        {
            Vector3 angles = directionalLight.transform.
                                              localEulerAngles;
            angles.x = value;
            directionalLight.transform.localEulerAngles = angles;
            directionalAngleText.text = value.ToString("F0");
        }
    }

    public float DirectionalIntensity
    {
        get => directionalLight.intensity;
        set
        {
            directionalLight.intensity = value;
            directionalIntensityText.text = value.ToString("F1");
        }
    }

    public float SpotIntensity
    {
        get => spotLight.intensity;
        set
        {
            spotLight.intensity = value;
            spotIntensityText.text = value.ToString("F1");
        }
    }

    private void Start()
    {
        directionalAngleText = directionalAngleSlider.
              GetComponentInChildren<TextMeshProUGUI>();
        directionalIntensityText = directionalIntensitySlider.
              GetComponentInChildren<TextMeshProUGUI>();
        spotIntensityText = spotIntensitySlider.
              GetComponentInChildren<TextMeshProUGUI>();

        directionalAngleSlider.value = DirectionalAngle;
        directionalIntensitySlider.value = DirectionalIntensity;
        spotIntensitySlider.value = SpotIntensity;
    }
}
