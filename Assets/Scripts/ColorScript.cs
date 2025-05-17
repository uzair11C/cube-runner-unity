using UnityEngine;

public class ColorScript : MonoBehaviour
{
    [SerializeField]
    private Renderer playerRenderer;
    [SerializeField]
    private Renderer bgRenderer;

    void Start()
    {
        playerRenderer.material.color = RandomColor(bright: true);
        bgRenderer.material.color = RandomColor(bright: false);
    }

    Color RandomColor(bool bright)
    {
        float hue = Random.value;
        float saturation = Random.Range(0.4f, 0.7f);

        // Avoid very low value which gives pure black
        float value = bright ? Random.Range(0.8f, 1f) : Random.Range(0.15f, 0.3f);

        return Color.HSVToRGB(hue, saturation, value);
    }
}
