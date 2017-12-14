using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Google.Authenticator;
using Microsoft.Extensions.Configuration;
namespace GoogleAuthSpike
{
    public class GoogleAuthUtil
    {
        IConfiguration _config;
        public GoogleAuthUtil(IConfiguration config)
        {
            _config = config;
            userSecretKey = _config.GetSection("appSettings")["GoogleSecretKey"];
        }

        public string userSecretKey { get; set; }

        public SetupCode GetScanCode()
        {
            TwoFactorAuthenticator tfa = new TwoFactorAuthenticator();
            SetupCode setupInfo = tfa.GenerateSetupCode("Test", "m.varaprasadmca@gmail.com", userSecretKey, 300, 300);
            return setupInfo;
        }

        public bool ValidateCode(string code, string secretKey = null)
        {
            if (string.IsNullOrEmpty(secretKey))
                secretKey = userSecretKey;

            TwoFactorAuthenticator tfa = new TwoFactorAuthenticator();
            bool isCorrectPIN = tfa.ValidateTwoFactorPIN(secretKey, code);
            return isCorrectPIN;
        }
    }
}
