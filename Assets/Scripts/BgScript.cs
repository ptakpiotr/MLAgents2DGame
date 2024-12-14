using UnityEngine;

public class BgScript : MonoBehaviour
{
    public float scrollSpeed = 0.2f;

    private MeshRenderer meshRenderer;

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    private void Update()
    {
        Scroll();
    }

    private void Scroll()
    {
        Vector2 offset = meshRenderer.sharedMaterial.mainTextureOffset;
        offset.x += Time.deltaTime * scrollSpeed;

        meshRenderer.sharedMaterial.mainTextureOffset = offset;
    }
}