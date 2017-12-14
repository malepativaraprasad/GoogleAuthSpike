using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoogleAuthSpike
{
    public class GoogleAuthModel
    {
        public string Id { get; set; }
        public string DbUserId { get; set; }
        public string CoreKey { get; set; }
        public string Username { get; set; }
        public string PassCodeGoogleSecret { get; set; }
        public bool PassCodeGoogleActive { get; set; }
    }
}
