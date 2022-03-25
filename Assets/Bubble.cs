using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bubble : MonoBehaviour
{
  [SerializeField] private Image ring;
  public float RingInitiateSpeed = 3f;
  private bool isRingInitiate = false, isRingOpened = false;
  public void InitiateRing(Vector2 position)
  {
    var transformSelf = transform;
    transformSelf.position = new Vector3(position.x, position.y, transformSelf.position.z);
    isRingInitiate = true;
  }

  public void CancelInitiateRing()
  {
    isRingInitiate = false;
  }

  private void Update()
  {
    if (!isRingOpened)
    {
      RingSequence();
    }
  }

  private void RingSequence()
  {
    if (ring.fillAmount >= 1)
    {
      isRingOpened = true;
    }
    else if (isRingInitiate && ring.fillAmount <1)
    {
      ring.fillAmount += Time.deltaTime * RingInitiateSpeed;
    }
    else if(!isRingInitiate && ring.fillAmount >=0)
    {
      ring.fillAmount -= Time.deltaTime * RingInitiateSpeed;
    }
    
  }
}
