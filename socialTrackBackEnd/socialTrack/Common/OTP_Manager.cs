using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace socialTrack.Common
{
    public class OTP_Manager
    {
        public string GenerateOtp()
        {
            string otp = "";
            Random random = new Random();
            otp = random.Next(10000, 99999).ToString();
            return otp;
        }

        public bool sendotp(string phoneNo, string otp)
        {
            phoneNo = "+91" + phoneNo;
            string accountSid = "ACdc382fc380f53c4bbd81291d5af472c5";
            string authToken = "caad0edf4c0fedc71cd9d2c17bccb01e";

            TwilioClient.Init(accountSid, authToken);

            var message = MessageResource.Create(
                body: "Your OTP is " + otp,
                from: new Twilio.Types.PhoneNumber("+12138949495"),
                to: new Twilio.Types.PhoneNumber(phoneNo)
            );

            if (!message.ErrorCode.HasValue)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        internal static string GenerateOTP()
        {
            throw new NotImplementedException();
        }
    }
}
