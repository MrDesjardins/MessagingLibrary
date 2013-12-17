using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MessagingLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestMessagingLibrary
{
    [TestClass]
    public class FeedBackCollectionTest
    {
        [TestMethod]
        public void FeedBackCollection_DefaultValue_StringEmpty()
        {
            //Arrange
            var feedBack = new FeedBackCollection();

            //Act
            //-

            //Assert
            Assert.AreEqual(string.Empty, feedBack.Code);
            Assert.AreEqual(string.Empty, feedBack.Message);
            Assert.AreEqual(FeedBackType.Unknown, feedBack.Type);
        }
        [TestMethod]
        public void FeedBackCollection_AddNewIFeedBack_StringMessage()
        {
            //Arrange
            const string CODE = "Code123";
            const string MESSAGE = "MessageABC XYZ";
            var feedBack = new FeedBackCollection();
            var feedBack1 = new FeedBack(CODE, MESSAGE, FeedBackType.Info);

            //Act
            feedBack.AddMessage(feedBack1);

            //Assert
            Assert.AreEqual(CODE, feedBack.Code);
            Assert.AreEqual(MESSAGE, feedBack.Message);
            Assert.AreEqual(FeedBackType.Info, feedBack.Type);
        }

        [TestMethod]
        public void FeedBackCollection_AddTwoNewIFeedBackWithSameType_StringMessageConcatenate()
        {
            //Arrange
            const string CODE1 = "Code123";
            const string CODE2 = "Code456";
            const string MESSAGE1 = "MessageABC XYZ";
            const string MESSAGE2 = "Message ZZZ";
            var feedBack = new FeedBackCollection();
            var feedBack1 = new FeedBack(CODE1, MESSAGE1, FeedBackType.Info);
            var feedBack2 = new FeedBack(CODE2, MESSAGE2, FeedBackType.Info);

            //Act
            feedBack.AddMessage(feedBack1);
            feedBack.AddMessage(feedBack2);

            //Assert
            Assert.AreEqual(CODE1 + ", "+ CODE2, feedBack.Code);
            Assert.AreEqual(MESSAGE1 + ", " + MESSAGE2, feedBack.Message);
            Assert.AreEqual(FeedBackType.Info, feedBack.Type);
        }

        [TestMethod]
        public void FeedBackCollection_AddTwoNewIFeedBackWithNotSameType_StringMessageConcatenate()
        {
            //Arrange
            const string CODE1 = "Code123";
            const string CODE2 = "Code456";
            const string MESSAGE1 = "MessageABC XYZ";
            const string MESSAGE2 = "Message ZZZ";
            var feedBack = new FeedBackCollection();
            var feedBack1 = new FeedBack(CODE1, MESSAGE1, FeedBackType.Info);
            var feedBack2 = new FeedBack(CODE2, MESSAGE2, FeedBackType.Warning);

            //Act
            feedBack.AddMessage(feedBack1);
            feedBack.AddMessage(feedBack2);

            //Assert
            Assert.AreEqual(CODE1 + ", " + CODE2, feedBack.Code);
            Assert.AreEqual(MESSAGE1 + ", " + MESSAGE2, feedBack.Message);
            Assert.AreEqual(FeedBackType.Unknown, feedBack.Type);
        }
    }
}
