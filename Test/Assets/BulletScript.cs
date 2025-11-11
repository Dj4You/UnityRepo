using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(Collider))]
public class BulletScript : MonoBehaviour
{
    [SerializeField] private float speed = 20f;
    [SerializeField] private float lifeTime = 5f;
    [SerializeField] private int damage = 25;

    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
        rb.collisionDetectionMode = CollisionDetectionMode.Continuous;
    }

    private void OnEnable()
    {
        rb.linearVelocity = transform.forward * speed;
        Invoke(nameof(Kill), lifeTime);
    }

    private void OnCollisionEnter(Collision hit)
    {
        var hp = hit.transform.GetComponent<HealthScript>();
        if (hp != null) hp.TakeDamage(damage);
        Kill();
    }

    private void Kill()
    {
        Destroy(gameObject);
    }
}
