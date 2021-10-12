using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Capstone
{
    public class Story
    {

        //instance variables
        private string title;
        private string source;
        private string body;

        //default constructor
        public Story()
        {

        }

        //constructor with parameters
        public Story(string t, string s, string b)
        {
            setTitle(t);
            setSource(s);
            setBody(b);
        }

        //title setter
        public void setTitle(string title)
        {
            this.title = title;
        }

        //source setter
        public void setSource(string source)
        {
            this.source = source;
        }

        //body setter
        public void setBody(string body)
        {
            this.body = body;
        }

        //title getter
        public string getTitle()
        {
            return title;
        }

        //source getter
        public string getSource()
        {
            return source;
        }

        //body getter
        public string getBody()
        {
            return body;
        }


    }
}