using System.Collections;
using UnityEngine;
using DG.Tweening;

public class GrassBlock : MonoBehaviour
{
    [SerializeField]
    GameObject _grassItem;
    [SerializeField]
    float _destroyAnimSpeed, _resetAnimSpeed;
    [SerializeField] GameObject _grassMesh;
    public void GetHit()
    {
        _grassMesh.transform.DOScale(Vector3.zero, _destroyAnimSpeed);
        GetComponent<Collider>().enabled = false;
        DropBlock();
        StartCoroutine(RespawnGrass());
    }
    void DropBlock()
    {
        var clone = Instantiate(_grassItem, transform.position, Quaternion.identity);
        clone.GetComponent<Rigidbody>().AddForce(Vector3.up * 5.5f, ForceMode.Impulse);
        clone.GetComponent<Rigidbody>().AddTorque(new Vector3(Random.Range(-1f,1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f)));
    }
    IEnumerator RespawnGrass()
    {
        _grassMesh.transform.DOScale(Vector3.one, _resetAnimSpeed).SetDelay(_destroyAnimSpeed);
        yield return new WaitForSeconds(_resetAnimSpeed);
        GetComponent<Collider>().enabled = true;
    }

}
