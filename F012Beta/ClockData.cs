using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using F012Beta;
using System.Drawing;

namespace F012Beta
{
    public class ClockData
    {
        #region AnalogClockData

        public const int AnalogClockWidth = 300;
        public const int AnalogClockHeight = 300;
        public const int AnalogClockSecondHandLength = 140;
        public const int AnalogClockMinutehandLength = 110;
        public const int AnalogClockHourHandLength = 80;

        public const string AnalogTweleve = "12";
        public const string AnalogThree = "3";
        public const string AnalogSix = "6";
        public const string AnalogNine = "9";

        public const float AnalogClockPenWidth = 1f;
        public const int AnalogClockNumberSize = 12;

        public const int AnalogClockEllipseX = 0;
        public const int AnalogClockEllipseY = 0;

        public static readonly Point AnalogTwelveNumberCoordinate = new Point(140, 2);
        public static readonly Point AnalogThreeNumberCoordinate = new Point(286, 140);
        public static readonly Point AnalogSixNumberCoordinate = new Point(142, 282);
        public static readonly Point AnalogNineNumberCoordinate = new Point(0, 140);

        public static readonly Brush BrushesForNumbers = Brushes.Black;

        public static readonly Color EllipseColor = Color.Black;
        public static readonly Color SecondHandColor = Color.Red;
        public static readonly Color MinuteHandColor = Color.Blue;
        public static readonly Color HourHandColor = Color.Black;

        public const int HalfCircleNumber = 180;
        public const int HourHandDegree = 30;
        public const double HourHandMinuteTickDegree = 0.5;
        public const int SecondHandTickDegree = 6;
        public const int NumberOfHours = 12;
    
        #endregion

        #region DigitalClockData

        public static readonly Point DigitalNumbersStartCoordinate = new Point(-4, 5);

        public const int DigitalNumberSize = 28;

        public const int DigitalClockWidth = 150;
        public const int DigitalClockHeight = 50;

        public const int DigitalClockX = 0;
        public const int DigitalClockY = 0;

        public static readonly Color RectangleFrameColor = Color.Black;
        public const float RectangleFramePenWidth = 2f;

        #endregion

        #region CommonData

        public const string FontType = "Arial";

        public const int TimerIntervals = 1000;
        public const int MinuteAssistNumber = 60;
        public const int HourAssistNumber = 60;
        public const int FlashNumberForCounter = 7;

        public static readonly Color FlashColor = Color.Red;
        public static readonly Color NumberColor = Color.Black;
        public static readonly Color BackgoundColor = Color.White;

        #endregion
    }

}