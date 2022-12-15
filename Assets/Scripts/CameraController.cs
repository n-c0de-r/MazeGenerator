using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private Camera camera;

    [SerializeField]
    TileMapper tileMapper;

    [SerializeField]
    int offset = 10;

    private float ratio;

    // Start is called before the first frame update
    void Start()
    {
        ratio = camera.aspect;
    }

    // Update is called once per frame
    void Update()
    {
        var (center, size) = CalculateOrthograficSize();
        camera.transform.position = center;
        camera.orthographicSize = size;
    }

    private (Vector3 center, float size) CalculateOrthograficSize()
    {
        Bounds bounds = tileMapper.GetBounds();

        bounds.Expand(offset);

        float vertical = bounds.size.y;
        float horizontal = bounds.size.x;

        // Don't really like this, there must be a mathematical relation (numbers are similar), but I can't figure it out now.
        float size = (vertical > horizontal) ? ((vertical-offset) / 10) * 6 : ((horizontal-offset) / 10) * 3;

        Vector3 center = bounds.center + new Vector3(0, 0, -10);

        return (center, size);
    }
}
