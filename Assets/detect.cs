using UnityEngine;
using Unity.Netcode;

public class detect : NetworkBehaviour
{
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name == "Board")
        {
            Quaternion randomRotation = Random.rotation;

            if (rb != null)
                rb.MoveRotation(randomRotation);
            else
                transform.rotation = randomRotation;
        }
    }
}
