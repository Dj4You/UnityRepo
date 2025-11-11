using UnityEngine;
#if ENABLE_INPUT_SYSTEM
using UnityEngine.InputSystem;
#endif

public class CharacterScript : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firePoint;
    [SerializeField] private float muzzleOffset = 1.2f;
    [SerializeField] private float bulletCooldown = 0.25f;

    private float lastShotTime = 0f;

    private void Update()
    {
        bool shootPressed = false;

#if ENABLE_INPUT_SYSTEM
        if (Keyboard.current != null && Keyboard.current.spaceKey.wasPressedThisFrame)
            shootPressed = true;
#else
        if (Input.GetKeyDown(KeyCode.Space))
            shootPressed = true;
#endif

        if (shootPressed)
            Shoot();
    }

    private void Shoot()
    {
        // Не стрелять слишком часто
        if (Time.time - lastShotTime < bulletCooldown) return;
        lastShotTime = Time.time;

        // Определяем, откуда появится пуля
        Vector3 spawnPos = firePoint != null
            ? firePoint.position
            : transform.position + transform.forward * muzzleOffset;

        Quaternion spawnRot = transform.rotation;

        Instantiate(bulletPrefab, spawnPos, spawnRot);
    }
}
