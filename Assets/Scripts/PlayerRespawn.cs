using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    private Vector3 startPosition;

    //появление на стартовой позиции уровня при падении за пределы карты

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        if (transform.position.y < -50f) 
        {
            Respawn();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("DeathZone"))
        {
            Respawn();
        }
    }

    private void Respawn()
    {
        transform.position = startPosition;
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.linearVelocity = Vector2.zero;
        }

        Debug.Log("Игрок вернулся на стартовую позицию!");
    }
}
