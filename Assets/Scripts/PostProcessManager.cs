using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class PostProcessManager : MonoBehaviour
{
    public Volume volume;
    private Bloom bloom;
    private Vignette vignette;

    [SerializeField] private float defaultVignetteIntensity = 0.3f;
    [SerializeField] private float maxVignetteIntensity = 0.7f;
    [SerializeField] private float vignetteIntensifyStep = 0.01f;

    void Start()
    {
        bloom = null;
        volume.profile.TryGet<Bloom>(out bloom);
        vignette = null;
        volume.profile.TryGet<Vignette>(out vignette);
    }

    public void IntensifyVignette()
    {
        if(vignette.intensity.value <= maxVignetteIntensity)
        {
            vignette.intensity.value += vignetteIntensifyStep;
        }        
    }

    void Update()
    {
        // Increase bloom intensity while the 'B' key is held down
        if (Input.GetKey(KeyCode.B))
        {
            vignette.intensity.value += Time.deltaTime * 2f; // Adjust the rate of change as needed
        }
        else
        {
            // Reset bloom intensity when the 'B' key is released
            bloom.intensity.value = 0f; // Reset to default or desired value
        }
    }
}
