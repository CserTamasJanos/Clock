using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace F012Beta
{
    /// <summary>
    /// Subject
    /// </summary>
    public class SenderFlashStatus
    {
        private List<FlasherInterface> clockShoudBeFlashedList = new List<FlasherInterface>();
        private bool flash = false;

        public bool Flash
        {
            get { return flash;}
            set {flash = value; NotifyAllClocks();}
        }

        public SenderFlashStatus()
        {

        }

        public void AttachAClock(FlasherInterface newClockToBeFlashed)
        {
            clockShoudBeFlashedList.Add(newClockToBeFlashed);
        }

        public void DetachAClock(FlasherInterface clockShouldBeRemoved)
        {
            clockShoudBeFlashedList.Remove(clockShouldBeRemoved);
        }

        public void NotifyAllClocks()
        {
            foreach (FlasherInterface aFlasher in clockShoudBeFlashedList)
            {
                aFlasher.UpdateFlash(this);
            }
        }
    }

    /// <summary>
    /// Class makes observation.
    /// </summary>
    class BasicClockDisplay : FlasherInterface
    {
        public delegate void TimerTick(Bitmap clockBitmap);
        public event TimerTick TimerTickEvent;
        protected Timer timer;

        protected Graphics clockGraphics;
        protected Bitmap clockBitmap;

        private bool flashBool;
        private int counter = ClockData.FlashNumberForCounter;

        protected bool FlashBool { get { return flashBool; } }

        protected int TimerWidth { get; set; }
        protected int TimerHeight { get; set; }

        protected int ClockPositionX { get; set; }
        protected int ClockPositionY { get; set; }

        public Graphics ClockGraphics { get { return clockGraphics; } }
        public Bitmap ClockBitmap { get { return clockBitmap; } }

        public BasicClockDisplay()
        {
            timer = new Timer();
            timer.Interval = ClockData.TimerIntervals;
            timer.Tick += new EventHandler(ActualClockBitmap);
            timer.Start();
        }

        /// <summary>
        /// The actual look of the Clock, can be overwritten according to the type of the clock.
        /// </summary>
        protected virtual void DrawClock()
        {

        }

        /// <summary>
        /// The clock sight can be modified befor it is drawn. (Flash makes the backgrond red and white again.)
        /// </summary>
        protected virtual void ActualClockSight()
        {
            Flash();

            clockGraphics.Clear(!FlashBool ? ClockData.BackgoundColor : ClockData.FlashColor);

            DrawClock();
        }

        /// <summary>
        /// I use delegate to reach the picturebox of the form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void ActualClockBitmap(object sender, EventArgs e)
        {
            ActualClockSight();

            if(TimerTickEvent != null)
            {
                TimerTickEvent.Invoke(ClockBitmap);
            }
        }

        public void UpdateFlash(SenderFlashStatus aFlasherButton)
        {
            if (aFlasherButton.Flash)
            {
                counter = 0;
            }
        }

        protected void Flash()
        {
            if (counter < ClockData.FlashNumberForCounter)
            {
                counter++;
                flashBool = !flashBool;
            }
            else
            {
                counter = ClockData.FlashNumberForCounter;
                flashBool = false;
            }
        }
    }

    /// <summary>
    /// Derived class makes observation.
    /// </summary>
    class AnalogClock : BasicClockDisplay
    {
        public AnalogClock()
        {
            TimerWidth = ClockData.AnalogClockWidth;
            TimerHeight = ClockData.AnalogClockHeight;
            ClockPositionX = TimerWidth / 2;
            ClockPositionY = TimerHeight / 2;

            clockBitmap = new Bitmap(TimerWidth, TimerHeight);

            clockGraphics = Graphics.FromImage(ClockBitmap);
        }

        /// <summary>
        /// Draws the analog clock parts.
        /// </summary>
        protected override void DrawClock()
        {
            int[] handCoordinates;

            //Frame of the Clock.
            clockGraphics.DrawEllipse(new Pen(ClockData.EllipseColor, ClockData.AnalogClockPenWidth), ClockData.AnalogClockEllipseX,
                                              ClockData.AnalogClockEllipseY, TimerWidth - ClockData.AnalogClockPenWidth,
                                              TimerHeight - ClockData.AnalogClockPenWidth);

            //Clocknumbers
            clockGraphics.DrawString(ClockData.AnalogTweleve, new Font(ClockData.FontType, ClockData.AnalogClockNumberSize), ClockData.BrushesForNumbers, ClockData.AnalogTwelveNumberCoordinate);
            clockGraphics.DrawString(ClockData.AnalogThree, new Font(ClockData.FontType, ClockData.AnalogClockNumberSize), ClockData.BrushesForNumbers, ClockData.AnalogThreeNumberCoordinate);
            clockGraphics.DrawString(ClockData.AnalogSix, new Font(ClockData.FontType, ClockData.AnalogClockNumberSize), ClockData.BrushesForNumbers, ClockData.AnalogSixNumberCoordinate);
            clockGraphics.DrawString(ClockData.AnalogNine, new Font(ClockData.FontType, ClockData.AnalogClockNumberSize), ClockData.BrushesForNumbers, ClockData.AnalogNineNumberCoordinate);

            //Secondhand
            handCoordinates = SecondAndMinuteHandCoordinates(DateTime.Now.Second, ClockData.AnalogClockSecondHandLength);
            clockGraphics.DrawLine(new Pen(ClockData.SecondHandColor, ClockData.AnalogClockPenWidth),
                                   new Point(ClockPositionX, ClockPositionY),
                                   new Point(handCoordinates[0], handCoordinates[1]));

            //Minutehand
            handCoordinates = SecondAndMinuteHandCoordinates(DateTime.Now.Minute, ClockData.AnalogClockMinutehandLength);
            clockGraphics.DrawLine(new Pen(ClockData.MinuteHandColor, ClockData.AnalogClockPenWidth),
                                   new Point(ClockPositionX, ClockPositionY),
                                   new Point(handCoordinates[0], handCoordinates[1]));

            //Hourhand
            handCoordinates = HourHandCoordinates(DateTime.Now.Hour % ClockData.NumberOfHours, DateTime.Now.Minute, ClockData.AnalogClockHourHandLength);
            clockGraphics.DrawLine(new Pen(ClockData.HourHandColor, ClockData.AnalogClockPenWidth),
                                   new Point(ClockPositionX, ClockPositionY),
                                   new Point(handCoordinates[0], handCoordinates[1]));
        }

        /// <summary>
        /// The second and the minute hand's arc distance is the same (Secondhand makes it 60 time).
        /// </summary>
        /// <param name="value"></param>
        /// <param name="handLength"></param>
        /// <returns></returns>
        private int[] SecondAndMinuteHandCoordinates(int value, int handLength)
        {
            int[] coordinates = new int[2];

            value *= ClockData.SecondHandTickDegree;

            if (value >= 0 && value <= ClockData.HalfCircleNumber)
            {
                coordinates[0] = ClockPositionX + (int)(handLength * Math.Sin(Math.PI * value / ClockData.HalfCircleNumber));
                coordinates[1] = ClockPositionY - (int)(handLength * Math.Cos(Math.PI * value / ClockData.HalfCircleNumber));
            }
            else
            {
                coordinates[0] = ClockPositionX - (int)(handLength * -Math.Sin(Math.PI * value / ClockData.HalfCircleNumber));
                coordinates[1] = ClockPositionY - (int)(handLength * Math.Cos(Math.PI * value / ClockData.HalfCircleNumber));
            }
            return coordinates;
        }

        /// <summary>
        /// Hourhand makes 30 degree during an hour, it moves 30 degree/60 minutes in minutes (0.5 degree/minute)
        /// </summary>
        /// <param name="hourValue"></param>
        /// <param name="minuteValue"></param>
        /// <param name="handLength"></param>
        /// <returns></returns>
        private int[] HourHandCoordinates(int hourValue, int minuteValue, int handLength)
        {
            int[] coordinates = new int[2];

            int value = (int)(minuteValue * ClockData.HourHandMinuteTickDegree) + (hourValue * ClockData.HourHandDegree);

            if (value >= 0 && value <= ClockData.HalfCircleNumber)
            {
                coordinates[0] = ClockPositionX + (int)(handLength * Math.Sin(Math.PI * value / ClockData.HalfCircleNumber));
                coordinates[1] = ClockPositionY - (int)(handLength * Math.Cos(Math.PI * value / ClockData.HalfCircleNumber));
            }
            else
            {
                coordinates[0] = ClockPositionX - (int)(handLength * -Math.Sin(Math.PI * value / ClockData.HalfCircleNumber));
                coordinates[1] = ClockPositionY - (int)(handLength * Math.Cos(Math.PI * value / ClockData.HalfCircleNumber));
            }
            return coordinates;
        }
    }

    /// <summary>
    /// Derived class makes observation.
    /// </summary>
    class DigitalClock : BasicClockDisplay
    {
        public DigitalClock()
        {
            TimerWidth = ClockData.DigitalClockWidth;
            TimerHeight = ClockData.DigitalClockHeight;

            ClockPositionX = ClockData.DigitalClockX;
            ClockPositionY = ClockData.DigitalClockY;

            clockBitmap = new Bitmap(TimerWidth, TimerHeight);
            clockGraphics = Graphics.FromImage(ClockBitmap);
        }

        /// <summary>
        /// Draws digital clock.
        /// </summary>
        protected override void DrawClock()
        {
            //Draw the frame of the digitalClock.
            clockGraphics.DrawRectangle(new Pen(ClockData.RectangleFrameColor, ClockData.RectangleFramePenWidth), ClockPositionX, ClockPositionY, TimerWidth, TimerHeight);

            //Draw Numbers.
            clockGraphics.DrawString(DateTime.Now.TimeOfDay.ToString(), new Font(ClockData.FontType, ClockData.DigitalNumberSize),
                                     ClockData.BrushesForNumbers, ClockData.DigitalNumbersStartCoordinate);
        }
    }


    class SomethingToBeFlashed : FlasherInterface
    {
        public delegate void InnerTimerIsOn(Bitmap actualRectangleSight);
        public event InnerTimerIsOn InnerTimerIsOnEvent;

        Graphics rectangle;
        Bitmap rectangleBitmap;

        private Timer innerTimerToCount; 

        private bool flashBool;
        private int counter = ClockData.FlashNumberForCounter;

        private bool FlashBool { get { return flashBool; } }

        private int RectangleWidth { get; set; }
        private int RectangleHeight { get; set; }

        private int RectanglePositionX { get; set; }
        private int RectanglePositionY { get; set; }

        public Graphics RectangleGraphics { get { return rectangle; } }
        public Bitmap RectangleBitmap { get { return rectangleBitmap; } }

        public SomethingToBeFlashed()
        {
            innerTimerToCount = new Timer();
            innerTimerToCount.Interval = ClockData.TimerIntervals;
            innerTimerToCount.Tick += new EventHandler(ActualRectangleBitmap);
            innerTimerToCount.Start();

            RectangleWidth = RectangleData.RectangleWidth;
            RectangleHeight = RectangleData.RectangleHeight;
 
            rectangleBitmap = new Bitmap(RectangleWidth, RectangleHeight);

            rectangle = Graphics.FromImage(rectangleBitmap);

            ActualRectangleSight();
        }

        private void DrawRectangle()
        {
            rectangle.DrawRectangle(new Pen(ClockData.RectangleFrameColor, ClockData.RectangleFramePenWidth),RectangleData.RectangelX,RectanglePositionY,RectangleWidth,RectangleHeight);
        }

        private void ActualRectangleSight()
        {
            Flash();

            rectangle.Clear(!flashBool ? RectangleData.RectangleBasicColor : ClockData.FlashColor);

            DrawRectangle();
        }

        public void ActualRectangleBitmap(object sender, EventArgs e)
        {
            ActualRectangleSight();

            if(InnerTimerIsOnEvent != null)
            {
                InnerTimerIsOnEvent.Invoke(RectangleBitmap);
            }

        }

        public void UpdateFlash(SenderFlashStatus aFlasherButton)
        {
            //innerTimerToCount.Start();

            if (aFlasherButton.Flash)
            {
                counter = 0;
            }
        }

        protected void Flash()
        {
            if (counter < ClockData.FlashNumberForCounter)
            {
                counter++;
                flashBool = !flashBool;
            }
            else
            {
                counter = ClockData.FlashNumberForCounter;
                flashBool = false;
                //innerTimerToCount.Stop();
            }
        }
    }
}
