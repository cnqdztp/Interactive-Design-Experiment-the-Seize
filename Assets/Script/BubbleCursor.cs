using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleCursor : MonoBehaviour
{
  private void OnTriggerEnter2D(Collider2D other)
  {
    Debug.Log(other);
    Bubble.Instance.UpdateSelectedItem(other.GetComponent<BubbleChild>());
  }

  private void OnTriggerExit2D(Collider2D other)
  {
    Bubble.Instance.UpdateSelectedItem(null);
  }
}
