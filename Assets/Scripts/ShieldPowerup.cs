using UnityEngine;

public class ShieldPowerup : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Destroy(gameObject); // Destroy powerup on pickup
        }
    }
}
