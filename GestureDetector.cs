namespace Microsoft.Samples.Kinect.DiscreteGestureBasics
{
    using Microsoft.Kinect;
    using Microsoft.Kinect.VisualGestureBuilder;
    using System;
    using System.Collections.Generic;
    /// <summary>
    /// Gesture Detector class which listens for VisualGestureBuilderFrame events from the service
    /// and updates the associated GestureResultView object with the latest results for the direction gestures
    /// </summary>
    public class GestureDetector : IDisposable
    {
        /// <summary> Path to the gesture database that was trained with VGB </summary>
        private readonly string gestureDatabase = @"Database\control_final3.gbd";

        /// <summary> Name of the discrete gesture in the database that we want to track </summary>
        private readonly string[] gesturename = { "flower", "up", "down", "hover", "left", "right","STOP" };

        public int direction = 0;
        public float[] signal = new float[4];

        /// <summary> Gesture frame source which should be tied to a body tracking ID </summary>
        private VisualGestureBuilderFrameSource vgbFrameSource = null;

        /// <summary> Gesture frame reader which will handle gesture events coming from the sensor </summary>
        private VisualGestureBuilderFrameReader vgbFrameReader = null;
        private bool isFlying = false;
        public bool isUnlocked = false;

        /// <summary>
        /// Initializes a new instance of the GestureDetector class along with the gesture frame source and reader
        /// </summary>
        /// <param name="kinectSensor">Active sensor to initialize the VisualGestureBuilderFrameSource object with</param>
        /// <param name="gestureResultView">GestureResultView object to store gesture results of a single body to</param>
        public GestureDetector(KinectSensor kinectSensor, GestureResultView gestureResultView)
        {
            if (kinectSensor == null)
            {
                throw new ArgumentNullException("kinectSensor");
            }

            if (gestureResultView == null)
            {
                throw new ArgumentNullException("gestureResultView");
            }

            this.GestureResultView = gestureResultView;

            // create the vgb source. The associated body tracking ID will be set when a valid body frame arrives from the sensor.
            this.vgbFrameSource = new VisualGestureBuilderFrameSource(kinectSensor, 0);
            this.vgbFrameSource.TrackingIdLost += this.Source_TrackingIdLost;

            // open the reader for the vgb frames
            this.vgbFrameReader = this.vgbFrameSource.OpenReader();
            if (this.vgbFrameReader != null)
            {
                this.vgbFrameReader.IsPaused = true;
                this.vgbFrameReader.FrameArrived += this.Reader_GestureFrameArrived;
            }

            // load the 'Seated' gesture from the gesture database
            using (VisualGestureBuilderDatabase database = new VisualGestureBuilderDatabase(this.gestureDatabase))
            {
                // we could load all available gestures in the database with a call to vgbFrameSource.AddGestures(database.AvailableGestures), 
                // but for this program, we only want to track one discrete gesture from the database, so we'll load it by name
                vgbFrameSource.AddGestures(database.AvailableGestures);
            }
        }//gesturedetector

        /// <summary> Gets the GestureResultView object which stores the detector results for display in the UI </summary>
        public GestureResultView GestureResultView { get; private set; }

        /// <summary>
        /// Gets or sets the body tracking ID associated with the current detector
        /// The tracking ID can change whenever a body comes in/out of scope
        /// </summary>
        public ulong TrackingId
        {
            get
            {
                return this.vgbFrameSource.TrackingId;
            }

            set
            {
                if (this.vgbFrameSource.TrackingId != value)
                {
                    this.vgbFrameSource.TrackingId = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether or not the detector is currently paused
        /// If the body tracking ID associated with the detector is not valid, then the detector should be paused
        /// </summary>
        public bool IsPaused
        {
            get
            {
                return this.vgbFrameReader.IsPaused;
            }

            set
            {
                if (this.vgbFrameReader.IsPaused != value)
                {
                    this.vgbFrameReader.IsPaused = value;
                }
            }
        }

        /// <summary>
        /// Disposes all unmanaged resources for the class
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }//dispose

        /// <summary>
        /// Disposes the VisualGestureBuilderFrameSource and VisualGestureBuilderFrameReader objects
        /// </summary>
        /// <param name="disposing">True if Dispose was called directly, false if the GC handles the disposing</param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (this.vgbFrameReader != null)
                {
                    this.vgbFrameReader.FrameArrived -= this.Reader_GestureFrameArrived;
                    this.vgbFrameReader.Dispose();
                    this.vgbFrameReader = null;
                }

                if (this.vgbFrameSource != null)
                {
                    this.vgbFrameSource.TrackingIdLost -= this.Source_TrackingIdLost;
                    this.vgbFrameSource.Dispose();
                    this.vgbFrameSource = null;
                }
            }
        }//dispose

        /// <summary>
        /// Handles gesture detection results arriving from the sensor for the associated body tracking Id
        /// </summary>
        /// <param name="sender">object sending the event</param>
        /// <param name="e">event arguments</param>
        private void Reader_GestureFrameArrived(object sender, VisualGestureBuilderFrameArrivedEventArgs e)
        {
            VisualGestureBuilderFrameReference frameReference = e.FrameReference;
            using (VisualGestureBuilderFrame frame = frameReference.AcquireFrame())
            {
                if (frame != null)
                {
                    IReadOnlyDictionary<Gesture, DiscreteGestureResult> discreteResults = frame.DiscreteGestureResults;
                    // get the discrete gesture results which arrived with the latest frame
                    

                    float max = 0;
                    DiscreteGestureResult result_flower = null;
                    DiscreteGestureResult result_hover = null;
                    DiscreteGestureResult result_stop = null;
                    DiscreteGestureResult result_up = null;
                    DiscreteGestureResult result_down = null; 
                    DiscreteGestureResult result_left = null;
                    DiscreteGestureResult result_right = null;
                    

                    if (isFlying == false)
                    {
                        foreach (Gesture gesture in this.vgbFrameSource.Gestures)
                        {
                            
                            if (gesture.Name.Equals("hover") && gesture.GestureType == GestureType.Discrete)
                            {
                                if (discreteResults != null)
                                {
                                    discreteResults.TryGetValue(gesture, out result_hover);
                                    if (result_hover.Confidence >= 0.3)
                                    {
                                        this.GestureResultView.Takeoff();
                                        isFlying = true;
                                        direction = 5;
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        if (isUnlocked == false)
                        {
                            foreach (Gesture gesture in this.vgbFrameSource.Gestures)
                            {
                                if (gesture.Name.Equals("flower") && gesture.GestureType == GestureType.Discrete)
                                {
                                    discreteResults.TryGetValue(gesture, out result_flower);
                                    if (result_flower.Confidence >= 0.8)
                                    {
                                        
                                        isUnlocked = true;
                                    }
                                }                               
                            }
                        }
                        else
                        {
                            if (discreteResults != null)
                            {
                                // we only have one gesture in this source object, but you can get multiple gestures
                                foreach (Gesture gesture in this.vgbFrameSource.Gestures)
                                {
                                    if (gesture.Name.Equals("up") && gesture.GestureType == GestureType.Discrete)
                                    {

                                        discreteResults.TryGetValue(gesture, out result_up);
                                        signal[0] = result_up.Confidence;
                                    }
                                    if (gesture.Name.Equals("left") && gesture.GestureType == GestureType.Discrete)
                                    {

                                        discreteResults.TryGetValue(gesture, out result_left);
                                        signal[1] = result_left.Confidence;
                                    }
                                    if (gesture.Name.Equals("down") && gesture.GestureType == GestureType.Discrete)
                                    {

                                        discreteResults.TryGetValue(gesture, out result_down);
                                        signal[2] = result_down.Confidence;
                                    }
                                    if (gesture.Name.Equals("right") && gesture.GestureType == GestureType.Discrete)
                                    {

                                        discreteResults.TryGetValue(gesture, out result_right);
                                        signal[3] = result_right.Confidence;
                                    }
                                    for (int i = 0; i < 4; i++)
                                    {
                                        if (Math.Abs(max) <= Math.Abs(signal[i]))
                                        {
                                            max = signal[i];
                                        }
                                    }
                                    if (Math.Abs(max) > 0.2)
                                    {

                                        if (signal[0] == max && signal[0] >= 0.5)
                                        {
                                            this.GestureResultView.UpdateGestureResult(true, true, signal[0], "↑Front↑");
                                            direction = 3;
                                        }
                                        if (signal[1] == max && signal[1] >= 0.5)
                                        {
                                            this.GestureResultView.UpdateGestureResult(true, true, signal[1], "←Left←");
                                            direction = 2;
                                        }
                                        if (signal[2] == max && signal[2] >= 0.5)
                                        {
                                            this.GestureResultView.UpdateGestureResult(true, true, signal[2], "↓Back↓");
                                            direction = 4;
                                        }
                                        if (signal[3] == max && signal[3] >= 0.5)
                                        {
                                            this.GestureResultView.UpdateGestureResult(true, true, signal[3], "→Right→");
                                            direction = 1;
                                        }
                                    }
                                    else
                                    {
                                        this.GestureResultView.UpdateGestureResult(true, true, 0.0f, "--Hover--");
                                        direction = 0;
                                    }
                                }
                            }//direction control
                            foreach (Gesture gesture in this.vgbFrameSource.Gestures)
                            {
                                if (gesture.Name.Equals("STOP") && gesture.GestureType == GestureType.Discrete)
                                {
                                    if (discreteResults != null)
                                    {
                                        discreteResults.TryGetValue(gesture, out result_stop);
                                        if (result_stop.Confidence >= 0.3)
                                        {
                                            this.GestureResultView.Stop();
                                            direction = 6;
                                            isUnlocked = false;
                                        }
                                    }
                                }
                            }
                        }//isUnlocked true
                    }//isFlying true
                }
            }
        }//reader gesture frame arrived

        /// <summary>
        /// Handles the TrackingIdLost event for the VisualGestureBuilderSource object
        /// </summary>
        /// <param name="sender">object sending the event</param>
        /// <param name="e">event arguments</param>
        private void Source_TrackingIdLost(object sender, TrackingIdLostEventArgs e)
        {
            this.GestureResultView.UpdateGestureResult(false, false, 0.0f, "null");
            direction = 0;
        }//sourcetrackingidlost
    }
}
