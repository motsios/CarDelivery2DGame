using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    [SerializeField] Color32 isLoadedColor = new Color32(1, 1, 1, 1);
    [SerializeField] Color32 noLoadedColor = new Color32(1, 1, 1, 1);

    [SerializeField] float destroyDelay = 0.5f;
    bool hasPackage;
    int counter = 0;
    SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        // Debug.Log("collision" + other);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Package" && !hasPackage)
        {
            // Debug.Log("Picked up");
            hasPackage = true;
            spriteRenderer.color = isLoadedColor;
            Destroy(other.gameObject, destroyDelay);

        }
        if (other.tag == "Customer" && hasPackage)
        {

            // Debug.Log("Package delivered");
            spriteRenderer.color = noLoadedColor;
            hasPackage = false;
            counter = counter + 1;
            if (counter == 3)
            {
                Debug.Log("Mission completed");
            }
        }
    }
}
