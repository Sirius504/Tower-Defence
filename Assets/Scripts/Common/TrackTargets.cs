using UnityEngine;

public class TrackTargets : MonoBehaviour {

    [SerializeField] 
    Transform[] targets;

    [SerializeField] 
    [Range(0.02f, 0.2f)]
    float boundingBoxPadding = 2f;

    [SerializeField]
    float minimumOrthographicSize = 8f;

    [SerializeField]
    float zoomSpeed = 20f;

    Camera camera;

    void Awake () 
    {
        camera = GetComponent<Camera>();
        camera.orthographic = true;
    }

    void LateUpdate()
    {
        Rect boundingBox = CalculateTargetsBoundingBox();
        Debug.Log($"Min: {new Vector2(boundingBox.xMin, -boundingBox.yMin)}");
        Debug.Log($"Max: {new Vector2(boundingBox.xMax, -boundingBox.yMax)}");
        camera.orthographicSize = Mathf.Max(minimumOrthographicSize, CalculateOrthographicSize(boundingBox));
    }

    /// <summary>
    /// Calculates a bounding box that contains all the targets.
    /// </summary>
    /// <returns>A Rect containing all the targets.</returns>
    Rect CalculateTargetsBoundingBox()
    {
        float minX = Mathf.Infinity;
        float maxX = Mathf.NegativeInfinity;
        float minY = Mathf.Infinity;
        float maxY = Mathf.NegativeInfinity;

        foreach (Transform target in targets) {
            Vector3 position = target.position;

            minX = Mathf.Min(minX, camera.WorldToViewportPoint(position).x);
            minY = Mathf.Min(minY, camera.WorldToViewportPoint(position).y);
            maxX = Mathf.Max(maxX, camera.WorldToViewportPoint(position).x);
            maxY = Mathf.Max(maxY, camera.WorldToViewportPoint(position).y);
        }

        return Rect.MinMaxRect(minX - boundingBoxPadding, maxY - boundingBoxPadding, maxX + boundingBoxPadding, minY + boundingBoxPadding);
    }

    /// <summary>
    /// Calculates a new orthographic size for the camera based on the target bounding box.
    /// </summary>
    /// <param name="boundingBox">A Rect bounding box containg all targets.</param>
    /// <returns>A float for the orthographic size.</returns>
    float CalculateOrthographicSize(Rect boundingBox)
    {
        float boundingBoxWidth = (boundingBox.xMax - boundingBox.xMin);
        float boundingBoxHeight = (-1 * boundingBox.yMax - -1 * boundingBox.yMin);
        return camera.orthographicSize * Mathf.Max(boundingBoxWidth, boundingBoxHeight);
    }
}
