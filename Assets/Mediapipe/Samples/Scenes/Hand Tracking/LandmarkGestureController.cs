using System;
using System.Collections;
using System.Collections.Generic;
using Mediapipe;
using UnityEngine;

public class LandmarkGestureController : MonoBehaviour
{
  public static LandmarkGestureController instance;
  [SerializeField]private int leftSeizeLandmarkIndex = 4, rightSeizeLandmarkIndex = 8;
  private GameObject landmarkSource;
  private bool readyForGestureDetection =false;
  [SerializeField] private float proximityThreshold = 1.5f;
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
      readyForGestureDetection = true;
      Debug.Log("Annotation Found!");
    }
  }

  private void LateUpdate()
  {
    if (readyForGestureDetection)
    {
      var leftSeizeTransform = landmarkSource.transform.GetChild(leftSeizeLandmarkIndex);
      var leftSeizePosition = leftSeizeTransform.position;
      var leftSeizeVector2 = new Vector2(leftSeizePosition.x, leftSeizePosition.y);

      var rightSeizeTransform = landmarkSource.transform.GetChild(rightSeizeLandmarkIndex);
      var rightSeizePosition = rightSeizeTransform.position;
      var rightSeizeVector2 = new Vector2(rightSeizePosition.x, rightSeizePosition.y);

      var proximityVector = leftSeizeVector2 - rightSeizeVector2;
      if (proximityVector.magnitude < proximityThreshold)
      {
        Debug.Log("Seize");
      }
    }
  }

}
