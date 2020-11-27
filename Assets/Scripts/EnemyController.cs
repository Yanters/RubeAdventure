using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public ParticleSystem smokeEffect;
    bool broken = true;
    public float speed;
    public bool vertical;
    public float changeTime = 3.0f;

    Rigidbody2D Enemyrigidbody2D;
    float timer;
    int direction = 1;

    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        Enemyrigidbody2D = GetComponent<Rigidbody2D>();
        timer = changeTime;
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (!broken) return;



        timer -= Time.deltaTime;

        if (timer < 0)
        {
            direction = -direction;
            timer = changeTime;
        }

    }

    void FixedUpdate()
    {
        if (!broken) return;



        Vector2 position = Enemyrigidbody2D.position;

        if (vertical)
        {
            position.y = position.y + Time.deltaTime * speed * direction;
            animator.SetFloat("Move X", 0);
            animator.SetFloat("Move Y", direction);
        }
        else
        {
            position.x = position.x + Time.deltaTime * speed * direction;
            animator.SetFloat("Move X", direction);
            animator.SetFloat("Move Y", 0);
        }

        Enemyrigidbody2D.MovePosition(position);

    }

    void OnCollisionEnter2D(Collision2D other)
    {
        RubyController player = other.gameObject.GetComponent<RubyController>();

        if (player != null)
        {
            player.ChangeHealth(-1);
        }
    }

    public void Fix()
    {
        animator.SetTrigger("Fixed");
        smokeEffect.Stop();
        broken = false;
        Enemyrigidbody2D.simulated = false;
    }

}
