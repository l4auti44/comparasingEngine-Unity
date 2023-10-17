using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private PlayerInput playerInput;
    [SerializeField] private float movementSpeed = 2f;
    [SerializeField] private GameObject bulletPrefab;
    [HideInInspector] public Vector2 movementInput;
    private Animator anim;
    private SpriteRenderer spriteRenderer;


    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        playerInput = GetComponent<PlayerInput>();
    }

    // Update is called once per frame
    void Update()
    {
        //Vector2 movement
        movementInput = playerInput.actions["Move"].ReadValue<Vector2>();
        if (movementInput != Vector2.zero)
        {
            anim.SetBool("isWalking", true);
        }
        else
        {
            anim.SetBool("isWalking", false);
        }
        if (movementInput.x < 0)
        {
            spriteRenderer.flipX = true;
        }
        else
        {
            spriteRenderer.flipX = false;
        }

        transform.Translate(movementInput * Time.deltaTime * movementSpeed);

        if (playerInput.actions["Shoot"].WasPerformedThisFrame())
        {
            Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        }
    }
}
