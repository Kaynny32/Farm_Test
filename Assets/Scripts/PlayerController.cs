using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;
using TMPro;
using DG.Tweening;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    ThirdPersonControllerAI ThirdPersonControllerAI;

    GrassBlock _tempGrassBlock;

    int _grassCount = 0;
    int _moneyCount;

    [SerializeField]
    TextMeshProUGUI _grassCountText;
    [SerializeField]
    TextMeshProUGUI _moneyCountText;

    [SerializeField]
    GameObject _grassBlock;
    [SerializeField]
    Transform _grassSpawnPoint;

    [SerializeField]
    Transform _shopPoint;

    private void Start()
    {
        _grassCountText.text = _grassCount + "/40";
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<GrassBlock>())
        {
            Attack();
            _tempGrassBlock = other.GetComponent<GrassBlock>();
        }
        if (other.GetComponent<Shop>())
        {
            if (_grassCount > 0)
            {
                other.GetComponent<Shop>().GetGrass(_grassBlock, _shopPoint, _grassSpawnPoint);
                StartCoroutine(GetMoney());
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PackOfGrass>())
        {           
            if (_grassCount < 40)
            {
                other.GetComponent<PackOfGrass>().PickUpedByPlayer();
                PickUp();
            }            
        }        
    }
    
    void Attack()
    {
        ThirdPersonControllerAI.GetAnimator().Play("Attack");
    }
    public void OnAttackFromAnim()
    {
        _tempGrassBlock.GetHit();
    }
    bool _active = false;
    public void PickUp()
    {
        if (_grassCount == 0)
        {
            var go = Instantiate(_grassBlock, _grassSpawnPoint);
            go.GetComponent<ConfigurableJoint>().connectedBody = _grassSpawnPoint.GetComponent<Rigidbody>();
        }
        _grassCount++;
        _grassCountText.text = _grassCount + "/40";
        DOTween.Sequence()
            .Append(_grassCountText.transform.DOScale(new Vector3(0, 0, 0), 0.2f))
            .AppendInterval(0.1f)
            .Append(_grassCountText.transform.DOScale(new Vector3(1, 1, 1), 0.2f));
    }
    IEnumerator GetMoney()
    {
        _grassCount -= 1;
        _moneyCount += 15;
        DOTween.Sequence()
            .Append(_moneyCountText.transform.DOScale(new Vector3(0, 0, 0), 5f))
            .AppendInterval(0.1f)
            .Append(_moneyCountText.transform.DOScale(new Vector3(1, 1, 1), 0.3f));
        yield return new WaitForSeconds(5);        
        _grassCountText.text = _grassCount + "/40";       
        _moneyCountText.text = _moneyCount.ToString();
    }
}
