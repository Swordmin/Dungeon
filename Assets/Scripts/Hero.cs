using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : Character
{

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            base.Heal(10);
        }
    }

    public override void Atack(Character character)
    {
        base.Atack(character);
    }

    public void GoNextRoom() 
    {
        
    }

}
