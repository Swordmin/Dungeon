using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] private string _name;
    [SerializeField] private float _health;
    [SerializeField] private float _damage;

    [SerializeField] private Room _room;
    public void Damage(float value)
    {
        _health -= value;
        if (_health <= 0)
            Die();
    }

    public bool isLive() => _health >= 0 ? true : false;

    public void SetRoom(Room room) 
    {
        _room = room;
    }

    private void Die() 
    {
        _room.Clear();
        GetComponent<MeshRenderer>().enabled = false;

    }

}
