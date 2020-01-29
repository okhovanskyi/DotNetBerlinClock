using BerlinClock;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace BerlinClockTests
{
    [TestClass]
    public class TimeConverterTestClass
    {
        private ITimeConverter _timeConver;
        private const string _turnedOff = "O";
        private const string _yellow = "Y";
        private const string _red = "R";

        [TestInitialize]
        public void Initialize()
        {
            _timeConver = new TimeConverter();
        }

        #region First Hours Row Tests
        [TestMethod]
        public void ConvertHoursTest_AssertFirstHoursRowLengthEqualsFour()
        {
            var result = _timeConver.ConvertHours(24);
            var firstRow = result.Split(Environment.NewLine)?.First();
            Assert.IsNotNull(firstRow);
            Assert.AreEqual(firstRow.Length, 4);
        }

        [TestMethod]
        public void ConvertHoursTest_AssertFirstHoursRowColorIsRed()
        {
            var result = _timeConver.ConvertHours(24);
            var firstRow = result.Split(Environment.NewLine)?.First();
            Assert.IsNotNull(firstRow);
            Assert.IsTrue(firstRow.Contains(_red));
            Assert.IsFalse(firstRow.Contains(_turnedOff));
        }
        #endregion
        #region Second Hours Row Tests
        [TestMethod]
        public void ConvertHoursTest_AssertSecondHoursRowLengthEqualsFour()
        {
            var result = _timeConver.ConvertHours(24);
            var secondRow = result.Split(Environment.NewLine)?.Last();
            Assert.IsNotNull(secondRow);
            Assert.AreEqual(secondRow.Length, 4);
        }

        [TestMethod]
        public void ConvertHoursTest_AssertSecondHoursRowColorIsRed()
        {
            var result = _timeConver.ConvertHours(24);
            var secondRow = result.Split(Environment.NewLine)?.Last();
            Assert.IsNotNull(secondRow);
            Assert.IsTrue(secondRow.Contains(_red));
            Assert.IsFalse(secondRow.Contains(_turnedOff));
        }
        #endregion
        #region Both Hours Rows Tests
        [TestMethod]
        public void ConvertHoursTest_AssertFirstAndSecondHoursRowsAreTurnedOff()
        {
            var result = _timeConver.ConvertHours(0);
            Assert.IsNotNull(result);
            Assert.IsFalse(result.Contains(_yellow));
        }

        [TestMethod]
        public void ConvertHoursTest_AssertFirstAndSecondHoursRowsFullyOn()
        {
            var result = _timeConver.ConvertHours(24);
            Assert.IsNotNull(result);
            Assert.IsFalse(result.Contains(_turnedOff));
        }
        #endregion
        #region First Minutes Row Tests
        [TestMethod]
        public void ConvertMinutesTest_AssertFirstMinutesRowLengthEqualsEleven()
        {
            var result = _timeConver.ConvertMinutes(59);
            var firstRow = result.Split(Environment.NewLine)?.First();
            Assert.IsNotNull(firstRow);
            Assert.AreEqual(firstRow.Length, 11);
        }

        [TestMethod]
        public void ConvertMinutesTest_AssertFirstMinutesRowColorIsYellowWithRed()
        {
            var result = _timeConver.ConvertMinutes(59);
            var firstRow = result.Split(Environment.NewLine)?.First();
            Assert.IsNotNull(firstRow);
            Assert.IsTrue(firstRow.Contains(_yellow));
            Assert.IsTrue(firstRow.Contains(_red));
            Assert.IsFalse(firstRow.Contains(_turnedOff));
        }
        #endregion
        #region Second Minutes Row Tests
        [TestMethod]
        public void ConvertMinutesTest_AssertSecondMinutesRowLengthEqualsFour()
        {
            var result = _timeConver.ConvertMinutes(59);
            var secondRow = result.Split(Environment.NewLine)?.Last();
            Assert.IsNotNull(secondRow);
            Assert.AreEqual(secondRow.Length, 4);
        }

        [TestMethod]
        public void ConvertMinutesTest_AssertSecondMinutesRowColorIsYellow()
        {
            var result = _timeConver.ConvertMinutes(59);
            var secondRow = result.Split(Environment.NewLine)?.Last();
            Assert.IsNotNull(secondRow);
            Assert.IsTrue(secondRow.Contains(_yellow));
            Assert.IsFalse(secondRow.Contains(_turnedOff));
        }
        #endregion
        #region Both Minutes Rows Tests
        [TestMethod]
        public void ConvertHoursTest_AssertFirstAndSecondMinutesRowsTurnedOff()
        {
            var result = _timeConver.ConvertMinutes(0);
            Assert.IsNotNull(result);
            Assert.IsFalse(result.Contains(_yellow));
            Assert.IsFalse(result.Contains(_red));
        }

        [TestMethod]
        public void ConvertHoursTest_AssertFirstAndSecondMinutesRowsFullyOn()
        {
            var result = _timeConver.ConvertMinutes(59);
            Assert.IsNotNull(result);
            Assert.IsFalse(result.Contains(_turnedOff));
        }
        #endregion
        #region Seconds Light Tests
        [TestMethod]
        public void ConvertSecondsTest_AssertSeconsLightTurnedOffTakingOddValue()
        {
            var result = _timeConver.ConvertSeconds(3);
            Assert.AreEqual(_turnedOff, result);
        }

        [TestMethod]
        public void ConvertSecondsTest_AssertSeconsLightTurnedOnTakingEvenValue()
        {
            var result = _timeConver.ConvertSeconds(2);
            Assert.AreEqual(_yellow, result);
        }
        #endregion
        #region convertTime Tests
        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void convertTimeTest_VerifyIndexOutOfRangeExceptionOnSeparatorOtherThanColon()
        {
            var result = _timeConver.convertTime("24/59/59");
        }

        [TestMethod]
        public void convertTimeTest_AssertNumberOfTornedOffLightsEqualsZero()
        {
            const string edgeCase = "24:59:00";

            var result = _timeConver.convertTime(edgeCase);
            Assert.IsFalse(result.Contains(_turnedOff));
        }
        #endregion
    }
}
