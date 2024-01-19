using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal
{
    public virtual void MakeSound()
    {
        Debug.Log("**Generic animal noises**");
    }
}

public class Dog : Animal
{
    public override void MakeSound()
    {
        Debug.Log("WOOF!");
    }
}

public class Sheep : Animal
{
    public override void MakeSound()
    {
        Debug.Log("Baaaaaaaaaaaaa");
    }
}

public class Cow : Animal
{
    public override void MakeSound()
    {
        Debug.Log("MOOOOOOOOOOOOOOOOOOOOOOOOO");
    }
}

public class Chicken : Animal
{
    public override void MakeSound()
    {
        Debug.Log("Buck buck buck...");
    }
}

public enum AnimalType
{
    DOG,
    SHEEP,
    COW,
    CHICKEN
}

public class Polymorphism : MonoBehaviour
{
    void MakeSound(AnimalType animal)
    {
        switch (animal)
        {
            case AnimalType.DOG:
                DogSound();
                break;

            case AnimalType.SHEEP:
                SheepSound();
                break;

            case AnimalType.COW:
                CowSound();
                break;

            case AnimalType.CHICKEN:
                ChickenSound();
                break;
        }
    }

    void DogSound()
    {
        Debug.Log("WOOF!");
    }

    void SheepSound()
    {
        Debug.Log("Baaaaaaaaaaaaa");
    }

    void CowSound()
    {
        Debug.Log("MOOOOOOOOOOOOOOOOOOOOOOOOO");
    }

    void ChickenSound()
    {
        Debug.Log("Buck buck buck...");
    }

    void Start()
    {
        // New way (automatic)
        Animal[] animals1 = {
            new Dog(),
            new Sheep(),
            new Cow(),
            new Chicken()
        };

        for (int i = 0; i < animals1.Length; i++)
        {
            animals1[i].MakeSound();
        }

        // Old way (manual)
        AnimalType[] animals2 =
        {
            AnimalType.DOG, AnimalType.SHEEP, AnimalType.COW, AnimalType.CHICKEN
        };

        for (int i = 0; i < animals2.Length; i++)
        {
            MakeSound(animals2[i]);
        }

        // Homework hint: you'll want to change your weapon based on the pad you've collider with.
        // For example,
        // Weapon weapon = new Rifle();
        // OnCollision:
        //      if shotgun, weapon = new Shotgun
    }
}
