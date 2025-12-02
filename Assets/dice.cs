using UnityEngine;
using TMPro;

public class dice : MonoBehaviour
{

    void Start(){}

    private void OnCollisionEnter(Collision other)
    {
        // If the object we hit is called "Board", rotate randomly
        if (other.gameObject.name == "Board")
        {
            // Generate a random rotation
            Quaternion randomRotation = Random.rotation;
            transform.rotation = randomRotation;
        }
    }

   
}