using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

	private Camera cam;
	public Transform target;
	public float camSpeed = 5.0f;
	public float focusScale = 0.2f;
	public float smoothTime = 3.0f;

	private float width;
	private float height;
	private float targetWidth;
	private float targetHeight;

	
    void Start()
    {
       

    }

    void FixedUpdate()
    {
    	Vector2 position = new Vector2(transform.position.x, transform.position.y);
        Vector2 targetPosition = new Vector2(target.position.x, target.position.y);
        Vector2 velocity = new Vector2(0,0);
        Vector2 current = Vector2.SmoothDamp(position, targetPosition, ref velocity, smoothTime);
        transform.position = new Vector3(current.x, current.y, -2);
    }

}
