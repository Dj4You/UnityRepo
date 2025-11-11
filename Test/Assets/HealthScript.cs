using UnityEngine;

public class HealthScript : MonoBehaviour
{
    [SerializeField] private int maxHP = 100;
    private int currentHP;

    private void Awake()
    {
        currentHP = maxHP;
    }

    public void TakeDamage(int amount)
    {
        currentHP -= amount;
        if (currentHP <= 0)
        {
            Destroy(gameObject);
        }
    }
}
