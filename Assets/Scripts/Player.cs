using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] private float _health, _maxHealth;
    [SerializeField] private float _defence, _maxDefence;
    [SerializeField] private float _agility, _force;

    [SerializeField] private Weapon _weapon;
    [SerializeField] private Room _room;

    public void Heal(float value) 
    {
        _health += value;
        if (_health > _maxHealth)
            _health = _maxHealth;
    }

    public void Damage() 
    {
        
    }
    public void SetWeapon(Weapon weapon) 
    {
        _weapon = weapon; 
    }
    public Weapon GetWeapon() => _weapon;

    public void Atack() 
    {
        if (_room.GetEnemy().isLive() && _weapon.isAtack)
        {
            _weapon.Atack();
            _room.GetEnemy().Damage(GetDamage());
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.TryGetComponent(out Room room)) 
        {
            _room = room;
        }
    }

    public float GetDamage() => _force + _weapon.GetDamage;

    public void Go()
    {
        if (_room.isClear()) 
        {
            _room.OpenDoor();
        }
    }
}
