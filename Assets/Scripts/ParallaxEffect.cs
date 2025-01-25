using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{
    [System.Serializable]
    public class ParallaxLayer
    {
        public Transform layerTransform; // The transform of the background layer
        public float parallaxMultiplier; // The multiplier for the parallax effect
    }

    public ParallaxLayer[] layers; // Array of layers to apply the parallax effect
    private Vector3 _previousCameraPosition;

    void Start()
    {
        // Initialize the camera's previous position
        _previousCameraPosition = Camera.main.transform.position;
    }

    void Update()
    {
        // Get the camera's current position
        Vector3 currentCameraPosition = Camera.main.transform.position;

        // Calculate the difference in the camera's position
        Vector3 deltaPosition = currentCameraPosition - _previousCameraPosition;

        // Apply the parallax effect to each layer
        foreach (var layer in layers)
        {
            if (layer.layerTransform != null)
            {
                float parallaxX = deltaPosition.x * layer.parallaxMultiplier;
                float parallaxY = deltaPosition.y * layer.parallaxMultiplier;

                Vector3 newLayerPosition = new Vector3(
                    layer.layerTransform.position.x + parallaxX,
                    layer.layerTransform.position.y + parallaxY,
                    layer.layerTransform.position.z
                );

                layer.layerTransform.position = newLayerPosition;
            }
        }

        // Update the camera's previous position
        _previousCameraPosition = currentCameraPosition;
    }
}
