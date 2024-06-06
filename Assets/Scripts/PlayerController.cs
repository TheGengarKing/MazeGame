using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;

    void Update()
    {
        // Get input for horizontal and vertical movement
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        // Calculate the movement direction based on input
        Vector2 moveDirection = new Vector2(moveX, moveY).normalized;

        // Move the player in the direction
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the player collides with the goal object
        if (collision.gameObject.CompareTag("Goal"))
        {
            // Load the next level using the LevelManager script
            FindObjectOfType<LevelManager>().NextLevel();
        }
    }
}
