using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody rigidbody;
    private Animator animator;
    public float speed = 5;
    public float rotationSpeed = 40;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

       

        Vector3 directionVector = new Vector3(h,0,v);
        if(directionVector.magnitude > Mathf.Abs(0.05f))
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(directionVector), Time.deltaTime * rotationSpeed);
        }
        animator.SetFloat("speed", Vector3.ClampMagnitude(directionVector, 1).magnitude);

        rigidbody.velocity = Vector3.ClampMagnitude(directionVector, 1) * speed;


    }
}
