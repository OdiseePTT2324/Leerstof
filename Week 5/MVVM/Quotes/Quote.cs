﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quotes
{
    public class Quote
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string Author { get; set; }

        public Quote(string text, string author)
        {
            Text = text;
            Author = author;
        }

        public Quote()
        {

        }

        public override string ToString()
        {
            if (Text.Length > 10) { 
                return Author + ":\t" + Text.Substring(0, 10);
            } else
            {
                return Author + ":\t" + Text;
            }
        }
    }
}
