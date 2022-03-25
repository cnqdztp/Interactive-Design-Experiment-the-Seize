using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class Bubble : MonoBehaviour
{
  [SerializeField] private Image ring;
  public float RingInitiateSpeed = 3f;
  private bool isRingTrigger = false, isRingOpened = false;
  [SerializeField] private Image cursor;
  private BubbleChild selectedBubbleChild;
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
    if (isRingTrigger)
    {
      StartRing();
    }
    else
    {
      if (selectedBubbleChild == null)
      {
        CloseRing();
      }
      else
      {
        
        
      }
    }

  }

  private void StartRing()
  {
    if (isRingTrigger&& ring.fillAmount >= 1)
    {
      isRingOpened = true;
      cursor.DOFade(1f, 0.4f);
    }
    else if (isRingTrigger && ring.fillAmount <1)
    {
      ring.fillAmount += Time.deltaTime * RingInitiateSpeed;
    }
    else if(!isRingTrigger && ring.fillAmount >=0)
    {
      ring.fillAmount -= Time.deltaTime * RingInitiateSpeed;
    }
    
  }

  private void CloseRing()
  {
    
  }
}
