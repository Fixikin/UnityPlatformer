using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static UnityEngine.Rendering.DebugUI;

public class Hero : MonoBehaviour
{
    [SerializeField] private float speed = 3f; // скорость
    [SerializeField] private int maxlives = 7; // жизни
    [SerializeField] private float jump_force = 15f; // сила прыжка

    public Slider livesBar;
    public int lives;

    private bool isGrounded = false;

    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer sprite;
    private Vector3 startPosition;

    public static Hero Instance { get; set; }

    void Start()
    {
        startPosition = transform.position;
        lives = maxlives;
        UpdateLivesUI();
    }

    //полоска жизней обновляется 
    void UpdateLivesUI()
    {
        if (livesBar!= null)
        {
            livesBar.value = (float)lives / maxlives;
        }
    }

    //функция получения урона
    public void GetDamage()
    {
        lives -= 1;
        Debug.Log(lives);
        UpdateLivesUI();
        if (lives == 0)
        {
            Respawn();
        }
    }

    //появление ГГ на старте уровня с полным запасом здоровья
    private void Respawn()
    {
        transform.position = startPosition;
        lives = 7;
        Debug.Log(lives);
        UpdateLivesUI();
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.linearVelocity = Vector2.zero;
        }

        Debug.Log("Игрок вернулся на стартовую позицию!");
    }


    private States State
    {
        get { return (States)anim.GetInteger("state"); }
        set { anim.SetInteger("state", (int)value); }
    }

    private void Awake()
    {
        Instance = this;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponentInChildren<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        CheckGround();
    }

    //бег и прыжок
    private void Update()
    {
        if (isGrounded) State = States.idle;

        if (Input.GetButton("Horizontal"))
            Run();
        if (isGrounded && Input.GetButtonDown("Jump"))
            Jump();
    }

    private void Run()
    {
        if (isGrounded) State = States.run;

        Vector3 dir = transform.right * Input.GetAxis("Horizontal");
        transform.position = Vector3.MoveTowards(transform.position, transform.position + dir, speed * Time.deltaTime);
        sprite.flipX = dir.x < 0.0f;
    }

    private void Jump()
    {
        rb.AddForce(transform.up * jump_force, ForceMode2D.Impulse);
    }

    //Проверка, на земле или нет
    private void CheckGround()
    {
        Collider2D[] collider = Physics2D.OverlapCircleAll(transform.position, 0.3f);
        isGrounded = collider.Length > 1;

        if (!isGrounded) State = States.jump;
    }

}
public enum States
{
    idle,
    run,
    jump
}
