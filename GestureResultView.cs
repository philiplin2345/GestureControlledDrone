namespace Microsoft.Samples.Kinect.DiscreteGestureBasics
{
    using System;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;

    /// <summary>
    /// Stores discrete gesture results for the GestureDetector.
    /// Properties are stored/updated for display in the UI.
    /// </summary>
    public sealed class GestureResultView : INotifyPropertyChanged
    {
        /// <summary> Array of brush colors to use for a tracked body; array position corresponds to the body colors used in the KinectBodyView class </summary>
        private readonly Brush[] trackedColors = new Brush[] { Brushes.Red, Brushes.Green, Brushes.Blue, Brushes.AliceBlue, Brushes.Aqua, Brushes.Azure };

        /// <summary> Brush color to use as background in the UI </summary>
        private Brush bodyColor = Brushes.AliceBlue;

        /// <summary> The body index (0-5) associated with the current gesture detector </summary>
        private string quadrotorState = "Landed";

        /// <summary> Current confidence value reported by the discrete gesture </summary>
        private float process = 0.0f;

        /// <summary> True, if the discrete gesture is currently being detected </summary>
        private bool detected = false;
        
        /// <summary> True, if the body is currently being tracked </summary>
        private bool isTracked = false;

        private string gestureType = null;

        /// <summary>
        /// Initializes a new instance of the GestureResultView class and sets initial property values
        /// </summary>
        /// <param name="bodyIndex">Body Index associated with the current gesture detector</param>
        /// <param name="isTracked">True, if the body is currently tracked</param>
        /// <param name="detected">True, if the gesture is currently detected for the associated body</param>
        /// <param name="confidence">Confidence value for detection of the 'Seated' gesture</param>
        public GestureResultView( bool isTracked, bool detected, float process, string gestureType)
        {

            this.IsTracked = isTracked;
            this.Detected = detected;
            this.Process = process;
            this.GestureType = gestureType;
        }//gestureresultview

        /// <summary>
        /// INotifyPropertyChangedPropertyChanged event to allow window controls to bind to changeable data
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary> 
        /// Gets the body index associated with the current gesture detector result 
        /// </summary>
        public string QuadrotorState
        {
            get
            {
                return this.quadrotorState;
            }

            private set
            {
                if (this.quadrotorState != value)
                {
                    this.quadrotorState = value;
                    this.NotifyPropertyChanged();
                }
            }
        }

        /// <summary> 
        /// Gets the body color corresponding to the body index for the result
        /// </summary>
        public Brush BodyColor
        {
            get
            {
                return this.bodyColor;
            }

            private set
            {
                if (this.bodyColor != value)
                {
                    this.bodyColor = value;
                    this.NotifyPropertyChanged();
                }
            }
        }

        /// <summary> 
        /// Gets a value indicating whether or not the body associated with the gesture detector is currently being tracked 
        /// </summary>
        public bool IsTracked 
        {
            get
            {
                return this.isTracked;
            }

            private set
            {
                if (this.IsTracked != value)
                {
                    this.isTracked = value;
                }
            }
        }

        /// <summary> 
        /// Gets a value indicating whether or not the discrete gesture has been detected
        /// </summary>
        public bool Detected 
        {
            get
            {
                return this.detected;
            }

            private set
            {
                if (this.detected != value)
                {
                    this.detected = value;
                    this.NotifyPropertyChanged();
                }
            }
        }

        /// <summary> 
        /// Gets a float value which indicates the detector's confidence that the gesture is occurring for the associated body 
        /// </summary>
        public float Process
        {
            get
            {
                return this.process;
            }

            private set
            {
                if (this.process != value)
                {
                    this.process = value;
                    this.NotifyPropertyChanged();
                }
            }
        }
        /// <summary> 
        /// Gets a value indicating whether or not the discrete gesture has been detected
        /// </summary>
        public string GestureType
        {
            get
            {
                return this.gestureType;
            }

            private set
            {
                if (this.gestureType != value)
                {
                    this.gestureType = value;
                    this.NotifyPropertyChanged();
                }
            }
        }
        /// <summary>
        /// Updates the values associated with the discrete gesture detection result
        /// </summary>
        /// <param name="isBodyTrackingIdValid">True, if the body associated with the GestureResultView object is still being tracked</param>
        /// <param name="isGestureDetected">True, if the discrete gesture is currently detected for the associated body</param>
        /// <param name="detectionConfidence">Confidence value for detection of the discrete gesture</param>
        public void UpdateGestureResult(bool isBodyTrackingIdValid, bool isGestureDetected, float confidence,  string gestureType)
        {
            this.IsTracked = isBodyTrackingIdValid;


            if (!this.IsTracked)
            {
                this.Detected = false;
                this.BodyColor = Brushes.Gray;
                this.GestureType = "null";
            }
            else
            {
                this.Detected = isGestureDetected;
                this.BodyColor = Brushes.Aqua;
                this.Process = confidence;
                this.GestureType = gestureType;
            }   
        }//updategestureresult
        public void Takeoff()
        {
            this.BodyColor = Brushes.LawnGreen;
            this.QuadrotorState = "Takeoff";
            this.GestureType = "none";
        }
        public void EmergencyStop()
        {
            this.BodyColor = Brushes.Red;
            this.QuadrotorState ="Emergencystop";
            this.GestureType = "none";
        }
        public void Stop ()
        {
            this.BodyColor = Brushes.DarkBlue;
            this.QuadrotorState = "Land";
            this.GestureType = "none";
        }
        /// <summary>
        /// Notifies UI that a property has changed
        /// </summary>
        /// <param name="propertyName">Name of property that has changed</param> 
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }//notifypropertychanged
    }
}
