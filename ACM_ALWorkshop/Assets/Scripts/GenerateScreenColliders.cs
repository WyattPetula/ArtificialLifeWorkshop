using UnityEngine;

public class GenerateScreenColliders : MonoBehaviour
{
    Camera cameraMain;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cameraMain = Camera.main;
        GenerateCollidersAcrossScreen();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void GenerateCollidersAcrossScreen()
    {
        Vector2 lDCorner = cameraMain.ViewportToWorldPoint(new Vector3(0, 0f, cameraMain.nearClipPlane));
        Vector2 rUCorner = cameraMain.ViewportToWorldPoint(new Vector3(1f, 1f, cameraMain.nearClipPlane));
        Vector2[] colliderpoints;

        EdgeCollider2D upperEdge = new GameObject("upperEdge").AddComponent<EdgeCollider2D>();
        colliderpoints = upperEdge.points;
        colliderpoints[0] = new Vector2(lDCorner.x, rUCorner.y);
        colliderpoints[1] = new Vector2(rUCorner.x, rUCorner.y);
        upperEdge.points = colliderpoints;

        EdgeCollider2D lowerEdge = new GameObject("lowerEdge").AddComponent<EdgeCollider2D>();
        colliderpoints = lowerEdge.points;
        colliderpoints[0] = new Vector2(lDCorner.x, lDCorner.y);
        colliderpoints[1] = new Vector2(rUCorner.x, lDCorner.y);
        lowerEdge.points = colliderpoints;

        EdgeCollider2D leftEdge = new GameObject("leftEdge").AddComponent<EdgeCollider2D>();
        colliderpoints = leftEdge.points;
        colliderpoints[0] = new Vector2(lDCorner.x, lDCorner.y);
        colliderpoints[1] = new Vector2(lDCorner.x, rUCorner.y);
        leftEdge.points = colliderpoints;

        EdgeCollider2D rightEdge = new GameObject("rightEdge").AddComponent<EdgeCollider2D>();

        colliderpoints = rightEdge.points;
        colliderpoints[0] = new Vector2(rUCorner.x, rUCorner.y);
        colliderpoints[1] = new Vector2(rUCorner.x, lDCorner.y);
        rightEdge.points = colliderpoints;
    }
}
