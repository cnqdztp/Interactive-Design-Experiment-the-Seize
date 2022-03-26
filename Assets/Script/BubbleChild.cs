using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class BubbleChild : MonoBehaviour
{
  public float fadeDuration = 0.3f,highlightDuration = 0.2f;
  public UnityEvent onBubbleSelected;
  public void ShowBubble()
  {
    gameObject.GetComponent<Image>().DOFade(1f, fadeDuration);
  }
  
  public void HideBubble()
  {
    gameObject.GetComponent<Image>().DOFade(1f, fadeDuration);
  }

  public void HighlightBubble()
  {
    transform.DOScale(new Vector3(1.2f, 1.2f, 1.2f),highlightDuration);
  }

  public void CancelHighlight()
  {
    transform.DOScale(Vector3.one, highlightDuration);

  }

  public void SelectedBubble()
  {
    onBubbleSelected.Invoke();
    transform.DOScale(new Vector3(2f, 2f, 2f), fadeDuration).OnComplete(CancelHighlight);
  }

  private void OnTriggerEnter2D(Collider2D other)
  {
    HighlightBubble();
  }

  private void OnTriggerExit2D(Collider2D other)
  {
    CancelHighlight();
  }
}
