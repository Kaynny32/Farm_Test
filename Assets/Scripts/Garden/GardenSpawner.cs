using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GardenSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject _grassPrefabs;
    [SerializeField]
    Transform _pointPosition;
    [SerializeField]
    Transform _pointPosition1;
    [SerializeField]
    BoxCollider _boxCollider;
    [SerializeField]
    DotweenAnim _anim;
    [SerializeField]
    int _idDestroy;
    
    float _time = 10.0f;
    GameObject obj;

    public bool _isTimer = false;
    public bool _activ = true;
    public static GardenSpawner instance = null;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerController>())
        {
            Spawn();
            _boxCollider.enabled = false;
        }
    }

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
            }
            else
            {
                _boxCollider.enabled = true;
                _isTimer = false;
                _time = 10.0f;
            }
        }
    }
    
    void Spawn()
    {
        var activ = true;
        if (_activ)
        {
            GameObject _grassListClone;
            _grassListClone = Instantiate(_grassPrefabs, _pointPosition);
            _anim.AnimGrass(_grassListClone, _pointPosition1, 14.0f, false);
            _activ = false;
            HeightGrass.instance.Timer(activ);
            obj = _grassListClone;
        }
    }
    public void GrassCloneDestroy()
    {
        Destroy(obj);
    }
}
