using System;
using MessagingLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestMessagingLibrary
{
    [TestClass]
    public class FeedBackTest
    {
        [TestMethod]
        public void FeedBack_DefaultValue_StringEmpty()
        {
            //Arrange
            var feedBack = new FeedBack();

            //Act
            //-

            //Assert
            Assert.AreEqual(string.Empty,feedBack.Code);
            Assert.AreEqual(string.Empty,feedBack.Message);
            Assert.AreEqual(FeedBackType.Unknown,feedBack.Type);
        }

        [TestMethod]
        public void FeedBack_UsingCodeMessageConstructor_DataSet()
        {
            //Arrange
            const string CODE = "Code123";
            const string MESSAGE = "MessageABC XYZ";
            var feedBack = new FeedBack(CODE, MESSAGE);

            //Act
            //-

            //Assert
            Assert.AreEqual(CODE, feedBack.Code);
            Assert.AreEqual(MESSAGE, feedBack.Message);
            Assert.AreEqual(FeedBackType.Unknown, feedBack.Type);
        }
        [TestMethod]
        public void FeedBack_UsingMessageConstructor_DataSet()
        {
            //Arrange
            
            const string MESSAGE = "MessageABC XYZ";
            var feedBack = new FeedBack(MESSAGE);

            //Act
            //-

            //Assert
            Assert.AreEqual(string.Empty, feedBack.Code);
            Assert.AreEqual(MESSAGE, feedBack.Message);
            Assert.AreEqual(FeedBackType.Unknown, feedBack.Type);
        }
        [TestMethod]
        public void FeedBack_UsingMessageTypeConstructor_DataSet()
        {
            //Arrange
            const FeedBackType TYPE = FeedBackType.Info;
            const string MESSAGE = "MessageABC XYZ";
            var feedBack = new FeedBack(MESSAGE,TYPE);

            //Act
            //-

            //Assert
            Assert.AreEqual(string.Empty, feedBack.Code);
            Assert.AreEqual(MESSAGE, feedBack.Message);
            Assert.AreEqual(TYPE, feedBack.Type);
        }
        [TestMethod]
        public void FeedBack_UsingCodeMessageTypeConstructor_DataSet()
        {
            //Arrange
            const string CODE = "Code123";
            const FeedBackType TYPE = FeedBackType.Info;
            const string MESSAGE = "MessageABC XYZ";
            var feedBack = new FeedBack(CODE,MESSAGE, TYPE);

            //Act
            //-

            //Assert
            Assert.AreEqual(CODE, feedBack.Code);
            Assert.AreEqual(MESSAGE, feedBack.Message);
            Assert.AreEqual(TYPE, feedBack.Type);
        }
    }
}
