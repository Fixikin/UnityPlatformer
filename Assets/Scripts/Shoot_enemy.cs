using UnityEngine;

public class Shoot_enemy : MonoBehaviour
{
    public GameObject projectile;
    public Transform shooting_position;
    public float shootInterval = 2f;
    private float shootTimer;

    void Update()
    {
        shootTimer += Time.deltaTime;
        if (shootTimer >= shootInterval)
        {
            Shoot();
            shootTimer = 0;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == Hero.Instance.gameObject)
        {
            Hero.Instance.GetDamage();
        }
    }
    void Shoot()
    {
        Instantiate(projectile, shooting_position.position, Quaternion.identity);
    }
}
