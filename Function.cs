using System;
using System.Collections.Generic;

using Amazon.Lambda.Core;

using Newtonsoft.Json;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]

namespace LambdaSLAPI
{
    using System.Globalization;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Text;
    using System.Text.RegularExpressions;

    using LambdaSLAPI.AlexaAPI;
    using LambdaSLAPI.AlexaAPI.Request;
    using LambdaSLAPI.AlexaAPI.Response;

    public class Function
    {
        private SkillResponse _response = null;

        private ILambdaContext _context = null;

        private String _loginToken = "";

        private const String APIURL = "http://demo.slmobile.de/demoApi/";

        public SkillResponse FunctionHandler(SkillRequest input, ILambdaContext ctx)
        {
            _context = ctx;
            try
            {
                _response = new SkillResponse
                            {
                                Response = new ResponseBody
                                           {
                                               ShouldEndSession = false
                                           },
                                Version = AlexaConstants.AlexaVersion
                            };

                //Login
                if (input.Session.Attributes != null)
                {
                    _response.SessionAttributes = input.Session.Attributes;
                    if (input.Session.Attributes.ContainsKey("token"))
                    {
                        _loginToken = input.Session.Attributes["token"]?.ToString();
                        Log($"Login Token from session is {_loginToken}");
                    }
                }
                else
                {
                    _response.SessionAttributes = new Dictionary<String, Object>();
                }

                if (String.IsNullOrEmpty(_loginToken) || input.Request.Type.Equals(AlexaConstants.LaunchRequest))
                {
                    var success = Login();
                    if (!success)
                    {
                        IOutputSpeech innerResponse = new PlainTextOutputSpeech();
                        ((PlainTextOutputSpeech)innerResponse).Text = "Da ist leider ein Fehler beim Login aufgetreten";
                        _response.Response.OutputSpeech = innerResponse;
                        return _response;
                    }
                }

                if (input.Request.Type.Equals(AlexaConstants.LaunchRequest))
                {
                    _response = ProcessLaunchRequest(_response);
                }
                else
                {
                    if (input.Request.Type.Equals(AlexaConstants.IntentRequest))
                    {
                        if (IsDialogIntentRequest(input))
                        {
                            if (!IsDialogSequenceComplete(input))
                            {
                                // delegate to Alexa until dialog is complete
                                CreateDelegateResponse();
                                return _response;
                            }
                        }

                        if (!ProcessDialogRequest(input, _response))
                        {
                            _response.Response.OutputSpeech = ProcessIntentRequest(input);
                        }
                    }
                }

                _response.SessionAttributes["token"] = _loginToken;
                return _response;
            }
            catch (Exception ex)
            {
                Log($"Error: " + ex.Message);
            }

            return null;
        }

        private SkillResponse ProcessLaunchRequest(SkillResponse response)
        {
            Log("ProcessLaunchRequest");
            IOutputSpeech innerResponse = new SsmlOutputSpeech();
            ((SsmlOutputSpeech)innerResponse).Ssml = SsmlDecorate("Herzlich willkommen bei der SelectLine API");
            response.Response.OutputSpeech = innerResponse;
            IOutputSpeech prompt = new PlainTextOutputSpeech();
            ((PlainTextOutputSpeech)prompt).Text = "Wie kann ich dir helfen?";
            response.Response.Reprompt = new Reprompt()
                                         {
                                             OutputSpeech = prompt
                                         };
            return response;
        }

        private Boolean ProcessDialogRequest(SkillRequest input, SkillResponse response)
        {
            Log("ProcessDialogRequest");
            var intentRequest = input.Request;
            Log($"Intentname: {intentRequest.Intent.Name}");
            return false;
        }

        private IOutputSpeech ProcessIntentRequest(SkillRequest input)
        {
            Log("ProcessIntentRequest");
            var intentRequest = input.Request;
            IOutputSpeech innerResponse = new PlainTextOutputSpeech();
            var speechMessage = "";
            var errorMessage = "";
            var realName = "";
            Log($"Intentname: {intentRequest?.Intent?.Name}");
            //List all slot values in logs
            if (intentRequest?.Intent?.Slots != null)
            {
                foreach (var slot in intentRequest?.Intent?.Slots)
                {
                    Log($"Slot: {slot.Key} = {slot.Value.Value}");
                }
            }

            switch (intentRequest?.Intent?.Name)
            {
                case "InfoIntent":
                    innerResponse = new SsmlOutputSpeech();
                    ((SsmlOutputSpeech)innerResponse).Ssml = SpeechAPIVersion();
                    break;
                case "ArticleIntent":
                    innerResponse = new SsmlOutputSpeech();
                    var paramArticleNumber = input.Request.Intent.Slots["articlenumber"].Value;
                    speechMessage = SpeechArtikelname(paramArticleNumber);
                    break;
                case "ArticleListIntent":
                    innerResponse = new SsmlOutputSpeech();
                    var paramCount = input.Request.Intent.Slots["number"].Value;
                    if (Int32.TryParse(paramCount, out var paramCountInt))
                    {
                        speechMessage = SpeechArticleList(paramCountInt);
                    }
                    else
                    {
                        speechMessage = SpeechArticleList(5);
                    }

                    break;
                case "StorageIntent":
                    innerResponse = new SsmlOutputSpeech();
                    paramArticleNumber = ResolveArticlenumber(
                        input.Request.Intent.Slots["articlenumber"].Value,
                        input.Request.Intent.Slots["articlename"].Value,
                        out errorMessage,
                        out realName);
                    speechMessage = String.IsNullOrEmpty(paramArticleNumber) ? errorMessage : SpeechLagerbestandByNumber(paramArticleNumber, realName);
                    break;
                case "PriceIntent":
                    innerResponse = new SsmlOutputSpeech();
                    paramArticleNumber = ResolveArticlenumber(
                        input.Request.Intent.Slots["articlenumber"].Value,
                        input.Request.Intent.Slots["customarticlename"].Value,
                        out errorMessage,
                        out realName);
                    speechMessage = String.IsNullOrEmpty(paramArticleNumber)
                                        ? errorMessage
                                        : SpeechPriceByArticleNumber(paramArticleNumber, realName, input.Request.Intent.Slots["amount"].Value);
                    break;
                case "TipsIntent":
                    innerResponse = new SsmlOutputSpeech();
                    speechMessage = "Hier ein Tipp zur SelectLine Warenwirtschaft. " + GetRandomString(Content.ListOfTips);
                    break;
                case "SLInfoIntent":
                    innerResponse = new SsmlOutputSpeech();
                    speechMessage = GetRandomString(Content.ListOfInfos);
                    break;
                case AlexaConstants.CancelIntent:
                    ((PlainTextOutputSpeech)innerResponse).Text = "Abbruch! Abbruch!";
                    _response.Response.ShouldEndSession = true;
                    break;

                case AlexaConstants.StopIntent:
                    ((PlainTextOutputSpeech)innerResponse).Text = GetRandomString(Content.ListOfBye);
                    _response.Response.ShouldEndSession = true;
                    break;

                case AlexaConstants.HelpIntent:
                    ((PlainTextOutputSpeech)innerResponse).Text =
                        "Du kannst mich nach dem Preis und Lagerbestand einzelner Artikel fragen. Oder nach etwas Interessantem zu SelectLine. Ich kann dir auch Tipps für die SelectLine Warenwirtschaft geben.";
                    break;

                default:
                    innerResponse = new SsmlOutputSpeech();
                    speechMessage = "Ich habe nichts verstanden, und erzähle dir daher was zu SelectLine. <break time='0.5s'/> " +
                                    GetRandomString(Content.ListOfInfos);
                    break;
            }

            if (!String.IsNullOrEmpty(speechMessage))
            {
                ((SsmlOutputSpeech)innerResponse).Ssml = speechMessage;
            }

            if (innerResponse.Type == AlexaConstants.SSMLSpeech)
            {
                BuildCard(intentRequest?.Intent?.Name, ((SsmlOutputSpeech)innerResponse)?.Ssml);
                ((SsmlOutputSpeech)innerResponse).Ssml = SsmlDecorate(((SsmlOutputSpeech)innerResponse)?.Ssml);
            }

            return innerResponse;
        }

        private String SpeechAPIVersion()
        {
            var apiVersion = "Leider ist ein Problem aufgetreten.";

            var result = PerformHttpRequestWithRetry("Info", out var response);
            if (!String.IsNullOrEmpty(result))
            {
                var responseBody = response.Content.ReadAsStringAsync().Result;
                var details = JsonConvert.DeserializeObject<Models.Info>(responseBody);
                apiVersion = $"Die API Version ist die {details.Version}";
            }
            else
            {
                Log($"API INFO ERROR: {response.StatusCode} ({response.ReasonPhrase})");
            }

            Log(apiVersion);
            return apiVersion;
        }

        private Boolean Login()
        {
            Log("Login");
            var token = "";
            var client = new HttpClient
                         {
                             BaseAddress = new Uri(APIURL)
                         };

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var urlParameters = "Login";

            Object bodyData = new
                              {
                                  UserName = "APIDemo",
                                  Password = "Ap1Dem0",
                                  LoginKind = "MobileApi"
                              };

            var content = new StringContent(JsonConvert.SerializeObject(bodyData), Encoding.UTF8, "application/json");

            var response = client.PostAsync(urlParameters, content).Result;
            Log($"Login with baseURL={APIURL} and urlParameters={urlParameters}");
            if (response.IsSuccessStatusCode)
            {
                var responseBody = response.Content.ReadAsStringAsync().Result;
                var details = JsonConvert.DeserializeObject<Models.Login>(responseBody);
                Log($"AccessToken: {details.AccessToken}");
                token = details.AccessToken;
            }
            else
            {
                _loginToken = token;
                Log($"API LOGIN ERROR: {response.StatusCode} ({response.ReasonPhrase})");
                return false;
            }

            _loginToken = token;
            Log($"Login ok. Token is {token}");
            return true;
        }

        private String SpeechArtikelname(String number)
        {
            var result = PerformHttpRequestWithRetry($"Articles/{number}", out var response);
            if (!String.IsNullOrEmpty(result))
            {
                var details = JsonConvert.DeserializeObject<Models.Article>(result);
                Log($"Article Name: {details.Name}");
                return details.Name;
            }
            else
            {
                Log($"API ARTICLE ERROR: {response.StatusCode} ({response.ReasonPhrase})");
            }

            return $"Leider konnte ich zu der Artikelnummer {number} nichts finden. Sorry.";
        }

        private String SpeechArticleList(Int32 count)
        {
            var returnStr = "";
            if (count > 8)
            {
                returnStr += "Das sind zu viele. Ich nenne dir 8 Artikel. <break time='0.5s'/>";
                count = 8;
            }
            else
            {
                returnStr += " Es gibt unter anderem folgende Artikel in den Demodaten.";
            }

            var result = PerformHttpRequestWithRetry($"Articles?items=125", out var response);
            if (!String.IsNullOrEmpty(result))
            {
                var details = JsonConvert.DeserializeObject<List<Models.Article>>(result);

                var runCount = details.Count < count ? details.Count : count;

                var randomList = new List<Int32>();

                var r = new Random();
                for (var i = 0; i < runCount; i++)
                {
                    var number = r.Next(0, details.Count - 1);
                    if (!randomList.Contains(number))
                    {
                        randomList.Add(number);
                    }
                    else
                    {
                        i--;
                    }
                }

                for (var i = 0; i < runCount; i++)
                {
                    if (i < randomList.Count && randomList[i] < details.Count)
                    {
                        returnStr += $" {details[randomList[i]].Name}. ";
                    }
                }

                return returnStr;
            }

            Log($"API ARTICLELIST ERROR: {response.StatusCode} ({response.ReasonPhrase})");
            return "Leider konnte ich keine Artikel finden. Sorry.";
        }

        private String SpeechLagerbestandByNumber(String number, String name)
        {
            Log($"SpeechLagerbestandByNumber number={number} name={name}");

            var result = PerformHttpRequestWithRetry($"Articles/Stock/?filter=ArticleNumber eq '{number}'", out var response);
            if (!String.IsNullOrEmpty(result))
            {
                var responseBody = response.Content.ReadAsStringAsync().Result;
                var details = JsonConvert.DeserializeObject<List<Models.Storage>>(responseBody);
                Double lagerSumme = 0;
                var einheit = "";
                foreach (var item in details)
                {
                    lagerSumme += item.Stock;
                    einheit = item.QuantityUnit;
                }

                var outputName = name;
                if (String.IsNullOrEmpty(name))
                {
                    outputName = $"Artikelnummer {number} ";
                }

                var speechMessage = $"Der Lagerbestand für {outputName} ist ";
                if (details.Count > 1)
                {
                    speechMessage += $"über alle {details.Count} Lager ";
                }

                speechMessage += $"{lagerSumme} {einheit}. ";

                return speechMessage;
            }

            Log($"API STOCK ERROR: {response.StatusCode} ({response.ReasonPhrase})");
            return $"Leider konnte ich zu der Artikelnummer {number} nichts finden. Sorry.";
        }

        private String SpeechPriceByArticleNumber(String number, String name, String amount)
        {
            Log($"SpeechPriceByArticleNumber number={number} name={name} amount={amount}");
            if (!Int32.TryParse(amount, out var amountInt))
            {
                amountInt = 1;
            }

            var result = PerformHttpRequestWithRetry($"Articles/{number}", out var response);
            if (!String.IsNullOrEmpty(result))
            {
                var details = JsonConvert.DeserializeObject<Models.Article>(result);
                Log($"Article Name: {details.Name}");
                Log($"Article Price: {details.Payment.ListPrice} - amount {amountInt} - {details.Payment.ListPrice * amountInt}");
                if (!String.IsNullOrEmpty(name))
                {
                    var priceSSML = GetCurrencySSML((details.Payment.ListPrice * amountInt).ToString(CultureInfo.InvariantCulture));
                    return $"Der Preis für {amountInt} {name} beträgt <say-as interpret-as='unit'>{priceSSML}</say-as>";
                }
                else
                {
                    return
                        $"Der Preis des Artikels mit der Nummer {number} beträgt <say-as interpret-as='unit'>{details.Payment.ListPrice}Euro</say-as>"; //Wenn nach Nummer gefragt wird dann nur ohne Amount
                }
            }
            else
            {
                Log($"API ARTICLE PRICE ERROR: {response.StatusCode} ({response.ReasonPhrase})");
            }

            return $"Leider konnte ich zu der Artikelnummer {number} nichts finden. Sorry.";
        }

        private String GetArticlenumberByName(String name, out String realName)
        {
            Log("GetArticlenumberByName");
            realName = "";

            var result = PerformHttpRequestWithRetry($"Articles?filter=Name ct '{name}'", out var response);
            if (!String.IsNullOrEmpty(result))
            {
                var responseBody = response.Content.ReadAsStringAsync().Result;
                var details = JsonConvert.DeserializeObject<List<Models.Article>>(responseBody);
                if (details.Count > 0)
                {
                    Log($"Article Name: {name},  Article Number:{details[0].Number}");
                    realName = details[0].Name;
                    return details[0].Number;
                }
            }

            Log($"No result in GetArticlenumberByName - name={name}");
            return "";
        }

        private String ResolveArticlenumber(String paramArticleNumber, String paramArticleName, out String errorMessage, out String realName)
        {
            realName = "";
            errorMessage = "";
            Log($"resolveArticlenumber - number={paramArticleNumber} name={paramArticleName}");
            if (String.IsNullOrEmpty(paramArticleNumber) || paramArticleNumber == "?")
            {
                Log("resolveArticlenumber - articlenumber is empty");
                if (!String.IsNullOrEmpty(paramArticleName))
                {
                    paramArticleNumber = GetArticlenumberByName(paramArticleName, out realName);
                    Log($"tried to get article number by name - result: {paramArticleNumber}");
                    if (String.IsNullOrEmpty(paramArticleNumber) || paramArticleNumber == "?")
                    {
                        errorMessage =
                            $"Ich konnte den Artikel  <break strength='weak'/> <prosody volume='x-loud'>{paramArticleName}</prosody> leider nicht finden.";
                        return "";
                    }
                }
                else
                {
                    Log("articleName is emtpy");
                    errorMessage = $"Leider konnte ich keinen Artikelnamen verstehen.";
                    return "";
                }
            }

            return paramArticleNumber;
        }

        //Returns Response Body or EmptyString
        private String PerformHttpRequest(String urlParameters, out HttpResponseMessage response)
        {
            var client = new HttpClient
                         {
                             BaseAddress = new Uri(APIURL)
                         };
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("Authorization", $"LoginId {_loginToken}");

            response = client.GetAsync(urlParameters).Result;
            if (response.IsSuccessStatusCode)
            {
                return response.Content.ReadAsStringAsync().Result;
            }
            else
            {
                Log(
                    $"PerformHttpRequest failed: URL={APIURL} urlParameters={urlParameters} token={_loginToken} {response.StatusCode} ({response.ReasonPhrase})");
                if (response.StatusCode == System.Net.HttpStatusCode.Forbidden)
                {
                    return System.Net.HttpStatusCode.Forbidden.ToString();
                }
            }

            return "";
        }

        private String PerformHttpRequestWithRetry(String urlParameters, out HttpResponseMessage response)
        {
            var result = PerformHttpRequest(urlParameters, out response);
            //Retry if forbidden with new login
            if (result == System.Net.HttpStatusCode.Forbidden.ToString())
            {
                Login();
                result = PerformHttpRequest(urlParameters, out response);
            }

            return result;
        }

        private void BuildCard(String title, String output)
        {
            if (!String.IsNullOrEmpty(output))
            {
                output = Regex.Replace(output, @"<.*?>", "");
                _response.Response.Card = new SimpleCard()
                                          {
                                              Title = title,
                                              Content = output,
                                          };
            }
        }

        private void CreateDelegateResponse()
        {
            var dld = new DialogDirective()
                      {
                          Type = AlexaConstants.DialogDelegate
                      };
            _response.Response.Directives.Add(dld);
        }

        private Boolean IsDialogIntentRequest(SkillRequest input)
        {
            return !String.IsNullOrEmpty(input.Request.DialogState);
        }

        private Boolean IsDialogSequenceComplete(SkillRequest input)
        {
            if (input.Request.DialogState.Equals(AlexaConstants.DialogStarted) || input.Request.DialogState.Equals(AlexaConstants.DialogInProgress))
            {
                return false;
            }
            else
            {
                if (input.Request.DialogState.Equals(AlexaConstants.DialogCompleted))
                {
                    return true;
                }
            }

            return false;
        }

        private String SsmlDecorate(String speech)
        {
            return "<speak>" + speech + "</speak>";
        }

        private void Log(String text)
        {
            _context?.Logger.LogLine($"XX: {text}");
        }

        private String GetRandomString(List<String> listOfStrings)
        {
            if (listOfStrings?.Count > 0)
            {
                var r = new Random();
                var number = r.Next(0, listOfStrings.Count);
                return listOfStrings[number];
            }

            return "";
        }

        private String GetCurrencySSML(String text)
        {
            var split = text.Split('.', 2);
            var result = "";
            result += split[0];
            result += " Euro ";
            if (split.Length > 1)
            {
                result += split[1];
                if (split[1].Length == 1)
                {
                    result += "0";
                }
            }

            return result;
        }
    }
}