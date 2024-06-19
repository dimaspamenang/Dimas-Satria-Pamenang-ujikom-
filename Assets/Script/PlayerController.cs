using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 3f;
    private Vector3 movement;
    private Animator animator;
    private Rigidbody rb;
    private bool isGameOver;

    public GameObject foodPrefab;
    public float throwForce = 1;

    private void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        if (isGameOver) return;

        float moveHorizontal = Input.GetAxis("Horizontal");

        movement = new Vector3(moveHorizontal, 0, 0);

        if(movement != Vector3.zero)
        {
            if(moveHorizontal > 0)
            {
                animator.SetBool("IsStrafeRight",true);
                animator.SetBool("IsStrafeLeft", false);
            }
            else if (moveHorizontal < 0)
            {
                animator.SetBool("IsStrafeRight", false);
                animator.SetBool("IsStrafeLeft",true);
            }
            else
            {

                animator.SetBool("IsStrafeRight", false);
                animator.SetBool("IsStrafeLeft", false);
                animator.SetTrigger("Idle");
            }
            if(Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
            {
                Throw();
            }
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                PauseMenu();
            }
        }
    }
    private void FixedUpdate()
    {
        Vector3 newPosition = rb.position + movement * speed * Time.deltaTime;
        rb.MovePosition(newPosition);
    }
    void Throw()
    {
        GameObject food = Instantiate(foodPrefab, transform.position + Vector3.up, Quaternion.identity);

        Vector3 throwDirection = transform.forward;
        throwDirection.y = 0f;

        Rigidbody foodRb = food.GetComponent<Rigidbody>();
        foodRb.velocity = throwDirection * throwForce * Time.deltaTime;

        Destroy(food, 3f);

        animator.SetTrigger("Throw");
    }
    void PauseMenu()
    {

    }
    public void GameOver()
    {
        isGameOver = true;
        animator.SetTrigger("GameOver");
    }
}
