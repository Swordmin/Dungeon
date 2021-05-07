using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{

    [SerializeField] private Enemy _enemy;
    [SerializeField] private GameObject _enemyPref;
    [SerializeField] private GameObject _door;
    [SerializeField] private GameObject _room;

    [SerializeField] private Transform _parent;
    [SerializeField] private Transform _spawnEnemy;

    [SerializeField] private bool _isClear;

    [SerializeField] private bool _playerTurn = true;

    private void OnEnable()
    {
        Init();
    }

    public Enemy GetEnemy() => _enemy;
    public void OpenDoor() 
    {
        CreateRoom();
        _door.GetComponent<Animator>().Play("DoorOpen");
    }

    public void Clear() 
    {
        _isClear = true;
    }
    public bool isClear() => _isClear;

    private void Init() 
    {
        Enemy enemy = new Enemy(10,5);
        GameObject enemyCreate = Instantiate(_enemyPref, _spawnEnemy.position, Quaternion.identity, _spawnEnemy);
        _enemy = enemyCreate.GetComponent<Enemy>();
        _enemy.SetRoom(this);
        _enemy.SetEnemy(enemy);
    }

    private void CreateRoom() 
    {
        Instantiate(_room, new Vector3(transform.position.x, transform.position.y, transform.position.z + 8),Quaternion.identity, _parent);
    }

    public void NextTurn() 
    {
        if (_playerTurn) 
        {
            _playerTurn = false;
        }
        else 
        {
            _playerTurn = true;
        }
    }

}
