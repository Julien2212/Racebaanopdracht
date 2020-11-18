using Model;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace ControllerTest
{
    [TestFixture]
    public class Model_Competition_NextTrackShould
    {
        private Competition _competition;


        [SetUp]
        public void SetUp()
        {
            _competition = new Competition();
        }

        [Test]
        public void NextTrack_EmptyQueue_ReturnNull()
        {

            var result = _competition.NextTrack();
            Assert.IsNull(result);
        }

        [Test]
        public void NextTrack_OneInQueue_ReturnTrack()
        {
            Track TestTrack = new Track("testtrack", new SectionTypes[]{SectionTypes.StartGrid, SectionTypes.Straight, SectionTypes.Finish});
            _competition.Tracks.Enqueue(TestTrack);
            var result = _competition.NextTrack();
            Assert.AreEqual(result, TestTrack);
        }

        [Test]
        public void NextTrack_OneInQueue_RemoveTrackFromQueue()
        {
            Track TestTrack2 = new Track("testtrack2", new SectionTypes[] { SectionTypes.StartGrid, SectionTypes.Straight, SectionTypes.Finish });
            _competition.Tracks.Enqueue(TestTrack2);
            var result = _competition.NextTrack();
            result = _competition.NextTrack();
            Assert.IsNull(result);
        }

        [Test]
        public void NextTrack_TwoInQueue_ReturnNextTrack()
        {
            Track TestTrack3 = new Track("testtrack3", new SectionTypes[] { SectionTypes.StartGrid, SectionTypes.Straight, SectionTypes.Finish });
            Track TestTrack4 = new Track("testtrack4", new SectionTypes[] { SectionTypes.StartGrid, SectionTypes.Straight, SectionTypes.Finish });
            _competition.Tracks.Enqueue(TestTrack3);
            _competition.Tracks.Enqueue(TestTrack4);
            var result1 = _competition.NextTrack();
            var result2 = _competition.NextTrack();
            Assert.AreEqual(result1,TestTrack3);
            Assert.AreEqual(result2, TestTrack4);
        }
    }
}
