using UnityEngine;

public class EnemyMoveAuto : MonoBehaviour
{
    public float speed = 2f;         // Tốc độ di chuyển
    public float changeTime = 2f;    // Thời gian đổi hướng

    private Vector2 movementDirection;
    private Rigidbody2D rb;
    private float timer;



    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ChangeDirection();
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            ChangeDirection();
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movementDirection * speed * Time.fixedDeltaTime);
    }

    void ChangeDirection()
    {
        int randomDirection = Random.Range(0, 4); // Chọn hướng ngẫu nhiên: 0 = trái, 1 = phải, 2 = lên, 3 = xuống

        switch (randomDirection)
        {
            case 0: movementDirection = Vector2.left; break;
            case 1: movementDirection = Vector2.right; break;
            case 2: movementDirection = Vector2.up; break;
            case 3: movementDirection = Vector2.down; break;
        }

        timer = changeTime; // Reset timer
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Wall") || collision.gameObject.CompareTag("Bomb")) // Nếu va chạm với tường, đổi hướng
        {
           
            ChangeDirection();
        }

        if (collision.gameObject.CompareTag("Enemy")){
            Debug.Log("ĐÃ CHẠM NHAU");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Explosion"))
        {
            gameObject.SetActive(false);
        }
    }
}
