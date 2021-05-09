using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private float _health;
    private float __health 
    {
        get { return _health; }
        set 
        {
            if (value < _maxHealth)
                _health = value;
            else
                _health = _maxHealth;
            if (value <= 0)
                Die();
        }
    }
    [SerializeField] private float _maxHealth;
    [SerializeField] private float _agility;
    private float __agility 
    {
        get { return _agility; }
        set 
        {
            if (value < _maxAgility)
                _agility = value;
            else
                _agility = _maxAgility;
        }
    }
    [SerializeField] private float _maxAgility;

    [SerializeField] private float _damage { get { return GetDamage(); } }

    [SerializeField] private float _force;
    [SerializeField] private float _defence;

    public virtual void Atack(Character character) 
    {
        character.TakeDamage(_damage);
    }
    
    public virtual void TakeDamage(float damage) 
    {
        
    }

    public virtual void Die() 
    {
    
    }

    public virtual void Heal(float heal)
    {
        __health += heal;
    }
    public virtual float GetDamage() 
    {
        return _force;
    }


}
