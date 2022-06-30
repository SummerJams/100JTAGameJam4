using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    private Camera thisCamera;
    [SerializeField]
    private Transform target;

    [SerializeField]
    private float upEdge;
    [SerializeField]
    private float rightEdge;
    [SerializeField]
    private float downEdge;
    [SerializeField]
    private float leftEdge;

    private float posX;
    private float posY;
    private float scaleCameraX;
    private float scaleCameraY;
    void Start()
    {
        thisCamera = GetComponent<Camera>();
        scaleCameraX = thisCamera.ScreenToWorldPoint(new Vector2(thisCamera.scaledPixelWidth, 0)).x - transform.position.x;
        scaleCameraY = thisCamera.ScreenToWorldPoint(new Vector2(0, thisCamera.scaledPixelHeight)).y - transform.position.y;
    }
    void Update()
    {
        if (target.position.x + scaleCameraX > rightEdge)
            posX = rightEdge - scaleCameraX;
        else if (target.position.x - scaleCameraX < -leftEdge)
            posX = -leftEdge + scaleCameraX;
        else
            posX = target.position.x;
        if (target.position.y + scaleCameraY > upEdge)
            posY = upEdge - scaleCameraY;
        else if (target.position.y - scaleCameraY < -downEdge)
            posY = -downEdge + scaleCameraY;
        else
            posY = target.position.y;
        transform.position = new Vector3(posX, posY, transform.position.z);
    }
}
