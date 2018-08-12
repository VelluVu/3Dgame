using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    //public GameObject player;
    //Vector3 offset;
    private const float Y_ANGLE_MIN = 10.0f;
    private const float Y_ANGLE_MAX = 40.0f;
    private const float DISTANCE_MIN = 0.5f;
    private const float DISTANCE_MAX = 1.5f;

    public Transform lookAt;
    public Transform camTransform;

    private Camera cam;

    private float distance = 3.0f;
    
    private float distanceSensivity = 0.1f;
    private float currentX = 0.0f;
    private float currentY = 0.0f;
    private float sensivityX = 2.0f;
    private float sensivityY = 0.1f;
    


	// Use this for initialization
	void Start () {

        camTransform = transform;
        cam = Camera.main;


        //offset = transform.position - player.transform.position;
		
	}

    private void LateUpdate()
    {
        
            Vector3 dir = new Vector3(0, 0, -distance);
            Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);
            camTransform.position = lookAt.position + rotation * dir;
            camTransform.LookAt(lookAt.position);

        //transform.position = player.transform.position + offset;
    }
    // Update is called once per frame
    void Update() {

        if (Input.GetMouseButton(1)) { 
        currentX += Input.GetAxis("Mouse X");
        currentY -= Input.GetAxis("Mouse Y");

        currentY = Mathf.Clamp(currentY, Y_ANGLE_MIN, Y_ANGLE_MAX);
        }

        distance = Mathf.Clamp(distance, DISTANCE_MIN, DISTANCE_MAX);

        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            distance -= distanceSensivity;
            
            
        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            distance += distanceSensivity;
            

        }


        /*if (Input.GetAxis("Mouse X") > 0)
        {
            transform.position += new Vector3(Input.GetAxisRaw("Mouse X") * Time.deltaTime * speed, 
                0.0f, Input.GetAxisRaw("Mouse Y") * Time.deltaTime * speed);
        }
        else if (Input.GetAxis("Mouse X") < 0) {

            transform.position += new Vector3(Input.GetAxisRaw("Mouse X") * Time.deltaTime * speed,
                0.0f, Input.GetAxisRaw("Mouse Y") * Time.deltaTime * speed);

        }
		*/
    }
}
