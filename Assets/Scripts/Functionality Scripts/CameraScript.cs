using UnityEngine;
using System.Collections;

/// CAMERA SCRIPT
/// written by:
/// Thomas Fitzgerald, Logan Gombar
/// 
/// Rotates, Zooms, and Resets Camera Position

public class CameraScript : MonoBehaviour
{

    public Transform target;
    public float distance = 16000.0f, xSpeed = 120.0f, ySpeed = 120.0f;
    public float yMinLimit = -9999f, yMaxLimit = 9999f;
    public float distanceMin = -9999f, distanceMax = 9999f;
    public float smoothTime = 2f;
    float rotationYAxis = 0.0f, rotationXAxis = 0.0f;
    float velocityX = 0.0f, velocityY = 0.0f;
    private new Rigidbody rigidbody;

    //for reseting the camera
    private Vector3 myCamPos = new Vector3(-6527.00f, 3419.861f, -6758.90f);
    private Vector3 camAngles;
    private float orthoSize;
    private int scrollSpeed;
	
	private Quaternion toRotation, rotation;
	private Vector3 negDistance, position, angles;

    // Initialization
    void Start()
    {
        scrollSpeed = 10;

        angles = transform.eulerAngles;
        rotationYAxis = angles.y;
        rotationXAxis = angles.x;

        rigidbody = GetComponent<Rigidbody>();

        // Make the rigid body not change rotation
        if (rigidbody != null)
        {
            rigidbody.freezeRotation = true;
        }

        myCamPos = transform.position;
        camAngles = transform.eulerAngles;
        orthoSize = Camera.main.orthographicSize;
    }

    //Actual running
    void Update()
    {
        if (target)
        {
            ///////////////////////////////
            // ROTATE VIEW
            ///////////////////////////////

            if (Input.GetMouseButton(0)) //get mouse position as mouse is down
            {
                velocityX += xSpeed * Input.GetAxis("Mouse X") * 0.002f;
                velocityY += ySpeed * Input.GetAxis("Mouse Y") * 0.002f;
            }

            //Stop camera when mouse is released
            if (Input.GetMouseButtonUp(0))
            {
                velocityX = 0;
                velocityY = 0;
            }

            rotationYAxis += velocityX;
            rotationXAxis -= velocityY;

            rotationXAxis = ClampAngle(rotationXAxis, yMinLimit, yMaxLimit); //find clamp angle through how much mouse is dragged

            toRotation = Quaternion.Euler(rotationXAxis, rotationYAxis, 0);  //end position of mouse
            rotation = toRotation;

            negDistance = new Vector3(0.0f, 0.0f, -distance);
            position = rotation * negDistance + target.position;

            transform.rotation = rotation;
            transform.position = position;

            velocityX = Mathf.Lerp(velocityX, 0, Time.deltaTime * smoothTime);
            velocityY = Mathf.Lerp(velocityY, 0, Time.deltaTime * smoothTime);

            ///////////////////////////////
            // RESET VIEW
            ///////////////////////////////

            if (Input.GetKey(KeyCode.R))
            {
                transform.position = myCamPos;
                transform.eulerAngles = camAngles;
                Camera.main.orthographicSize = orthoSize;
                velocityX = 0.0f;
                velocityY = 0.0f;
                rotationXAxis = 20;
                rotationYAxis = 44;
            }

            ///////////////////////////////
            // ZOOM IN/OUT
            ///////////////////////////////

            if (Input.GetKey(KeyCode.O))
            {//out
                Camera.main.orthographicSize = Mathf.Min(Camera.main.orthographicSize + scrollSpeed, 20000);
            }
            else if (Input.GetKey(KeyCode.I))
            {//in
                Camera.main.orthographicSize = Mathf.Max(Camera.main.orthographicSize - scrollSpeed, 250);
            }

            if (Input.GetAxis("Mouse ScrollWheel") != 0)
            {
                if (Input.GetAxis("Mouse ScrollWheel") < 0)
                {
                    Camera.main.orthographicSize = Mathf.Min(Camera.main.orthographicSize - Input.GetAxis("Mouse ScrollWheel") * 500, 20000);
                }
                else if (Input.GetAxis("Mouse ScrollWheel") > 0)
                {
                    Camera.main.orthographicSize = Mathf.Max(Camera.main.orthographicSize - Input.GetAxis("Mouse ScrollWheel") * 500, 210);
                }
            }

        }

    }

    //provided unity method for clamp angles
    public static float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360F)
            angle += 360F;
        if (angle > 360F)
            angle -= 360F;
        return Mathf.Clamp(angle, min, max);
    }
}