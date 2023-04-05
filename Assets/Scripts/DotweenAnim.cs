using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using DG.Tweening;


public class DotweenAnim : MonoBehaviour
{
    public void AnimDOT(GameObject obg, Transform point, float duretion, bool snapping)
    {
        obg.transform.DOMove(point.position, duretion, snapping);
    }
    public void AnimGrass(GameObject obg, Transform point, float duretion, bool snapping)
    {
        obg.transform.DOMove(point.position, duretion, snapping);
    }
}
