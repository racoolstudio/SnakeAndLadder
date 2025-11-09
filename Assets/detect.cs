using UnityEngine;
using TMPro;

public class detect : MonoBehaviour
{
    public TextMeshPro tmpText;           // Reference to 3D TMP text
    public Color normalColor = Color.white;
    public Color collisionColor = Color.red;

    void Start()
    {
        if (tmpText != null)
        {
            tmpText.text = "Waiting for collision...";
            tmpText.color = normalColor;
        }
        else
        {
            Debug.LogWarning("TMP Text reference not set in Inspector!");
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        Debug.Log(other.gameObject.name + " just collided with me!");

        if (tmpText != null)
        {
            

            tmpText.text = "Me Collided with " + other.gameObject.name + "!";
            tmpText.color = collisionColor;
        }

        // If the object we hit is called "Board", rotate randomly
        if (other.gameObject.name == "Board")
        {
            // Generate a random rotation
            Quaternion randomRotation = Random.rotation;
            transform.rotation = randomRotation;

            // Optional: update TMP text to reflect rotation
            if (tmpText != null)
                tmpText.text = "Hit Board! Rotated randomly!";
        }
    }

    private void OnCollisionExit(Collision other)
    {
        Debug.Log(other.gameObject.name + " stopped colliding with me!");

        if (tmpText != null)
        {
            tmpText.text = "Collision ended.";
            tmpText.color = normalColor;
        }
    }
}
