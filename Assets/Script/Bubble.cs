using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class Bubble : MonoBehaviour
{
  [SerializeField] private Image ring;
  [SerializeField] private BubbleParent bubbleParent;
  public float RingInitiateSpeed = 3f;
  private bool isRingTrigger = false, isRingOpened = false;
  [SerializeField] private Image cursor;
  private BubbleChild selectedBubbleChild;
  public static Bubble Instance;
  
  private void Awake()
  {
    Instance = this;
  }
  public void TriggerRing(Vector2 position)
  {
    var transformSelf = ring.transform;
    transformSelf.position = new Vector3(position.x, position.y, transformSelf.position.z);
    isRingTrigger = true;
  }

  public void UpdateRingPosition(Vector2 position)
  {
    var transformSelf = ring.transform;
    transformSelf.position = new Vector3(position.x, position.y, transformSelf.position.z);
  }

  public void CancelTriggerRing()
  {
    isRingTrigger = false;
  }
  
  

  private void Update()
  {
    // Debug.Log(selectedBubbleChild);
    if (isRingTrigger)
    {
      if (!isRingOpened)
      {
        StartRing();
      }

    }
    else
    {
      if (selectedBubbleChild == null)
      {
        bubbleParent.HideBubbleChild();
        CloseRing();
      }
      else
      {
        bubbleParent.HideBubbleChild();
        bubbleParent.SelectBubbleChild(selectedBubbleChild);
        CloseRing();
        selectedBubbleChild = null;
      }
    }

  }

  private void StartRing()
  {
    if (ring.fillAmount >= 1)
    {
      isRingOpened = true;
      cursor.DOFade(1f, 0.4f);
      ShowBubble();
      
    }
    else if (ring.fillAmount < 1)
    {
      ring.fillAmount += Time.deltaTime * RingInitiateSpeed;
    }


  }

  private void CloseRing()
  {
    isRingOpened = false;
    ring.fillAmount -= Time.deltaTime * RingInitiateSpeed;
    cursor.DOFade(0f, 0.2f);

  }

  private void ShowBubble()
  {
    bubbleParent.SetBubblePosition(ring.transform.position);
    bubbleParent.ShowBubbleChild();
  }

  public void UpdateSelectedItem(BubbleChild item)
  {
    selectedBubbleChild = item;
  }
}
