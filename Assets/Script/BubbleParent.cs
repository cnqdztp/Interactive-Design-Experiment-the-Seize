using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class BubbleParent : MonoBehaviour
{
  public BubbleChild[] bubbleChildren;
  public float fadeDuration = 0.4f,highlightDuration = 0.2f;
  public void ShowBubbleChild()
  {
    foreach (var child in bubbleChildren)
    {
      child.gameObject.SetActive(true);
      // child.ShowBubble();
      // child.fadeDuration = fadeDuration;
      // child.highlightDuration = highlightDuration;
      GetComponent<CanvasGroup>().DOFade(1f, fadeDuration);
    }
  }
  public void HideBubbleChild()
  {
    foreach (var child in bubbleChildren)
    {
      GetComponent<CanvasGroup>().DOFade(0f, fadeDuration);
      // child.gameObject.SetActive(false);
    }
  }

  public void SelectBubbleChild(BubbleChild selectedItem)
  {
    selectedItem.SelectedBubble();
  }

  public void SetBubblePosition(Vector3 position)
  {
    gameObject.transform.position = position;
  }
}
