using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject explosionPrefab;

    void Update()
    {
        transform.Translate(Vector3.up * 10f * Time.deltaTime);

        if (transform.position.y > 6f)
        {
            Destroy(gameObject);
        }
    }

   void OnTriggerEnter2D(Collider2D other)
{
    if (other.CompareTag("Enemy"))
    {
        Enemy enemyScript = other.GetComponent<Enemy>();
        if (enemyScript != null && enemyScript.hashealthpack)
        {
            // Find the player and heal
            PlayerController player = FindObjectOfType<PlayerController>();
            // if (player != null)
            // {
                
            //     // Show message (e.g., using UI)
            //     Debug.Log("Health increased"); // Replace with UI update if you want
            // }
        }

        if (explosionPrefab != null)
            Instantiate(explosionPrefab, other.transform.position, Quaternion.identity);

        ScoreManager.instance.Addscore(1);
        Destroy(other.gameObject);
        Destroy(gameObject);
        

    }
}
}
