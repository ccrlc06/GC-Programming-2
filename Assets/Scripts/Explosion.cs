using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public GameObject particlePrefab;
    public WeaponType weaponType;

    void CreateParticle(float rotation, float speed)
    {
        GameObject particle = Instantiate(particlePrefab, transform.position, Quaternion.Euler(0.0f, 0.0f, rotation));
        particle.GetComponent<Rigidbody2D>().velocity = particle.transform.right * speed;
    }

    void OnDestroy()
    {
        // By forwarding the weapon type from Player.cs to Explosion.cs,
        // we lay the foundation to create weapon-specific special effects!
        if (weaponType == WeaponType.GRENADE)
        {
            float rotation = 0.0f;
            float step = 45.0f;
            float speed = 5.0f;

            for (int i = 0; i < 8; i++)
            {
                CreateParticle(rotation, speed);
                rotation += step;
            }
        }
    }
}
