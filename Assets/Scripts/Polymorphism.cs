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

public class Polymorphism : MonoBehaviour
{
    void Start()
    {
        Animal dog = new Dog();
        Animal sheep = new Sheep();
        Animal cow = new Cow();
        Animal chicken = new Chicken();

        dog.MakeSound();
        sheep.MakeSound();
        cow.MakeSound();
        chicken.MakeSound();
    }
}
