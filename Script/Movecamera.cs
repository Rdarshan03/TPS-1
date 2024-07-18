using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movecamera : MonoBehaviour
{
    public Transform user;
    public Transform pivot;
    Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - user.position;
    }

    // Update is called once per frame
    void Update()
    {
        //Cursor.lockState = CursorLockMode.Locked;

        var mousex = Input.GetAxis("Mouse X");
        var mouseY = Input.GetAxis("Mouse Y");
        pivot.Rotate(-mouseY, mousex, 0);


        var rotation = Quaternion.Euler(pivot.eulerAngles.x, pivot.eulerAngles.y, 0);
        transform.position = user.position + (rotation * offset);

        transform.rotation = rotation;

        //transform.LookAt(user.position);

    }
}
