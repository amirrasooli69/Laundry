using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    class Data_Importer
    {

        public async Task<string> GET(string url)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var values = new Dictionary<string, string>
                        {
                            { "Nothing", "Nothing" }
                        };

                    var content = new FormUrlEncodedContent(values);

                    var response = await client.PostAsync(url, content);

                    var responseString = await response.Content.ReadAsStringAsync();
                    return responseString;
                }
            }
            catch (WebException ex)
            {
                WebResponse errorResponse = ex.Response;
                using (Stream responseStream = errorResponse.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(responseStream, Encoding.GetEncoding("utf-8"));
                    String errorText = reader.ReadToEnd();
                    // log errorText
                }
                throw;
            }
        }

        //public async Task<string> GET(string url, string Application)
        //{
        //    try
        //    {
        //        using (var client = new HttpClient())
        //        {
        //            var values = new Dictionary<string, string>
        //                {
        //                    { "Application", Application }
        //                };

        //            var content = new FormUrlEncodedContent(values);

        //            var response = await client.PostAsync(url, content);

        //            var responseString = await response.Content.ReadAsStringAsync();
        //            return responseString;
        //        }
        //    }
        //    catch (WebException ex)
        //    {
        //        string asd = ex.ToString();
        //        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
        //        try
        //        {
        //            WebResponse response = request.GetResponse();
        //            using (Stream responseStream = response.GetResponseStream())
        //            {
        //                StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
        //                return reader.ReadToEnd();
        //            }
        //        }
        //        catch (WebException exx)
        //        {
        //            WebResponse errorResponse = exx.Response;
        //            using (Stream responseStream = errorResponse.GetResponseStream())
        //            {
        //                StreamReader reader = new StreamReader(responseStream, Encoding.GetEncoding("utf-8"));
        //                String errorText = reader.ReadToEnd();
        //                // log errorText
        //            }
        //            throw;
        //        }
        //    }
        //}

        //baraye select bar asase serial cpu

        public async Task<string> GET(string url, string id)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var values = new Dictionary<string, string>
                        {
                            { "id", id }
                        };

                    var content = new FormUrlEncodedContent(values);

                    var response = await client.PostAsync(url, content);

                    var responseString = await response.Content.ReadAsStringAsync();
                    return responseString;
                }
            }
            catch (WebException ex)
            {
                string asd = ex.ToString();
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                try
                {
                    WebResponse response = request.GetResponse();
                    using (Stream responseStream = response.GetResponseStream())
                    {
                        StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                        return reader.ReadToEnd();
                    }
                }
                catch (WebException exx)
                {
                    WebResponse errorResponse = exx.Response;
                    using (Stream responseStream = errorResponse.GetResponseStream())
                    {
                        StreamReader reader = new StreamReader(responseStream, Encoding.GetEncoding("utf-8"));
                        String errorText = reader.ReadToEnd();
                        // log errorText
                    }
                    throw;
                }
            }
        }
        public async Task<string> GET(string url, string name, string id)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var values = new Dictionary<string, string>
                        {
                            { "name", name },
                            { "id", id }
                        };

                    var content = new FormUrlEncodedContent(values);

                    var response = await client.PostAsync(url, content);

                    var responseString = await response.Content.ReadAsStringAsync();
                    return responseString;
                }
            }
            catch (WebException ex)
            {
                string exep = ex.ToString();
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                try
                {
                    WebResponse response = request.GetResponse();
                    using (Stream responseStream = response.GetResponseStream())
                    {
                        StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                        return reader.ReadToEnd();
                    }
                }
                catch (WebException exx)
                {
                    WebResponse errorResponse = exx.Response;
                    using (Stream responseStream = errorResponse.GetResponseStream())
                    {
                        StreamReader reader = new StreamReader(responseStream, Encoding.GetEncoding("utf-8"));
                        String errorText = reader.ReadToEnd();
                        // log errorText
                    }
                    throw;
                }
            }
        }

        public async Task<string> GET(string url, string managename, string phone, string token)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var values = new Dictionary<string, string>
                        {
                            { "Managename", managename },
                            { "Phone", phone },
                            { "Token", token }
                        };

                    var content = new FormUrlEncodedContent(values);

                    var response = await client.PostAsync(url, content);

                    var responseString = await response.Content.ReadAsStringAsync();
                    return responseString;
                }
            }
            catch (WebException ex)
            {
                string exep = ex.ToString();
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                try
                {
                    WebResponse response = request.GetResponse();
                    using (Stream responseStream = response.GetResponseStream())
                    {
                        StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                        return reader.ReadToEnd();
                    }
                }
                catch (WebException exx)
                {
                    WebResponse errorResponse = exx.Response;
                    using (Stream responseStream = errorResponse.GetResponseStream())
                    {
                        StreamReader reader = new StreamReader(responseStream, Encoding.GetEncoding("utf-8"));
                        String errorText = reader.ReadToEnd();
                        // log errorText
                    }
                    throw;
                }
            }
        }

        public async Task<string> GET(string url, string Name, string familly, string code, string trans)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var values = new Dictionary<string, string>
                        {
                            { "Name", Name },
                            { "familly", familly },
                            { "code", code },
                            { "trans", trans }
                        };

                    var content = new FormUrlEncodedContent(values);

                    var response = await client.PostAsync(url, content);

                    var responseString = await response.Content.ReadAsStringAsync();
                    return responseString;
                }
            }
            catch (WebException ex)
            {
                string exep = ex.ToString();
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                try
                {
                    WebResponse response = request.GetResponse();
                    using (Stream responseStream = response.GetResponseStream())
                    {
                        StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                        return reader.ReadToEnd();
                    }
                }
                catch (WebException exx)
                {
                    WebResponse errorResponse = exx.Response;
                    using (Stream responseStream = errorResponse.GetResponseStream())
                    {
                        StreamReader reader = new StreamReader(responseStream, Encoding.GetEncoding("utf-8"));
                        String errorText = reader.ReadToEnd();
                        // log errorText
                    }
                    throw;
                }
            }
        }
        public async Task<string> GET(string url, string application, string managename, string serial, string cammersialname, string state, string trans, string phone, string tel, string email, string address, string Reagent)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var values = new Dictionary<string, string>
                        {
                            { "Application", application },
                            { "Managename", managename },
                            { "Serial", serial },
                            { "Cammersialname", cammersialname },
                            { "State", state },
                            {"trans",trans },
                            { "Phone", phone },
                            { "Tel", tel },
                            { "Email", email },
                            { "Address", address },
                            { "Reagent", Reagent }
                        };

                    var content = new FormUrlEncodedContent(values);

                    var response = await client.PostAsync(url, content);

                    var responseString = await response.Content.ReadAsStringAsync();
                    return responseString;
                }
            }
            catch (WebException ex)
            {
                string exep = ex.ToString();
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                try
                {
                    WebResponse response = request.GetResponse();
                    using (Stream responseStream = response.GetResponseStream())
                    {
                        StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                        return reader.ReadToEnd();
                    }
                }
                catch (WebException exx)
                {
                    WebResponse errorResponse = exx.Response;
                    using (Stream responseStream = errorResponse.GetResponseStream())
                    {
                        StreamReader reader = new StreamReader(responseStream, Encoding.GetEncoding("utf-8"));
                        String errorText = reader.ReadToEnd();
                        // log errorText
                    }
                    throw;
                }
            }
        }
        public static string Request(string Url, string filter1)
        {
            try
            {
                string strReq;
                string strData;
                Stream dataStream;
                StreamReader reader;
                WebRequest request;
                WebResponse response;
                strReq = Url + filter1;

                request = WebRequest.Create(strReq);
                response = request.GetResponse();
                dataStream = response.GetResponseStream();
                reader = new StreamReader(dataStream);
                strData = reader.ReadToEnd();
                //MessageBox.Show(strData);
                reader.Close();
                response.Close();
                return strData;
            }
            catch (Exception)
            {
                return "1";
            }

        }
        public async Task<string> GET(string url, string application, string managename, string serial, string cammersialname, string state, string trans, string phone, string tel, string email)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var values = new Dictionary<string, string>
                        {
                            { "transFormId", application.ToString() },
                            { "transSaveId", managename.ToString() },
                            { "transPrice", serial.ToString() },
                            { "transModuleId", cammersialname.ToString() },
                            { "transAu", state },
                            {"transGatewayAu",trans },
                            { "transIp", phone },
                            { "transDate", tel },
                            { "transStatus", email },
                        };

                    var content = new FormUrlEncodedContent(values);

                    var response = await client.PostAsync(url, content);

                    var responseString = await response.Content.ReadAsStringAsync();
                    return responseString;
                }
            }
            catch (WebException ex)
            {
                string exep = ex.ToString();
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                try
                {
                    WebResponse response = request.GetResponse();
                    using (Stream responseStream = response.GetResponseStream())
                    {
                        StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                        return reader.ReadToEnd();
                    }
                }
                catch (WebException exx)
                {
                    WebResponse errorResponse = exx.Response;
                    using (Stream responseStream = errorResponse.GetResponseStream())
                    {
                        StreamReader reader = new StreamReader(responseStream, Encoding.GetEncoding("utf-8"));
                        String errorText = reader.ReadToEnd();
                        // log errorText
                    }
                    throw;
                }
            }
        }
    }
}
