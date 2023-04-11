using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class PackOfGrass : MonoBehaviour
{
    [SerializeField]
    Collider _collider;
    public void PickUpedByPlayer()
    {
        StartCoroutine(Anim());
    }
    IEnumerator Anim()
    {
        _collider.enabled = false;
        transform.DOScale(new Vector3(0,0,0),0.5f);
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
}
