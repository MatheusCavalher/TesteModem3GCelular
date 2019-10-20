using System;
using System.Collections.Generic;

namespace smsTeste
{
    public class ShortMessage
    {
        #region Private Variables
        private String index;
        private String status;
        private String sender;
        private String alphabet;
        private String sent;
        private String message;
        #endregion

        public String Index
        {
            get { return index; }
            set { index = value; }
        }
        public String Status
        {
            get { return status; }
            set { status = value; }
        }
        public String Sender
        {
            get { return sender; }
            set { sender = value; }
        }
        public String Alphabet
        {
            get { return alphabet; }
            set { alphabet = value; }
        }
        public String Sent
        {
            get { return sent; }
            set { sent = value; }
        }
        public String Message
        {
            get { return message; }
            set { message = value; }
        }
    }
    public class ShortMessageCollection : List<ShortMessage>
    {
    }
}
