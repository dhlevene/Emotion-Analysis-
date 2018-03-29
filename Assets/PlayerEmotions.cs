using UnityEngine;
using UnityEngine.UI;
using Affdex;
using System.Collections.Generic;
using System.Collections;

public class PlayerEmotions : ImageResultsListener
{
    public float currentValence;
    public float currentAnger;
    public float currentSmile;
    public float currentDisgust;
    public float currentEyeClosure;
    public float currentJoy;
    public float currentSadness;
    public float currentSurprise;
    public float currentInterocularDistance;
    public float currentAttention;
    public float currentEngagement;
    public FeaturePoint[] featurePointsList;
    public Slider zenSlider;
    public bool videoPaused = false;
    public GameObject face_lost_warning;

    Transform playerIcon;
    Transform player;
    Image playerIconImage;
    public int frameNo = 0;
    public float eye_distance_base;
    public float final_atten;

    public override void onFaceFound(float timestamp, int faceId)
    {
        face_lost_warning.SetActive(false);
        //setIcon(255);
        Debug.Log("Found the face");
        eye_distance_base = currentInterocularDistance;
    }

    public override void onFaceLost(float timestamp, int faceId)
    {
        face_lost_warning.SetActive(true);
        //setIcon(20);
        currentValence = 0;
        currentJoy = 0;
        currentSadness = 0;
        currentSurprise = 0;
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
        //Debug.Log("Got face results");
        //Debug.Log("Frame Number: " + frameNo++);
        /*if(frameNo % 30 == 0)
        {
            calculateAttention(currentInterocularDistance);
        }*/
        if (videoPaused == false)
        {
            foreach (KeyValuePair<int, Face> pair in faces)
            {
                int FaceId = pair.Key;  // The Face Unique Id.
                Face face = pair.Value;    // Instance of the face class containing emotions, and facial expression values.

                //Retrieve the Emotions Scores
                face.Emotions.TryGetValue(Emotions.Valence, out currentValence);
                face.Emotions.TryGetValue(Emotions.Anger, out currentAnger);
                face.Emotions.TryGetValue(Emotions.Joy, out currentJoy);
                face.Emotions.TryGetValue(Emotions.Sadness, out currentSadness);
                face.Emotions.TryGetValue(Emotions.Surprise, out currentSurprise);
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

    }

    public float calculateAttention()
    {
        /*if (Mathf.Abs(observed_eye_distance - eye_distance_base) >= 5)
        {
            //leaning forward

        }
        final_atten = 0;
        return final_atten;*/
        return currentAttention;
    }


    public List<float> getEmotion(int choice)
    {
        List<float> emotions = new List<float>();
            emotions.Add(currentJoy);
            emotions.Add(currentSadness);
            emotions.Add(currentAnger);
            emotions.Add(currentDisgust);
            emotions.Add(currentSurprise);
            
        return emotions;
    }
    public void pauseStream()
    {
        videoPaused = true;
    }
    public void resumeStream()
    {
        videoPaused = false;
    }
    /*    private void setIcon(byte alpha)
        {
            playerIcon = GameObject.FindGameObjectWithTag("PlayerIcon").transform;
            playerIconImage = playerIcon.GetComponent<Image>();
            playerIconImage.color = new Color32(255, 255, 255, alpha);
        }*/
}