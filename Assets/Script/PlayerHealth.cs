using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 3;
    public int currentHealth;
    public AudioSource audioSource;
    public AudioClip sound;
    public AudioClip sound2;
    public AudioClip sound3;

    public HealthBar healthBar;
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            TakeDamage(1);
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        audioSource.PlayOneShot(sound);
        if (currentHealth > 0)
        {
            audioSource.PlayOneShot(sound3);
        }
        healthBar.SetHealth(currentHealth);
        if (currentHealth < 1)
        {
            audioSource.PlayOneShot(sound2);
            Time.timeScale = 0;
            Die();
        }
        return;
    }

    public void Die()
    {
        GameOverManager.instance.OnPlayerDeath();
    }
}


