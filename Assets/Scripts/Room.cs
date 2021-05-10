using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum RoomType 
{
    Enemy = 80,
    Empty = 10,
    Gold = 10
}

public class Room : MonoBehaviour
{

    [SerializeField] private RoomType _type;
    [SerializeField] private Character _hero;
    [SerializeField] private Character _enemy;

    [SerializeField] private GameObject _roomTemplate;

    [SerializeField] private Transform _parent;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F)) 
        {
            RoomCreate();
        }
    }

    public void Inititalization() 
    {
        
    }

    public void SetParent(Transform parent) 
    {
        _parent = parent;
    }

    public void RoomCreate() 
    {
        GameObject newRoom = Instantiate(_roomTemplate, new Vector3(transform.position.x, transform.position.y, transform.localPosition.z - 8), Quaternion.identity, _parent);
        Room room = newRoom.GetComponent<Room>();
        room.SetParent(_parent);
    }

}
