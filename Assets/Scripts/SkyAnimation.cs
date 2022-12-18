using UnityEngine;

public class SkyAnimation : MonoBehaviour
{
    [SerializeField]
    private GameObject sky;
    private Material skyMaterial;
    private Vector2 skyOffset;
    private float skyScale;

    // Start is called before the first frame update
    void Start()
    {
        skyMaterial = sky.GetComponent<MeshRenderer>().material;
        skyOffset = skyMaterial.mainTextureOffset;
        skyScale = sky.transform.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {
        skyOffset.x += Time.deltaTime / skyScale;
        skyMaterial.mainTextureOffset = skyOffset;
    }
}
