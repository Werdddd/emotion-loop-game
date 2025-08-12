using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    public Vector2 turn;

    [SerializeField] public float sensitivity = 1f;

    public Vector3 deltaMove;

    [SerializeField] public float speed = 1;

    public float minYAngle = -90f; // Minimum vertical rotation angle
    public float maxYAngle = 90f;  // Maximum vertical rotation angle

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        turn.x += Input.GetAxis("Mouse X") * sensitivity;
        turn.y += Input.GetAxis("Mouse Y") * sensitivity;

        // Clamp the vertical rotation angle to prevent looking too far up or down
        turn.y = Mathf.Clamp(turn.y, minYAngle, maxYAngle);

        transform.localRotation = Quaternion.Euler(-turn.y, turn.x, 0);
    }
}
