using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;
using TMPro;


public class EnvironmentLightingControls : MonoBehaviour
{
    //these could all be serializefeilds
    public Toggle useSkyboxToggle;
    public Slider skyboxIntensitySlider;
    public TextMeshProUGUI skyboxIntensityText;
    public Toggle enableFog;

    public bool EnableFog
    {
        get => RenderSettings.fog;
        set => RenderSettings.fog = value;
    }

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
        enableFog.isOn = EnableFog;
    }
}
