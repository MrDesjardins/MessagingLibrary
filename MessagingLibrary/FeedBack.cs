using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MessagingLibrary
{
    public class FeedBack:IFeedBack
    {
        public FeedBack()
        {
            this.Code = string.Empty;
            this.Message = string.Empty;
            this.Type = FeedBackType.Unknown;
        }
         public FeedBack(string code, string message, FeedBackType type):this()
        {
            this.AddMessage(code,message,type);
        }
        public FeedBack(string code, string message):this()
        {
            this.AddMessage(code,message);
        }
        public FeedBack(string message):this()
        {
            this.AddMessage(message);
        }
        public FeedBack(string message, FeedBackType type): this()
        {
            this.AddMessage(message,type);
        }
        public string Code{ get; set; }
        public string Message{ get; set; }
        public FeedBackType Type { get; set; }
        public void AddMessage(string code, string message, FeedBackType type)
        {
            this.Code = code;
            this.Message = message;
            this.Type = type;
        }
        public void AddMessage(string code, string message)
        {
            this.Code = code;
            this.Message = message;
        }

        public void AddMessage(string message, FeedBackType type)
        {
            this.Type = type;
            this.Message = message;
        }
        public void AddMessage(string message)
        {
            this.Message = message;
        }



    }
}
