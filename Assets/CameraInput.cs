// Unity derives Camera Input Component UI from this file
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace Affdex
{
    // Provides WebCam access to the detector.  Sample rate set per second.  Use
    [RequireComponent(typeof(Detector))]
    public class CameraInput : MonoBehaviour, IDetectorInput
    {
        // Number of frames per second to sample.  Use 0 and call ProcessFrame() manually to run manually.
        // Enable/Disable to start/stop the sampling
        public float sampleRate = 20;

        // Should the selected camera be front facing?
        public bool isFrontFacing = true;

        // Desired width for capture
        public int targetWidth = 640;

        // Desired height for capture
        public int targetHeight = 480;

        // List of WebCams accessible to Unity
        [HideInInspector]
        protected WebCamDevice[] devices;

        // WebCam chosen to gather metrics from
        [HideInInspector]
        protected WebCamDevice device;

        // Web Cam texture
        [HideInInspector]
        private WebCamTexture cameraTexture;
        public webcam cam;

        public float videoRotationAngle
        {
            get
            {
                return cameraTexture.videoRotationAngle;
            }
        }

        // The detector that is on this game object
        
        public Detector detector
        {
            get; private set;
        }

        // The texture that is being modified for processing
        public Texture Texture
        {
            get
            {
                return cameraTexture;
            }
        }

        void Start()
        {
            if (!AffdexUnityUtils.ValidPlatform())
                return;
            detector = GetComponent<Detector>();
            devices = WebCamTexture.devices;
            if (devices.Length > 0)
            {
                SelectCamera(isFrontFacing);

                if (device.name != "Null")
                {

                    cameraTexture = cam.webcamTexture;
                    cameraTexture.deviceName = device.name;
                    cameraTexture.requestedFPS = (int)sampleRate;
                    //cameraTexture = new WebCamTexture(device.name, targetWidth, targetHeight, (int)sampleRate);
                    cameraTexture.Play();
                }
            }
        }

        // Set the target device (by name or orientation)
        // <param name="isFrontFacing">Should the device be forward facing?</param>
        // <param name="name">The name of the webcam to select.</param>
        public void SelectCamera(bool isFrontFacing, string name = "")
        {
            foreach (WebCamDevice d in devices)
            {
                if (d.name.Length > 1 && d.name == name)
                {
                        cameraTexture.Stop();
                        device = d;
                        cameraTexture = cam.webcamTexture;
                        cameraTexture.deviceName = device.name;
                        cameraTexture.requestedFPS = (int)sampleRate;
                    //cameraTexture = new WebCamTexture(device.name, targetWidth, targetHeight, (int)sampleRate);
                    cameraTexture.Play();
                }
                else if (d.isFrontFacing == isFrontFacing)
                    device = d;
            }
        }

        void OnEnable()
        {
            if (!AffdexUnityUtils.ValidPlatform())
                return;

            //get the selected camera!

            if (sampleRate > 0)
                StartCoroutine(SampleRoutine());
        }

        // Coroutine to sample frames from the camera
        private IEnumerator SampleRoutine()
        {
            while (enabled)
            {
                yield return new WaitForSeconds(1 / sampleRate);
                ProcessFrame();
            }
        }

        // Sample an individual frame from the webcam and send to detector for processing.
        public void ProcessFrame()
        {
            if (cameraTexture != null)
            {
                if (detector.IsRunning)
                {
                    if (cameraTexture.isPlaying)
                    {
                    Frame.Orientation orientation = Frame.Orientation.Upright;
                    Frame frame = new Frame(cameraTexture.GetPixels32(), cameraTexture.width, cameraTexture.height, orientation, Time.realtimeSinceStartup);
                    detector.ProcessFrame(frame);
                    }
                }
            }
        }

        void OnDestroy()
        {
            if (cameraTexture != null)
                cameraTexture.Stop();
        }
    }
}
