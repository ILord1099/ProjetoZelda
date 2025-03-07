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

    [Header("Attack Config")]
    public ParticleSystem fxAttack;


    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();  
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        Move();

    }
    public void Move()//movimentação e animação
    {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            if (Input.GetButtonDown("Fire1"))
            {
                anim.SetTrigger("Attack");
                fxAttack.Emit(50);
            
            }


            direction = new Vector3(horizontal, 0f, vertical).normalized;

            if (direction.magnitude > 0.1f)
            {
                float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.Euler(0, targetAngle, 0);
                isWalk = true;
            }
            else
            {
                isWalk = false;
            }
            controller.Move(direction * movementSpeed * Time.deltaTime);

            anim.SetBool("isWalk", isWalk);
        }
 }

