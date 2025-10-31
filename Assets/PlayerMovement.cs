using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public float speed = 5f; // Movement speed

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Ball1 - WASD movement
        if (gameObject.name == "Ball1")
        {
            float moveX = Input.GetAxis("Horizontal"); // A/D or Left/Right arrow
            float moveY = Input.GetAxis("Vertical");   // W/S or Up/Down arrow

            // Apply movement to the Rigidbody2D
            transform.Translate(new Vector2(moveX, moveY) * speed * Time.deltaTime);
        }

        // Ball2 - Arrow Keys movement
        if (gameObject.name == "Ball2")
        {
            float moveX = 0f;
            float moveY = 0f;

            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
                moveX = Input.GetAxis("Horizontal"); // Arrow keys left/right
            if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow))
                moveY = Input.GetAxis("Vertical");   // Arrow keys up/down

            // Apply movement to the Rigidbody2D
            transform.Translate(new Vector2(moveX, moveY) * speed * Time.deltaTime);
        }
    }
}