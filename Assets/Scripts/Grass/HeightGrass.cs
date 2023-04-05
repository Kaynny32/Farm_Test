using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class HeightGrass : MonoBehaviour
{
    [SerializeField]
    BoxCollider _boxCollider;

    float _time = 15f;
    bool _isTimer = false;
    int _hit = 500;

    public static HeightGrass instance = null;
    void Awake()
    {
        if (instance == null)
            instance = this;
    }
    private void FixedUpdate()
    {
        if (_isTimer == true)
        {
            if (_time > 0)
            {
                _time -= Time.fixedDeltaTime;
                _boxCollider.enabled = false;
            }
            else
            {
                _boxCollider.enabled = true;
            }
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerController>())
        {
            if (_hit > 0)
            {
                _hit -= 1;
            }
            else
            {
                Mining();
                other.gameObject.GetComponent<PlayerController>().SpawnBlock();
                _hit = 500;
            }

        }
    }
    public void Timer(bool isActive)
    {
        _isTimer = isActive;
    }
    public void Mining()
    {        
        GardenSpawner.instance._activ = true;
        GardenSpawner.instance._isTimer = true;
        GardenSpawner.instance.GrassCloneDestroy();
    }
}
