using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private CharacterController controller;
    private Animator anim;

    [Header("Config Player")]
    public float movementSpeed = 3f;

    private Vector3 direction;
    private bool isWalk;

    [Header("Camera")]
    public GameObject camB;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();  
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {


        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        if(Input.GetButtonDown("Fire1"))
        {
            anim.SetTrigger("Attack");
        }


        direction = new Vector3 (horizontal,0f,vertical).normalized;

        if(direction.magnitude > 0.1f) 
        {
            float targetAngle = Mathf.Atan2(direction.x,direction.z) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0,targetAngle,0);
            isWalk = true;
        }
        else // if(direction,magnitude <= 0.1f)
        {
            isWalk = false;
        }
        controller.Move(direction * movementSpeed* Time.deltaTime);

        anim.SetBool("isWalk", isWalk);
    }

    private void OnTriggerEnter(Collider other)
    {
        switch(other.gameObject.tag)
        {
            case "Camtrigger":
                camB.SetActive(true);
                break;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        switch (other.gameObject.tag)
        {
            case "Camtrigger":
                camB.SetActive(false);
                break;
        }
    }
}
