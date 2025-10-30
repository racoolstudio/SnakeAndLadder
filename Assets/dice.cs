using System.Collections.Generic;
using UnityEngine;

public class CupDiceHold : MonoBehaviour
{
    [Header("Cup Trigger")]
    public Transform cupTrigger;            // Child trigger inside the cup
    public List<Rigidbody> dice = new List<Rigidbody>();

    [Header("Settings")]
    public float holdForce = 50f;          // Force to keep dice in cup
    public float tipAngle = 120f;          // Degrees at which dice are allowed to fall

    private void FixedUpdate()
    {
        float angle = Vector3.Angle(transform.up, Vector3.up);

        foreach (Rigidbody die in dice)
        {
            if (die == null) continue;

            // Get dice position relative to cup trigger
            Vector3 localPos = cupTrigger.InverseTransformPoint(die.position);
            Vector3 size = ((BoxCollider)cupTrigger.GetComponent<Collider>()).size * 0.5f;

            // Check if dice is inside the cup trigger
            if (Mathf.Abs(localPos.x) < size.x &&
                Mathf.Abs(localPos.y) < size.y &&
                Mathf.Abs(localPos.z) < size.z)
            {
                // Only apply holding force if cup is not tipped
                if (angle < tipAngle)
                {
                    Vector3 toCenter = cupTrigger.position - die.position;
                    die.AddForce(toCenter * holdForce * Time.fixedDeltaTime, ForceMode.Acceleration);
                }
            }
        }
    }
}
