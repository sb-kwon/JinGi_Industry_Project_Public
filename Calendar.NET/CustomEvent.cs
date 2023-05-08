using System;
using System.Drawing;

namespace Calendar.NET
{
    /// <summary>
    /// A custom or user-defined event
    /// </summary>
    public class CustomEvent : IEvent
    {
        public int Rank
        {
            get;
            set;
        }

        public float EventLengthInHours
        {
            get;
            set;
        }

        public bool Enabled
        {
            get;
            set;
        }

        public CustomRecurringFrequenciesHandler CustomRecurringFunction
        {
            get;
            set;
        }

        public bool IgnoreTimeComponent
        {
            get;
            set;
        }

        public bool ReadOnlyEvent
        {
            get;
            set;
        }

        public DateTime Date
        {
            get;
            set;
        }

        public Color EventColor
        {
            get;
            set;
        }

        public Font EventFont
        {
            get;
            set;
        }

        public string EventText
        {
            get;
            set;
        }

        public string EventMessage
        {
            get;
            set;
        }

        public Color EventTextColor
        {
            get;
            set;
        }

        public RecurringFrequencies RecurringFrequency
        {
            get;
            set;
        }

        public bool TooltipEnabled
        {
            get;
            set;
        }

        public bool ThisDayForwardOnly
        {
            get;
            set;
        }

        /// <summary>
        /// CustomEvent Constructor
        /// </summary>
        public CustomEvent()
        {
            EventColor = Color.FromArgb(255, 80, 80);
            EventFont = new Font("맑은 고딕", 11, FontStyle.Regular);
            EventTextColor = Color.FromArgb(255, 255, 255);
            Rank = 1;
            ReadOnlyEvent = true;
            Enabled = true;
            IgnoreTimeComponent = true;
            TooltipEnabled = true;
            ThisDayForwardOnly = true;
            RecurringFrequency = RecurringFrequencies.None;
        }

        public IEvent Clone()
        {
            return new CustomEvent
            {
                CustomRecurringFunction = CustomRecurringFunction,
                Date = Date,
                Enabled = Enabled,
                EventColor = EventColor,
                EventFont = EventFont,
                EventText = EventText,
                EventTextColor = EventTextColor,
                IgnoreTimeComponent = IgnoreTimeComponent,
                Rank = Rank,
                ReadOnlyEvent = ReadOnlyEvent,
                RecurringFrequency = RecurringFrequency,
                ThisDayForwardOnly = ThisDayForwardOnly,
                EventLengthInHours = EventLengthInHours,
                TooltipEnabled = TooltipEnabled
            };
        }
    }
}
