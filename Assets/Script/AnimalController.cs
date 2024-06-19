using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalController : MonoBehaviour
{
    public float speed;
    public int hungerNeed;
    public int score;
    public Animator animator;
    private bool isBack;
    private bool isDead = false;

    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("IsWalking", true);
    }

    void Update()
    {
        if (!isDead)
        {
            Move();
        }
    }

    void Move()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime * Mathf.Sign(transform.localScale.x));
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Food"))
        {
            GameManager.instance.AddScore(score);
            hungerNeed -= GameManager.instance.foodHungerValue;
            Destroy(other.gameObject);

            if (hungerNeed <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
    public void TakeDamage(int damage)
    {
        if (!isDead)
        {
            hungerNeed -= damage;
            if(hungerNeed <= 0)
            {
                Die();
            }
        }
    }
    void Die()
    {
        isDead = true;
        Destroy(gameObject);
    }
    public void GameOver()
    {

    }

}
