using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType 
{
    Resources = 0,
    Weapon = 1,
    Gold = 2
}

public class Item : MonoBehaviour
{

    [SerializeField] ItemType _type;

    public void Init() 
    {
    
    }

}
