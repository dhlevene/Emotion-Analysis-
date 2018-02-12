using UnityEngine;
using UnityEngine.UI;
using Affdex;
using System.Collections.Generic;

public class PlayerEmotions : ImageResultsListener
{
    public float currentValence;
    public float currentAnger;
    public float currentSmile;
    public float currentDisgust;
    public float currentEyeClosure;
    public float currentJoy;
    public float currentInterocularDistance;
    public float currentAttention;
    public float currentEngagement;
    public FeaturePoint[] featurePointsList;
    public Slider zenSlider;

    Transform playerIcon;
    Transform player;
    Image playerIconImage;

    public override void onFaceFound(float timestamp, int faceId)
    {
        //setIcon(255);
        Debug.Log("Found the face");
    }

    public override void onFaceLost(float timestamp, int faceId)
    {
        //setIcon(20);
        currentValence = 0;
        currentJoy = 0;
        currentAnger = 0;
        currentSmile = 0;
        currentDisgust = 0;
        currentEyeClosure = 0;
        currentInterocularDistance = 0;
        currentAttention = 0;
        currentEngagement = 0;
        Debug.Log("Lost the face");
        //player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public override void onImageResults(Dictionary<int, Face> faces)
    {
        Debug.Log("Got face results");

        foreach (KeyValuePair<int, Face> pair in faces)
        {
            int FaceId = pair.Key;  // The Face Unique Id.
            Face face = pair.Value;    // Instance of the face class containing emotions, and facial expression values.

            //Retrieve the Emotions Scores
            face.Emotions.TryGetValue(Emotions.Valence, out currentValence);
            face.Emotions.TryGetValue(Emotions.Anger, out currentAnger);
            face.Emotions.TryGetValue(Emotions.Joy, out currentJoy);
            face.Emotions.TryGetValue(Emotions.Disgust, out currentDisgust);
            face.Emotions.TryGetValue(Emotions.Engagement, out currentEngagement);

            //Retrieve the Smile Score
            face.Expressions.TryGetValue(Expressions.Smile, out currentSmile);
            face.Expressions.TryGetValue(Expressions.EyeClosure, out currentEyeClosure);
            face.Expressions.TryGetValue(Expressions.Attention, out currentAttention);

            //Retrieve the Interocular distance, the distance between two outer eye corners.
            currentInterocularDistance = face.Measurements.interOcularDistance;


            //Retrieve the coordinates of the facial landmarks (face feature points)
            featurePointsList = face.FeaturePoints;
        }
    }

/*    private void setIcon(byte alpha)
    {
        playerIcon = GameObject.FindGameObjectWithTag("PlayerIcon").transform;
        playerIconImage = playerIcon.GetComponent<Image>();
        playerIconImage.color = new Color32(255, 255, 255, alpha);
    }*/
}