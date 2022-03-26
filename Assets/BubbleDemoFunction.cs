using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class BubbleDemoFunction : MonoBehaviour
{
  private bool isActivated = false;
  public void Weather()
  {
    if (!isActivated)
    {
      gameObject.SetActive(true);
      GetComponent<CanvasGroup>().DOFade(1f, 0.4f);
      var target = transform.position;
      transform.position = transform.position - Vector3.one;
      transform.DOMove(target, 0.4f);
      isActivated = true;
    }
    else
    {
      GetComponent<CanvasGroup>().DOFade(0f, 0.4f);
      var target = transform.position;
      transform.position = transform.position + Vector3.one;
      transform.DOMove(target, 0.4f);
      isActivated = false;
    }
    
  }
  public void Wallet()
  {
    if (!isActivated)
    {
      gameObject.SetActive(true);
      GetComponent<CanvasGroup>().DOFade(1f, 0.4f);
      var target = transform.position;
      transform.position = transform.position + Vector3.one;
      transform.DOMove(target, 0.4f);
      isActivated = true;

    }
    else
    {
      GetComponent<CanvasGroup>().DOFade(0f, 0.4f);
      var target = transform.position;
      transform.position = transform.position - Vector3.one;
      transform.DOMove(target, 0.4f);
      isActivated = false;

    }
    
  }
  public void Music()
  {
    if (!isActivated)
    {
      gameObject.SetActive(true);
      GetComponent<CanvasGroup>().DOFade(1f, 0.4f);
      var target = transform.position;
      transform.position = transform.position + Vector3.one;
      transform.DOMove(target, 0.4f);
      isActivated = true;

    }
    else
    {
      GetComponent<CanvasGroup>().DOFade(0f, 0.4f);
      var target = transform.position;
      transform.position = transform.position - Vector3.one;
      transform.DOMove(target, 0.4f);
      isActivated = false;

    }
    
  }
}
