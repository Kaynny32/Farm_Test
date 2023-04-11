using DG.Tweening;
using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField]
    float _deley;
    [SerializeField]
    GameObject _prefabscoin;
    [SerializeField]
    GameObject _conteiner;
    [SerializeField]
    Transform _movePoint;

    public void GetGrass(GameObject gameObject, Transform position, Transform backPack)
    {
        StartCoroutine(Grass(gameObject, position, backPack));
        StartCoroutine(GetMoney());
    }
    IEnumerator Grass(GameObject gameObject, Transform position, Transform backPack)
    {
        var go = Instantiate(gameObject, backPack);
        go.transform.DOMove(position.position, 3f, false).SetDelay(_deley);
        yield return new WaitForSeconds(3f);
        Destroy(go);        
    }
    IEnumerator GetMoney()
    {
        var go = Instantiate(_prefabscoin, _conteiner.transform);
        go.transform.DOMove(_movePoint.transform.position, 5f);
        yield return new WaitForSeconds(5f);
        Destroy (go);        
    }
}
