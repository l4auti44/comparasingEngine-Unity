using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed = 15f;
    private PlayerMovement player;
    private float timer = 3f;
    private Vector2 facingDirection = Vector2.right;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponentInParent<PlayerMovement>();
        if (player.movementInput != Vector2.zero)
        {
            facingDirection = player.movementInput;
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(facingDirection * Time.deltaTime * speed);
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("collision");
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
