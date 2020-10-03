using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed;  
    public float angularSpeed;
    public Transform wheelTransform;              

    private Rigidbody2D rb2d; 
    private int lastDir = 0;   
    private float zAng = 0;    
    private float targetAngle = 0;
    private bool returning = false;


    void Start()
    {
        rb2d = GetComponent<Rigidbody2D> ();
    }

    void FixedUpdate()
    {
        float moveHorizontal = 0.0f;
        float moveVertical = 0.0f;

        returning = true;
        bool rotating = false;

        if(Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
        	lastDir = 0;
        	moveVertical += 1.0f;
        }

        if(Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
        	lastDir = 0;
        	moveVertical -= 1.0f;
        }

        if(Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
        	lastDir = 1;
        	moveHorizontal -= 1.0f;
        	rotating = true;
        	returning = false;
        }

        if(Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
        	lastDir = -1;
        	moveHorizontal += 1.0f;
        	rotating = true;
        	returning = false;
        }

        if(rotating)
        {
        	float step = angularSpeed * Time.fixedDeltaTime;
        	float z = wheelTransform.rotation.eulerAngles.z;
        	Vector3 offset = new Vector3(0.0f, 0.0f, step * lastDir);
        	Quaternion currentRotation = Quaternion.identity;
        	currentRotation.eulerAngles = wheelTransform.rotation.eulerAngles + offset;
        	zAng = currentRotation.eulerAngles.z;
        	wheelTransform.rotation = currentRotation;
        }
        else if(returning)
        {
        	//targetAngle = (int) zAng / 120 + (lastDir)
        }

        Vector2 movement = new Vector2 (moveHorizontal, moveVertical);
        movement = movement * speed;
        rb2d.MovePosition(rb2d.position + movement * Time.fixedDeltaTime);
    }

    void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 100, 20), "Z: " + zAng);
    }

    void Update()
    {
        
    }
}
