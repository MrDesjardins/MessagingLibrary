using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MessagingLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSTestExtensions;

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

        [TestMethod]
        public void FeedBackCollection_TryToSetCode_ThrowException()
        {
            //Arrange
            const string CODE1 = "Code123";
            var feedBack = new FeedBackCollection();

            //Act & Assert
            ExceptionAssert.Throws<NotImplementedException>(()=>feedBack.Code = CODE1);
        }
        [TestMethod]
        public void FeedBackCollection_TryToSetMessage_ThrowException()
        {
            //Arrange
            const string MESSAGE1 = "MessageABC XYZ";
            var feedBack = new FeedBackCollection();

            //Act & Assert
            ExceptionAssert.Throws<NotImplementedException>(() => feedBack.Message = MESSAGE1);
        }

        [TestMethod]
        public void FeedBackCollection_TryToSetType_ThrowException()
        {
            //Arrange
            var feedBack = new FeedBackCollection();

            //Act & Assert
            ExceptionAssert.Throws<NotImplementedException>(() => feedBack.Type = FeedBackType.Info);
        }

        [TestMethod]
        public void FeedBackCollection_AddMessageWithMessageOnly_MessageIsSet()
        {
            //Arrange
            const string MESSAGE1 = "MessageABC XYZ";
            var feedBack = new FeedBackCollection();

            //Act
            feedBack.AddMessage(MESSAGE1);

            //Assert
            Assert.AreEqual(MESSAGE1, feedBack.Message);
        }

        [TestMethod]
        public void FeedBackCollection_AddMessageWithCodeMessagOnly_MessageCodeAreSet()
        {
            //Arrange
            const string CODE1 = "Code123";
            const string MESSAGE1 = "MessageABC XYZ";
            var feedBack = new FeedBackCollection();

            //Act
            feedBack.AddMessage(CODE1,MESSAGE1);

            //Assert
            Assert.AreEqual(CODE1, feedBack.Code);
            Assert.AreEqual(MESSAGE1, feedBack.Message);
            Assert.AreEqual(FeedBackType.Unknown, feedBack.Type);
        }

        [TestMethod]
        public void FeedBackCollection_AddMessageWithCodeMessageTypeOnly_MessageCodeTypeAreSet()
        {
            //Arrange
            const string CODE1 = "Code123";
            const string MESSAGE1 = "MessageABC XYZ";
            var feedBack = new FeedBackCollection();

            //Act
            feedBack.AddMessage(CODE1, MESSAGE1, FeedBackType.Info);

            //Assert
            Assert.AreEqual(CODE1, feedBack.Code);
            Assert.AreEqual(MESSAGE1, feedBack.Message);
            Assert.AreEqual(FeedBackType.Info, feedBack.Type);
        }

        [TestMethod]
        public void FeedBackCollection_AddMessageWithMessageTypeOnly_MessageTypeAreSet()
        {
            //Arrange
            const string MESSAGE1 = "MessageABC XYZ";
            var feedBack = new FeedBackCollection();

            //Act
            feedBack.AddMessage(MESSAGE1, FeedBackType.Info);

            //Assert
            Assert.AreEqual(string.Empty,feedBack.Code);
            Assert.AreEqual(MESSAGE1, feedBack.Message);
            Assert.AreEqual(FeedBackType.Info, feedBack.Type);
        }
    }
}
