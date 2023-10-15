using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace Core.Common.Helpers
{

    public class AppHelper
    {
        private static string PasswordKey = "zdfvdsfHgdhhDSHFSD$#%SDVZDFGTd";
        public static byte[] GetMD5HashData(string data, ref int index)
        {
            index = 0;
            try
            {
                index = 1;
                MD5 md5 = MD5.Create();//Create(PasswordKey)
                index = 2;
                byte[] bytes = Encoding.Default.GetBytes(data);
                index = 3;
                byte[] resultHashData = md5.ComputeHash(bytes);
                index = 4;
                return resultHashData;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public static int GenerateRandomNo4digits()
        {
            int _min = 1000;
            int _max = 9999;
            Random _rdm = new Random();
            return _rdm.Next(_min, _max);
        }

        public static byte[] GetMD5HashData(string data)
        {

            try
            {

                MD5 md5 = MD5.Create();

                byte[] bytes = Encoding.Default.GetBytes(data);

                byte[] resultHashData = md5.ComputeHash(bytes);

                return resultHashData;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public static byte[] GetMD5HashData2(string data)
        {
            MD5 md5 = MD5.Create();

            byte[] resultHashData = md5.ComputeHash(Encoding.Default.GetBytes(data));

            return resultHashData;
        }

        public static string GetSHA1HashData(string data)
        {
            //create new instance of md5
            SHA1 sha1 = SHA1.Create();

            //convert the input text to array of bytes
            byte[] hashData = sha1.ComputeHash(Encoding.Default.GetBytes(data));

            //create new instance of StringBuilder to save hashed data
            StringBuilder returnValue = new StringBuilder();

            //loop for each byte and add it to StringBuilder
            for (int i = 0; i < hashData.Length; i++)
            {
                returnValue.Append(hashData[i].ToString());
            }

            // return hexadecimal string
            return returnValue.ToString();
        }

        private static bool ValidateMD5HashData(string inputData, string storedHashData)
        {
            //hash input text and save it string variable
            string getHashInputData = inputData;

            if (string.Compare(getHashInputData, storedHashData) == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static bool ValidateSHA1HashData(string inputData, string storedHashData)
        {
            //hash input text and save it string variable
            string getHashInputData = GetSHA1HashData(inputData);

            if (string.Compare(getHashInputData, storedHashData) == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        //public static List<SpParametersInfo> GetParametersInfo(object parameters)
        //{
        //    List<SpParametersInfo> result = new List<SpParametersInfo>();



        //    Type mytype = parameters.GetType();
        //    IList<PropertyInfo> props = new List<PropertyInfo>(mytype.GetProperties());

        //    var lstFieldName = props.Select(p => p.Name).ToList();

        //    Type type = parameters.GetType();

        //    FieldInfo[] fields = type.GetFields();
        //    foreach (var p in props)
        //    {
        //        object value = null;
        //        string name = p.Name;
        //        object temp = p.GetValue(parameters);
        //        if (temp is int)
        //        {
        //            value = (int)temp;
        //        }
        //        else if (temp is string)
        //        {
        //            value = temp as string;
        //        }
        //        result.Add(new SpParametersInfo()
        //        {
        //            Name = name,
        //            Value = value
        //        });
        //    }
        //    return result;
        //}


        public static bool ComparerPassword(byte[] dbPass, byte[] entryPass)
        {
            HashAlgorithm ha = HashAlgorithm.Create();
            string strDbPass = BitConverter.ToString(dbPass);
            string strEntryPass = BitConverter.ToString(entryPass);
            if (strDbPass == strEntryPass)
                return true;
            return false;
        }

        public static byte[] StrToMD5Hash(string strKey, string password)
        {
            var byteKey = System.Text.Encoding.UTF8.GetBytes(strKey);
            var md5 = new HMACMD5(byteKey);
            var bytePass = System.Text.Encoding.UTF8.GetBytes(password);
            var passHash = md5.ComputeHash(bytePass);
            return passHash;
        }

        public static bool SendEmail(string to, string subject, string body, string mailAddress = null, string password = null)
        {
            try
            {
                if (string.IsNullOrEmpty(mailAddress))
                    mailAddress = "Info@peykegol.com";

                if (string.IsNullOrEmpty(password))
                    password = "ir4BWRaXxiq35Z9";

                var dateNum = (int)(DateTime.Now - new DateTime(1900, 1, 1)).TotalDays;
                MailMessage mail = new MailMessage();
                SmtpClient smtpServer = new SmtpClient("smtp.gmail.com");

                mail.From = new MailAddress(mailAddress);
                mail.To.Add(to);
                mail.Subject = subject;
                mail.Body = body;

                smtpServer.Port = 587;
                smtpServer.Credentials = new System.Net.NetworkCredential(mailAddress, password);
                smtpServer.EnableSsl = true;

                smtpServer.Send(mail);

                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw;
            }
        }

        public static string SendSMS(string smsphone, string smstext)
        {

            string smsMessage = HttpUtility.UrlEncode(smstext);

            // Create a request using a URL that can receive a post. 
            string uri = "http://ws3584.isms.ir/sendWS?";
            string postData = "username=iranaustralia&password=88927127&mobiles%5B0%5D=" + smsphone + "&body=" + smsMessage;

            HttpWebRequest request = (HttpWebRequest)
            WebRequest.Create(uri); request.KeepAlive = false;
            request.ProtocolVersion = HttpVersion.Version10;
            request.Method = "POST";

            byte[] postBytes = Encoding.ASCII.GetBytes(postData);
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = postBytes.Length;
            Stream requestStream = request.GetRequestStream();

            // now send it
            requestStream.Write(postBytes, 0, postBytes.Length);
            requestStream.Close();

            // grab the response and print it out to the console along with the status code
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();


            return new StreamReader(response.GetResponseStream()).ReadToEnd() + response.StatusCode.ToString();
        }


        public static byte[] ConvertBitMapToByteArray(Image bitmap)
        {
                byte[] result = null;

                if (bitmap != null)
                {
                    MemoryStream stream = new MemoryStream();
                    //bitmap.Save(stream, bitmap.RawFormat);
                    bitmap.Save(stream, ImageFormat.Jpeg);
                    result = stream.ToArray();
                }

                return result;
        }

        public static string GenerateImage(string text, int width, int height)
        {
            Bitmap bmp = new Bitmap(width, height);
            Graphics g = Graphics.FromImage(bmp);
            SolidBrush sb = new SolidBrush(Color.White);
            g.FillRectangle(sb, 0, 0, bmp.Width, bmp.Height);
            Font font = new Font("Tahoma", 20);
            sb = new SolidBrush(Color.Black);
            g.DrawString(text, font, sb, bmp.Width / 2 - (text.Length / 2) * font.Size, (bmp.Height / 2) - font.Size);
            int count = 0;
            Random rand = new Random();
            while (count < 180)
            {
                sb = new SolidBrush(Color.LightSlateGray);
                g.FillEllipse(sb, rand.Next(0, bmp.Width), rand.Next(0, bmp.Height), 4, 2);
                count++;
            }
            count = 0;
            while (count < 10)
            {
                g.DrawLine(new Pen(Color.Bisque), rand.Next(0, bmp.Width), rand.Next(0, bmp.Height), rand.Next(0, bmp.Width), rand.Next(0, bmp.Height));
                count++;
            }

            Image img = (Image)bmp;

            return Convert.ToBase64String(ConvertBitMapToByteArray(img));
        }


        public static string CaptchaToImage(string text, int width, int height)
        {
            Random random = new Random();

            Bitmap bitmap = new Bitmap
              (width, height, PixelFormat.Format32bppArgb);
            Graphics g = Graphics.FromImage(bitmap);
            g.SmoothingMode = SmoothingMode.AntiAlias;
            Rectangle rect = new Rectangle(0, 0, width, height);
            HatchBrush hatchBrush = new HatchBrush(HatchStyle.SmallConfetti,
                Color.LightGray, Color.White);
            g.FillRectangle(hatchBrush, rect);
            SizeF size;
            float fontSize = rect.Height + 1;
            Font font;

            do
            {
                fontSize--;
                font = new Font(FontFamily.GenericSansSerif, fontSize, FontStyle.Bold);
                size = g.MeasureString(text, font);
            } while (size.Width > rect.Width);
            StringFormat format = new StringFormat();
            format.Alignment = StringAlignment.Center;
            format.LineAlignment = StringAlignment.Center;
            GraphicsPath path = new GraphicsPath();
            //path.AddString(this.text, font.FontFamily, (int) font.Style, 
            //    font.Size, rect, format);
            path.AddString(text, font.FontFamily, (int)font.Style, 35, rect, format);
            float v = 4F;
            PointF[] points =
            {
                new PointF(random.Next(rect.Width) / v, random.Next(
                   rect.Height) / v),
                new PointF(rect.Width - random.Next(rect.Width) / v,
                    random.Next(rect.Height) / v),
                new PointF(random.Next(rect.Width) / v,
                    rect.Height - random.Next(rect.Height) / v),
                new PointF(rect.Width - random.Next(rect.Width) / v,
                    rect.Height - random.Next(rect.Height) / v)
          };
            Matrix matrix = new Matrix();
            matrix.Translate(0F, 0F);
            path.Warp(points, rect, matrix, WarpMode.Perspective, 0F);
            hatchBrush = new HatchBrush(HatchStyle.Percent10, Color.Black, Color.SkyBlue);
            g.FillPath(hatchBrush, path);
            int m = Math.Max(rect.Width, rect.Height);
            for (int i = 0; i < (int)(rect.Width * rect.Height / 30F); i++)
            {
                int x = random.Next(rect.Width);
                int y = random.Next(rect.Height);
                int w = random.Next(m / 50);
                int h = random.Next(m / 50);
                g.FillEllipse(hatchBrush, x, y, w, h);
            }

            int count = 0;
            while (count < 10)
            {
                g.DrawLine(new Pen(Color.LightGreen), random.Next(0, bitmap.Width), random.Next(0, bitmap.Height), random.Next(0, bitmap.Width), random.Next(0, bitmap.Height));
                count++;
            }

            font.Dispose();
            hatchBrush.Dispose();
            g.Dispose();

            return Convert.ToBase64String(ConvertBitMapToByteArray(bitmap));
        }

    }
}
