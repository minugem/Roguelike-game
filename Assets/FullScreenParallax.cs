using UnityEngine;

public class FullScreenParallax : MonoBehaviour
{
    [SerializeField] private float scrollSpeed = 0.5f;
    
    private float startPositionX;
    private float visibleBackgroundWidth;
    private SpriteRenderer spriteRenderer;
    private GameObject backgroundCopy;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        
        // Store the start position X and calculate the visible background width
        startPositionX = transform.position.x;
        visibleBackgroundWidth = spriteRenderer.bounds.size.x / 2f; // Since the image is twice as wide as needed

        // Create a copy of the background and position it
        backgroundCopy = Instantiate(gameObject, transform.parent);
        backgroundCopy.transform.position = new Vector2(startPositionX + visibleBackgroundWidth, transform.position.y);

        // Disable the script on the copy to prevent infinite spawning
        Destroy(backgroundCopy.GetComponent<FullScreenParallax>());
    }

    void Update()
    {
        // Move both background parts to the left
        MoveBackground(transform);
        MoveBackground(backgroundCopy.transform);
    }

    void MoveBackground(Transform bgTransform)
    {
        // Move the background to the left
        bgTransform.Translate(Vector2.left * scrollSpeed * Time.deltaTime);

        // Check if the background has moved completely off-screen
        if (bgTransform.position.x <= startPositionX - visibleBackgroundWidth)
        {
            // Reset the position
            bgTransform.position = new Vector2(startPositionX + visibleBackgroundWidth, bgTransform.position.y);
        }
    }
}