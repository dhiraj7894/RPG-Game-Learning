using UnityEngine;

public class CharecterStats : MonoBehaviour
{
    public int maxHealth = 100;
    int currentHealth;

    public Stat damage;
    public Stat armor;

    private void Awake()
    {
        currentHealth = maxHealth;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            takeDamage(10);
        }
    }

    public void takeDamage(int damage)
    {
        damage -= armor.GetValue();
        damage = Mathf.Clamp(damage, 0, int.MaxValue);

        currentHealth -= damage;
        Debug.Log(transform.name + " take's " + damage + " damage.");
        if(currentHealth <= 0)
        {
            Die();
        }
    }
    public virtual void Die() {

        Debug.Log(transform.name + " Died.");
    }
}
