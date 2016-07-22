using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessagingLibrary
{
    public class FeedBackCollection:IFeedBack
    {
        public FeedBackCollection()
        {
            Messages = new List<IFeedBack>();
        }
        public List<IFeedBack> Messages { get; set; }

        public string Code
        {
            get {
                return Messages.Any() ? Messages.Select(d => d.Code).Aggregate((current, next) => string.Format("{0}, {1}", current, next)) : string.Empty;
            }
            set { throw new NotImplementedException("Setting Code is not possible for FeedBackCollection"); }
        }

        public string Message
        {
            get
            {
                return Messages.Any() ? Messages.Select(d => d.Message).Aggregate((current, next) => string.Format("{0}, {1}", current, next)) : string.Empty;
            }
            set { throw new NotImplementedException("Setting Message is not possible for FeedBackCollection"); }
        }

        public FeedBackType Type
        {
            get
            {
                if (Messages.Any())
                {
                    var allSameType = Messages.All(d => d.Type == Messages.First().Type);
                    return allSameType ? Messages.First().Type : FeedBackType.Unknown;
                }
                else
                {
                    return FeedBackType.Unknown;
                }
            }
            set { throw new NotImplementedException("Setting Type is not possible for FeedBackCollection"); }
        }

        public bool IsValid { get; set; }

        public void AddMessage(string code, string message)
        {
            Messages.Add(new FeedBack(code,message));
        }

        public void AddMessage(string message)
        {
            Messages.Add(new FeedBack(message));
        }

        public void AddMessage(string code, string message, FeedBackType type)
        {
            Messages.Add(new FeedBack(code, message,type));
        }

        public void AddMessage(string message, FeedBackType type)
        {
            Messages.Add(new FeedBack(message,type));
        }
        public void AddMessage(IFeedBack message)
        {
            Messages.Add(message);
        }
    }
}
