using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroContainer : MonoBehaviour
{
    public Hero hero;

    // Use this for initialization
    void Start()
    {
        hero = new Hero();
    }
}
