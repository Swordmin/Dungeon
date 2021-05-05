using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    [SerializeField] private float _damage;
    [SerializeField] private float _quality;
    [SerializeField] private bool _isCanAtack;

    [SerializeField] private GameObject _weapon;

    public void SetDamage(float value)
    {
        _damage = value;
    }
    public void SeQuality(float value)
    {
        _quality = value;
    }

    public float GetDamage => _damage;
    public float GetQuality => _quality;

    public bool isAtack => _isCanAtack;

    public void Atack()
    {
        _isCanAtack = false;
        _weapon.GetComponent<Animator>().Play("Atack");
        StartCoroutine(AtackTimer());
    }

    private IEnumerator AtackTimer() 
    {
        yield return new WaitForSeconds(1.5f);
        _isCanAtack = true;

    }

}
