using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 100f;
    private float currentHealth;

    public Text healthText; // Reference to the UI Text component

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthUI(); // Call the method to update the UI at the start
    }

    public void TakeDamage(float damageAmount)
    {
        if (currentHealth > 0f)
        {
            currentHealth -= damageAmount;
            UpdateHealthUI(); // Call the method to update the UI after taking damage

            if (currentHealth <= 0f)
            {
                Die();
            }
        }
    }

    void Die()
    {
        Debug.Log("Player has died.");
        // Implement any additional logic for player death (e.g., respawn or game over).
    }

    public void Heal(float healAmount)
    {
        currentHealth = Mathf.Min(currentHealth + healAmount, maxHealth);
        UpdateHealthUI(); // Call the method to update the UI after healing
    }

    void UpdateHealthUI()
    {
        // Update the UI Text component with the current health value
        if (healthText != null)
        {
            healthText.text = "Health: " + currentHealth.ToString("F0"); // F0 to display as an integer
        }
    }
}