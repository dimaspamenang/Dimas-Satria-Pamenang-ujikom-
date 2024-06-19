using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodController : MonoBehaviour
{
    public int hungerValue = 25;
    public float lifetime = 3f;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, lifetime);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Animal"))
        {

        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
