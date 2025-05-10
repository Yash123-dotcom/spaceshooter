using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float movespeed = 5f;
    public GameObject bulletprefab;
    public Transform Firepoint;
    public TextMeshProUGUI gameovertext;
    public TextMeshProUGUI healthtext;
    
    // Shield variables
    public GameObject shieldObject; // Assign shield sprite/effect in Inspector
    public int maxShieldHits = 3;
    private int currentShieldHits = 0;
    public TextMeshProUGUI shieldText;

    private bool isGameover = false;
    public int maxhealth = 3;
    public int currenthealth;

    void Start()
    {
        currenthealth = maxhealth;
        UpdateHealthUI();
        if (gameovertext != null)
            gameovertext.gameObject.SetActive(false);
        shieldObject.SetActive(false); // Start with shield inactive
    }

    void Update()
    {
        if (isGameover) return;
        HandleMovement();
        HandleShooting();
    }

    void HandleMovement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        transform.Translate(Vector2.right * horizontal * movespeed * Time.deltaTime);
    }

    void HandleShooting()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            Shoot();
    }

    void Shoot()
    {
        if (bulletprefab != null && Firepoint != null)
            Instantiate(bulletprefab, Firepoint.position, Quaternion.identity);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            if (currentShieldHits > 0)
            {
                currentShieldHits--;
                UpdateShieldUI();
                if (currentShieldHits <= 0)
                    shieldObject.SetActive(false);
            }
            else
            {
                TakeDamage(1);
            }
        }
        else if (other.CompareTag("ShieldPowerup"))
        {
            ActivateShield(maxShieldHits);
            Destroy(other.gameObject);
        }
    }

    void ActivateShield(int hits)
    {
        currentShieldHits = hits;
        shieldObject.SetActive(true);
        UpdateShieldUI();
    }

    void TakeDamage(int damage)
    {
        currenthealth -= damage;
        UpdateHealthUI();
        if (currenthealth <= 0)
            GameOver();
    }

    void UpdateHealthUI()
    {
        if (healthtext != null)
            healthtext.text = "Health: " + currenthealth;
    }

    void UpdateShieldUI()
    {
        if (shieldText != null)
            shieldText.text = "Shield: " + currentShieldHits;
    }

    void GameOver()
    {
        isGameover = true;
        if (gameovertext != null)
            gameovertext.gameObject.SetActive(true);
    }
}
