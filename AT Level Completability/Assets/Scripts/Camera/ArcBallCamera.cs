using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcBallCamera : MonoBehaviour
{
    // references to the player and the camera target (player head)
    public GameObject player;
    public GameObject cameraTarget;

    private Vector2 rotationDirection;

    // speed the camera will rotate at
    [SerializeField] float rotationSpeed = 1f;
    float pitch;

    // camera distance from the player head
    [SerializeField] float radius = 5f;

    // Spherical coords
    Vector3 sc = new Vector3();
    [SerializeField] float minZRotationClamp = -0.4f;
    [SerializeField] float maxZRotationClamp = 0.6f;

    [SerializeField] float smoothingFactor = 0.25f;

    private void Start()
    {
        this.transform.position = new Vector3(radius, 0.0f, 1.6f);
        this.transform.LookAt(cameraTarget.transform.position);

        sc = GetSphericalCoordinates(this.transform.position);
        sc = new Vector3(8f, -1.6f, 0.5f);
        //smoothingFactor *= Time.deltaTime;
    }


    // change the cartesian coordinates of the camera to polar
    Vector3 GetSphericalCoordinates(Vector3 cartesian)
    {
        float radius = Mathf.Sqrt(
            Mathf.Pow(cartesian.x, 2) +
            Mathf.Pow(cartesian.y, 2) +
            Mathf.Pow(cartesian.z, 2));

        float phi = Mathf.Atan2(cartesian.z / cartesian.x, cartesian.x);
        float theta = Mathf.Acos(cartesian.y / radius);

        if (cartesian.x < 0) { phi += Mathf.PI; }

        //print(phi);

        return new Vector3(radius, phi, theta);
    }

    // change the polar coordinates to cartesian
    Vector3 GetCartesianCoordinates(Vector3 sphereical)
    {
        Vector3 ret = new Vector3();

        ret.x = sphereical.x * Mathf.Cos(sphereical.z) * Mathf.Cos(sphereical.y);
        ret.y = sphereical.x * Mathf.Sin(sphereical.z);
        ret.z = sphereical.x * Mathf.Cos(sphereical.z) * Mathf.Sin(sphereical.y);

        return ret;
    }

    void SnapCam()
    {
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            pitch = 0;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            pitch = 0.5f * Mathf.PI;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            pitch = Mathf.PI;
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            pitch = 1.5f * Mathf.PI;
        }

        sc.y = Mathf.Lerp(sc.y, pitch, smoothingFactor);
    }

    void MouseInput()
    {
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            rotationDirection.x = 1;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rotationDirection.x = -1;
        }
        else
        {
            rotationDirection.x = 0;
        }
    }

    void RotateCam()
    {
        float dx = rotationDirection.x * rotationSpeed;
        float dy = rotationDirection.y * rotationSpeed;

        if (dx != 0f || dy != 0f)
        {
            sc.y += dx * Time.deltaTime;

            //Debug.Log(sc.z);
            sc.z = Mathf.Clamp(sc.z + dy * Time.deltaTime, minZRotationClamp, maxZRotationClamp);
        }
    }

    private void Update()
    {
        //SnapCam();
        //MouseInput();
        //RotateCam();

        this.transform.position = GetCartesianCoordinates(sc) + cameraTarget.transform.position;
        this.transform.LookAt(cameraTarget.transform.position);
    }
}
