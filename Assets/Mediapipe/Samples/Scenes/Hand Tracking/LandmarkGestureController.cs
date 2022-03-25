using System;
using System.Collections;
using System.Collections.Generic;
using Mediapipe;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Events;

public class LandmarkGestureController : MonoBehaviour
{
  public static LandmarkGestureController instance;
  [SerializeField]private int leftSeizeLandmarkIndex = 4, rightSeizeLandmarkIndex = 8;
  private GameObject landmarkSource;
  private bool readyForGestureDetection =false;
  [SerializeField] private float proximityThreshold = 1.5f;
  private bool currentSeize = false,lastSeize = false;
  public UnityEvent<Vector2> onSeizeStart,onSeizeHold,onSeizeEnd;
  private Vector2 leftSeizeVector2, rightSeizeVector2;
  private void Awake()
  {
    instance = this;
  }
  private void Start()
  {
    LookForPointListAnnotationGameObject();
  }

  private void LookForPointListAnnotationGameObject()
  {
    landmarkSource = GameObject.Find("Point List Annotation");
    if (landmarkSource == null)
    {
      InvokeRepeating(nameof(LookForPointListAnnotationGameObject),1,1);
    }
    else
    {
      
      CancelInvoke(nameof(LookForPointListAnnotationGameObject));
      foreach (Transform child in landmarkSource.transform)
      {
        child.gameObject.GetComponent<Renderer>().enabled = false;
      }
      readyForGestureDetection = true;
      Debug.Log("Annotation Found!");
    }
  }

  private void LateUpdate()
  {
    if (readyForGestureDetection)
    {
      if (currentSeize && !lastSeize)
      {
        // Debug.Log("StartSeize at "+ GetSeizePosition());
        onSeizeStart.Invoke(GetSeizePosition());
      }
      if (currentSeize && lastSeize)
      {
        // Debug.Log("HoldSeize at "+ GetSeizePosition());
        onSeizeHold.Invoke(GetSeizePosition());
      }
      if (!currentSeize && lastSeize)
      {
        // Debug.Log("EndSeize at "+ GetSeizePosition());
        onSeizeEnd.Invoke(GetSeizePosition());
      }
      lastSeize = currentSeize;
      
      
      var leftSeizeTransform = landmarkSource.transform.GetChild(leftSeizeLandmarkIndex);
      var leftSeizePosition = leftSeizeTransform.position;
      leftSeizeVector2 = new Vector2(leftSeizePosition.x, leftSeizePosition.y);

      var rightSeizeTransform = landmarkSource.transform.GetChild(rightSeizeLandmarkIndex);
      var rightSeizePosition = rightSeizeTransform.position;
      rightSeizeVector2 = new Vector2(rightSeizePosition.x, rightSeizePosition.y);

      var proximityVector = leftSeizeVector2 - rightSeizeVector2;
      currentSeize = proximityVector.magnitude < proximityThreshold;
      // Debug.Log();
    }
  }

  private Vector2 GetSeizePosition()
  {
    return (leftSeizeVector2);
  }
  
  

}
