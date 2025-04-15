using UnityEngine;
using UnityEngine.UI;

public class CanvasScalerController : MonoBehaviour
{
    public CanvasScaler canvasScaler;

    void Start()
    {
        // Ensure the CanvasScaler component is assigned if it's not already.
        if (canvasScaler == null)
        {
            canvasScaler = GetComponent<CanvasScaler>();
        }

        // Set the Canvas Scaler settings at runtime
        SetCanvasScalerSettings();
    }

    public void SetCanvasScalerSettings()
    {
        // Set UI Scale Mode to Scale With Screen Size
        canvasScaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;

        // Set Screen Match Mode to Expand
        canvasScaler.screenMatchMode = CanvasScaler.ScreenMatchMode.Expand;

        // Optionally, set the reference resolution (this is the resolution you design your UI for)
        canvasScaler.referenceResolution = new Vector2(800, 400);  // Example: 1920x1080
    }
}
