using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private Camera camera;

    [SerializeField]
    TileMapper tileMapper;

    [SerializeField]
    int offset = 1;

    /// <summary>
    /// Scales the camera view to fit the entire maze in the screen.
    /// </summary>
    public void CalculateCameraSize()
    {
        Bounds bounds = tileMapper.GetBounds();

        bounds.Expand(offset);

        float vertical = bounds.size.y;
        float horizontal = bounds.size.x;

        // Still doesn't look too well, but all the mazes are in the camera view. TODO: Needs fixing!
        float size = Mathf.Max(vertical, horizontal) * 0.5f;

        Vector3 center = bounds.center + new Vector3(0, 0, -10);

        camera.transform.position = center;
        camera.orthographicSize = size;
    }
}
