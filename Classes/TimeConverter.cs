using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BerlinClock
{
    public class TimeConverter : ITimeConverter
    {
        private const char _turnedOff = 'O';
        private const char _yellow = 'Y';
        private const char _red = 'R';
        private const string _initialElevenLightsTurnedOff = "OOOOOOOOOOO";
        private const string _initialEleventLightsTurnedOn = "YYRYYRYYRYY";
        private const string _initialFourLightsTurnedOffRow = "OOOO";

        public string ConvertHours(int hours)
        {
            var firstRowLightsOnNumber = hours / 5;
            var secondRowLightsOnNumber = hours % 5;

            var firstRow = _initialFourLightsTurnedOffRow
                           .Remove(0, firstRowLightsOnNumber)
                           .Insert(0, new string(_red, firstRowLightsOnNumber));
                
            var secondRow = _initialFourLightsTurnedOffRow
                           .Remove(0, secondRowLightsOnNumber)
                           .Insert(0, new string(_red, secondRowLightsOnNumber));

            return $"{firstRow}{Environment.NewLine}{secondRow}";
        }

        public string ConvertMinutes(int minutes)
        {
            var firstRowLightsOnNumber = minutes / 5;
            var secondRowLightsOnNumber = minutes % 5;

            var firstRowIntermediateBuffer = _initialEleventLightsTurnedOn.Substring(0, firstRowLightsOnNumber);

            var firstRow = _initialElevenLightsTurnedOff
                           .Remove(0, firstRowLightsOnNumber)
                           .Insert(0, firstRowIntermediateBuffer);

            var secondRow = _initialFourLightsTurnedOffRow
                           .Remove(0, secondRowLightsOnNumber)
                           .Insert(0, new string(_yellow, secondRowLightsOnNumber));

            return $"{firstRow}{Environment.NewLine}{secondRow}";
        }

        public string ConvertSeconds(int seconds)
        {
            if (seconds % 2 == 0)
            {
                return _yellow.ToString();
            }
            return _turnedOff.ToString();
        }

        public string convertTime(string aTime)
        {
            var splittedStringArray = aTime.Split(':'); 
            var stringBuilder = new StringBuilder();
            stringBuilder.Append(ConvertSeconds(int.Parse(splittedStringArray[2])));
            stringBuilder.Append(Environment.NewLine);
            stringBuilder.Append(ConvertHours(int.Parse(splittedStringArray[0])));
            stringBuilder.Append(Environment.NewLine);
            stringBuilder.Append(ConvertMinutes(int.Parse(splittedStringArray[1])));

            return stringBuilder.ToString();
        }
    }
}
