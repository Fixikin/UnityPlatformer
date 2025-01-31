using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public float distance;

    private void Start()
    {
        //При появлении начинаем рутину Death, которая уничтожает объект через 5 (если никуда не попала)
        StartCoroutine(Death());
    }

    private void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }

    private IEnumerator Death()
    {
        yield return new WaitForSeconds(5f);
        if (gameObject !=  null )
        {
            Destroy(gameObject);
        }
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Если пуля попадает во что-то - она уничтожается. Если в ГГ - он получает урон
        if (collision.gameObject == Hero.Instance.gameObject)
        {
            Hero.Instance.GetDamage();
        }
        Destroy(gameObject);
    }
}
