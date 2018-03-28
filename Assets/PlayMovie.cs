// Unity derives Video File Input Component UI from this file
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Video;

namespace Affdex
{
    public class PlayMovie : MonoBehaviour, IDetectorInput
    {
        //public MovieTexture movie;
        //public VideoClip videoToPlay;
        private VideoPlayer videoPlayer;
        private VideoSource videoSource;
        private AudioSource audioSource;

        public GameObject movie;

        public float sampleRate = 20;
        private Texture2D t2d;

        public Detector detector
        {
            get; private set;
        }

        public Texture Texture
        {
            get
            {
                return videoPlayer.texture;
            }
        }

        void Start()
        {
            Application.runInBackground = true;
            //movie.Play();
            t2d = new Texture2D(checked((int)movie.GetComponent<VideoPlayer>().clip.width), checked((int)movie.GetComponent<VideoPlayer>().clip.height), TextureFormat.RGB24, false);
            //StartCoroutine(playVideo());
            detector = GetComponent<Detector>();
        }

        IEnumerator playVideo()
        {
           videoPlayer = gameObject.AddComponent<VideoPlayer>();
           audioSource = gameObject.AddComponent<AudioSource>();

            videoPlayer.playOnAwake = false;
            audioSource.playOnAwake = false;

            videoPlayer.source = VideoSource.VideoClip;
            //videoPlayer.clip = videoToPlay;
            videoPlayer.Prepare();

            while (!videoPlayer.isPrepared)
            {
                Debug.Log("Preparing Video");
                yield return null;
            }

            Debug.Log("Done Preparing Video");

            videoPlayer.audioOutputMode = VideoAudioOutputMode.AudioSource;
            videoPlayer.EnableAudioTrack(0, true);
            videoPlayer.SetTargetAudioSource(0, audioSource);

            //Assign the Texture from Video to RawImage to be displayed
            //image.texture = videoPlayer.texture;

            videoPlayer.Play();
            audioSource.Play();

            Debug.Log("Playing Video");
            while (videoPlayer.isPlaying)
            {
                //Debug.LogWarning("Video Time: " + Mathf.FloorToInt((float)videoPlayer.time));
                yield return null;
            }

            Debug.Log("Done Playing Video");
        }


        void OnEnable()
        {
            if (!AffdexUnityUtils.ValidPlatform())
                return;

            if (sampleRate > 0)
                StartCoroutine(SampleRoutine());
        }

        private IEnumerator SampleRoutine()
        {
            while (enabled)
            {

                yield return new WaitForSeconds(1 / sampleRate);
                if (detector.IsRunning)
                {
                    ProcessFrame();
                }
            }
        }

        private void ProcessFrame()
        {
            if (movie.GetComponent<VideoPlayer>() != null)
            {
                RenderTexture rt = RenderTexture.GetTemporary(checked((int)movie.GetComponent<VideoPlayer>().clip.width), checked((int)movie.GetComponent<VideoPlayer>().clip.height), 0, RenderTextureFormat.ARGB32, RenderTextureReadWrite.Default, 1);
                RenderTexture.active = rt;

                //Copy the movie texture to the render texture
                Graphics.Blit(movie.GetComponent<VideoPlayer>().texture, rt);

                //Read the render texture to our temporary texture
                t2d.ReadPixels(new Rect(0, 0, rt.width, rt.height), 0, 0);

                //apply the bytes
                t2d.Apply();

                //Send to the detector
                Frame frame = new Frame(t2d.GetPixels32(), t2d.width, t2d.height, Frame.Orientation.Upright, Time.realtimeSinceStartup);
                detector.ProcessFrame(frame);

                RenderTexture.ReleaseTemporary(rt);
            }
        }
    }
}
