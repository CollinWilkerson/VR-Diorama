using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;


public class EnvironmentLightingControls : MonoBehaviour
{
    public Toggle useSkyboxToggle;
    public Slider skyboxIntensitySlider;
    public Text skyboxIntensityText;

    public bool UseSkybox
    {
        get => (RenderSettings.ambientMode == AmbientMode.Skybox);
        set
        {
            //sets the skybox settings when the bool is changed.
            RenderSettings.ambientMode = (value) ?
               AmbientMode.Skybox : AmbientMode.Flat;
            skyboxIntensitySlider.interactable = value;
            skyboxIntensityText.gameObject.SetActive(value);
        }
    }

    public float SkyboxIntensity
    {
        get => RenderSettings.ambientIntensity;
        set
        {
            RenderSettings.ambientIntensity = value;
            skyboxIntensityText.text = value.ToString("F1");
        }
    }

    private void Start()
    {
        //sets the toggle to the skybox state
        useSkyboxToggle.isOn = UseSkybox;
    }
}
