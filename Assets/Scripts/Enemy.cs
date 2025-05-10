using UnityEngine;

public class Enemy : MonoBehaviour
{
    public bool hashealthpack = true;

    void Update()
    {
        // Move the enemy downward
        transform.Translate(Vector3.down * 2f * Time.deltaTime);

        // Destroy if off-screen
        if (transform.position.y < -6f)
        {
            Destroy(gameObject);
        }
    }
}
