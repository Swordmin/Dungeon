using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] private string _name;
    [SerializeField] private float _health;
    [SerializeField] private float _damage;

    [SerializeField] private Room _room;

    public Enemy(float health, float damage) 
    {
        _health = health;
        _damage = damage;
        //GetComponent<MeshFilter>().mesh = mesh;
    }
    
    public void SetEnemy(Enemy enemy)
    {
        _name = enemy.GetName();
        _health = enemy.GetHealth();
        _damage = enemy.GetDamage();
    }

    public void TakeDamage(float value)
    {
        _health -= value;
        if (_health <= 0)
            Die();
    }

    public string GetName() => _name;
    public float GetHealth() => _health;
    public float GetDamage() => _damage;
    public bool isLive() => _health >= 0 ? true : false;

    public void SetRoom(Room room) 
    {
        _room = room;
    }

    private void Atack(Player player) 
    {
        player.TakeDamage(_damage);
    }

    private void Die() 
    {
        _room.Clear();
        GetComponent<MeshRenderer>().enabled = false;

    }

}
