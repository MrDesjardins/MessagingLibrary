using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessagingLibrary
{
    public enum FeedBackType
    {
        Unknown,
        Trace,
        Debug,
        Info,
        Warning,
        Error,
        Fatal
    }

    public interface IFeedBack
    {
        string Code { get; set; }
        string Message { get; set; }
        FeedBackType Type { get; set; }
        bool IsValid { get; set; }
        void AddMessage(string code, string message);
        void AddMessage(string message);
        void AddMessage(string code, string message, FeedBackType type);
        void AddMessage(string message, FeedBackType type);
    }
}
