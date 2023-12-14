using System;

namespace AssoSw.Lesson6.DelegatesEvents
{
    public class Car
    {
        public Car(string model)
        {
            Model = model;
        }

        public string Model
        {
            get;
            private set;
        }

        public event EventHandler<EngineRpmEventArgs> EngineOverheating; // Motore fuori giri
        public event EventHandler EngineOff;

        private EventHandler _engineOn;
        public event EventHandler EngineOn
        {
            add
            {
                _engineOn += value;
            }
            remove
            {
                _engineOn -= value;
            }
        }

        private int numberOfRpm;

        public bool IsEngineOn { get; set; }

        public void Start()
        {
            numberOfRpm = 800;
            IsEngineOn = true;
            OnEngineOn();
        }

        private void OnEngineOn()
        {
            if (_engineOn != null)
                _engineOn(this, EventArgs.Empty);
        }

        public void Accelerate()
        {
            if (IsEngineOn)
            {
                numberOfRpm += 100;
                if (numberOfRpm > 8000)
                {
                    OnEngineOverheating();
                }
            }
        }

        private void OnEngineOverheating()
        {
            if (EngineOverheating != null)
            {
                EngineOverheating(this, new EngineRpmEventArgs() { NumberOfRpm = this.numberOfRpm });
            }
        }

        public void Decelerate()
        {
            if (!IsEngineOn)
                return;

            numberOfRpm -= 100;
            if (numberOfRpm <= 300)
            {
                numberOfRpm = 0;
                IsEngineOn = false;
                OnEngineOff();
            }
        }

        protected void OnEngineOff()
        {
            if (EngineOff != null)
            {
                EngineOff(this, EventArgs.Empty);
            }
        }
    }

    public class EngineRpmEventArgs : EventArgs
    {
        public int NumberOfRpm { get; set; }
    }
}
