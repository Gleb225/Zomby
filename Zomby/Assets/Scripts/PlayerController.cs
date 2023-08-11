using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private Rigidbody rigidbody;
    [SerializeField]  private Animator animator;
    public float speed = 5;
    public float rotationSpeed = 40;
    // Start is called before the first frame update
    // Update is called once per frame
    void Update()
    {
        Vector3 directionVector = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        if(directionVector.magnitude > Mathf.Abs(0.05f))
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(directionVector), Time.deltaTime * rotationSpeed);
        }
        animator.SetFloat("speed", Vector3.ClampMagnitude(directionVector, 1).magnitude);

        rigidbody.velocity = Vector3.ClampMagnitude(directionVector, 1) * speed;
    }
}
