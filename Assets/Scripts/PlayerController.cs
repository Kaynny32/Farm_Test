using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Scripts")]
    [SerializeField]
    DotweenAnim _anim;

    [Header("Block")]
    [SerializeField]
    GameObject _prefabsBlock;
    List<GameObject> _prefabsBlockClone = new List<GameObject>();
    [SerializeField]
    Transform _spawnPointblock;

    [Header("Backpack")]
    [SerializeField]
    GameObject _prefabsBackpack;
    [SerializeField]
    List<GameObject> _prefabsBackpackkClone = new List<GameObject>();
    [SerializeField]
    Transform _spawnPointBackpack;

    [Header("DOTween")]
    [SerializeField]
    Transform _point;

    bool _activ = true;

    public static PlayerController instance = null;

    void Awake()
    {
        if (instance == null)
            instance = this;
    } 
    public void SpawnBlock()
    {
        _prefabsBlockClone.Add(Instantiate(_prefabsBlock, _spawnPointblock));        
    }
    public void BackpackSpawn()
    {
        _prefabsBackpackkClone.Add(Instantiate(_prefabsBackpack, _spawnPointBackpack));
        Destroy(_prefabsBlockClone[0]);
        _prefabsBlockClone.RemoveAt(0);
        ScoreP();
    }
    public void BackpackDestroy()
    {
         _anim.AnimDOT(_prefabsBackpackkClone[0], _point, 3.5f, false);
        Loom.QueueOnMainThread(() =>
        {
            Destroy(_prefabsBackpackkClone[0]);
            _prefabsBackpackkClone.RemoveAt(0);
            ScoreM();
        },4f);
        
    }
    private void ScoreP()
    {
        if (_prefabsBackpackkClone.Count <= 40)
        {
            GameManager.instance.ScoreBlockInt++;
        }
        else if (_prefabsBackpackkClone.Count >= 40)
        {
            Destroy(_prefabsBackpackkClone[0]);
            _prefabsBackpackkClone.RemoveAt(0);
        }
    }
    private void ScoreM()
    {
        GameManager.instance.ScoreBlockInt--;
        GameManager.instance.ScoreMonyInt += 15;
    }
}
