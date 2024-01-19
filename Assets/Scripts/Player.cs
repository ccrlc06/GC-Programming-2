using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WeaponType
{
    RIFLE,
    SHOTGUN,
    GRENADE
}

public class Player : MonoBehaviour
{
    public GameObject projectilePrefab;
    WeaponType weaponType;

    //Rigidbody2D rb;
    float moveSpeed = 10.0f;    // Move at 10 units per second
    float turnSpeed = 360.0f;   // Turn at 360 degrees per second

    void Start()
    {
        //rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float dt = Time.deltaTime;

        if (Input.GetKey(KeyCode.E))
        {
            transform.Rotate(0.0f, 0.0f, -turnSpeed * dt);
        }

        else if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(0.0f, 0.0f, turnSpeed * dt);
        }

        // A quaternion represents a rotation.
        // A vector represents a direction.
        // We get our direction vector by taking whatever direction we want a rotation of 0 to be (Vector3.right in this case),
        // and multiply it by our transfor's rotation which is a quaternion.
        //Vector3 direction = transform.rotation * Vector3.right;
        //Vector3 direction = transform.right;    // automatic version of the above

        // We can use trigonometry to convert directions to angles and angles to directions
        // (This is unnecessary for the actual implementation, just review)
        //float angle = Mathf.Atan2(direction.y, direction.x);
        //direction = new Vector3(Mathf.Cos(angle), Mathf.Sin(angle));
        //Debug.Log(angle * Mathf.Rad2Deg);
        Debug.DrawLine(transform.position, transform.position + transform.right * 10.0f);

        Vector3 velocity = Vector3.zero;
        if (Input.GetKey(KeyCode.W))
        {
            velocity += transform.right;
        }
        
        else if (Input.GetKey(KeyCode.S))
        {
            velocity -= transform.right;
        }
        
        if (Input.GetKey(KeyCode.A))
        {
            velocity += transform.up;
        }
        
        else if (Input.GetKey(KeyCode.D))
        {
            velocity -= transform.up;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            switch (weaponType)
            {
                case WeaponType.RIFLE:
                    CreateRifle(transform.right, moveSpeed * 5.0f);
                    break;

                case WeaponType.SHOTGUN:
                    CreateShotgun(transform.right, moveSpeed * 2.5f);
                    break;

                case WeaponType.GRENADE:
                    CreateGrenade(transform.right, moveSpeed);
                    break;
            }
        }

        transform.position += velocity * moveSpeed * dt;
        // "switch" is equivalent to the following (basically a fancy if-statement):
        //if (weaponType == WeaponType.RIFLE)
        //    color = Color.red;
        //if (weaponType == WeaponType.SHOTGUN)
        //    color = Color.green;
        //if (weaponType == WeaponType.GRENADE)
        //    color = Color.blue;
        //GetComponent<SpriteRenderer>().color = color;
    }

    GameObject CreateProjectile(Vector3 direction, float speed, Color color)
    {
        GameObject projectile = Instantiate(projectilePrefab);
        projectile.transform.position = transform.transform.position + direction;
        projectile.GetComponent<Rigidbody2D>().velocity = direction * speed;
        projectile.GetComponent<SpriteRenderer>().color = color; 
        return projectile;
    }

    void CreateRifle(Vector3 direction, float speed)
    {
        CreateProjectile(direction, speed, Color.red);
    }

    void CreateShotgun(Vector3 direction, float speed)
    {
        CreateProjectile(Quaternion.Euler(0.0f, 0.0f, -30.0f) * direction, speed, Color.green);
        CreateProjectile(direction, speed, Color.green);
        CreateProjectile(Quaternion.Euler(0.0f, 0.0f, 30.0f) * direction, speed, Color.green);   
    }

    void CreateGrenade(Vector3 direction, float speed)
    {
        GameObject grenade = CreateProjectile(direction, speed, Color.blue);
        grenade.GetComponent<Explosion>().weaponType = weaponType;
        Destroy(grenade, 0.5f);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Rifle"))
            weaponType = WeaponType.RIFLE;

        else if (collision.CompareTag("Shotgun"))
            weaponType = WeaponType.SHOTGUN;

        else if (collision.CompareTag("Grenade"))
            weaponType = WeaponType.GRENADE;
    }
}
