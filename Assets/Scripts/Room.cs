using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{

    [SerializeField] private Enemy _enemy;
    [SerializeField] private GameObject _door;
    [SerializeField] private GameObject _room;

    [SerializeField] private bool _isClear;

    private void OnEnable()
    {
        Init();
        _enemy.SetRoom(this);
    }

    private void Start()
    {
        CreateRoom();
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
        
    }

    private void CreateRoom() 
    {
        Instantiate(_room, new Vector3(transform.position.x, transform.position.y, transform.position.z + 4),Quaternion.identity);
    }

}
