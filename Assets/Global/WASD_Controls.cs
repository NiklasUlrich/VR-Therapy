using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WASD_Controls : MonoBehaviour
{
    public float moveSpeed;
    public float sensitivity;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Rotate();
    }

    private void Move()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 movement = transform.forward * vertical + transform.right * horizontal;
        /*
        Vector3 Movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        */
        gameObject.transform.position += moveSpeed * Time.deltaTime * movement;
        
    }

    private void Rotate()
    {
        float rotateHorizontal = Input.GetAxis("Mouse X");
        float rotateVertical = Input.GetAxis("Mouse Y");

        transform.RotateAround(gameObject.transform.position, Vector3.up, rotateHorizontal * sensitivity);
        transform.RotateAround(gameObject.transform.position, transform.right, - rotateVertical * sensitivity);
    }
}
