using UnityEngine;

public class DiceRollWithBoardCheck : MonoBehaviour
{
    public Collider boardCollider;          // assign the board collider in inspector
    public float forceAmount = 10f;
    public float torqueAmount = 10f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        if (boardCollider == null)
        {
            Debug.LogError("Board Collider is not assigned!");
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (IsOnBoard())
            {
                RollDice();
            }
            else
            {
                Debug.Log("Dice is not on the board!");
            }
        }
    }

    bool IsOnBoard()
    {
        if (boardCollider == null) return false;

        Vector3 dicePos = transform.position;
        Bounds boardBounds = boardCollider.bounds;

        return boardBounds.Contains(dicePos);
    }

    void RollDice()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z);
        transform.rotation = Random.rotation;

        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;

        Vector3 randomForce = new Vector3(
            Random.Range(-1f, 1f),
            1f,
            Random.Range(-1f, 1f)
        ).normalized * forceAmount;

        Vector3 randomTorque = new Vector3(
            Random.Range(-1f, 1f),
            Random.Range(-1f, 1f),
            Random.Range(-1f, 1f)
        ).normalized * torqueAmount;

        rb.AddForce(randomForce, ForceMode.Impulse);
        rb.AddTorque(randomTorque, ForceMode.Impulse);
    }
}
