using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheGame.Models
{
    public class LostModel
    {
        public string Name { get; set; }
        public string From { get; set; }

        // Added custom tag support for when you want to speak to the victim; Punkin' with a personal touch.
        public string Tag { get; set; }
        public string LaughingAtYourLossImage { get; set; }
    }
}