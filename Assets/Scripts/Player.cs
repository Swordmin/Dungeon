using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] private float _health, _maxHealth;
    [SerializeField] private float _defence, _maxDefence;
    [SerializeField] private float _agility, _force;

    [SerializeField] private bool _isCanMove;
    [SerializeField] private bool _isCanRoomCreate = true;

    [SerializeField] private Weapon _weapon;
    [SerializeField] private Room _room;

    [SerializeField] private List<Item> _items = new List<Item>();

    private void Update()
    {
        if (_isCanMove)
            transform.Translate(new Vector3(0, 0, 4 * Time.deltaTime));
    }

    public void Heal(float value) 
    {
        _health += value;
        if (_health > _maxHealth)
            _health = _maxHealth;
    }

    public void TakeDamage(float damage) 
    {
        _health -= damage;
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
            _room.GetEnemy().TakeDamage(GetDamage());
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.TryGetComponent(out Room room)) 
        {
            _room = room;
            _isCanMove = false;
            _isCanRoomCreate = true;
        }
    }

    public float GetDamage() => _force + _weapon.GetDamage;

    public void Go()
    {
        if (_room.isClear() && _isCanRoomCreate) 
        {
            _room.OpenDoor();
            _isCanMove = true;
            _isCanRoomCreate = false;
        }
    }
}
