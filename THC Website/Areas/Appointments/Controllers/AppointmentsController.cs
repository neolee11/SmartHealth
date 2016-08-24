using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AP_RepoImplementation;
using Business_Logic.RepositoryContracts;
using Business_Objects.BusinessObjects;

namespace THC_Website.Areas.Appointments.Controllers
{
    public class AppointmentsController : Controller
    {
        // GET: Appointments/Appointments
        public ActionResult Index()
        {
            return View();
        }

        // GET: Appointments/Appointments
        public ActionResult Report()
        {
            return View();
        }

        // GET: Appointments/Appointments
        public ActionResult MyTest()
        {
            var testRepo = new PatientRepository();
            
            return null;
        }

        // GET: Appointments/Appointments/DoSomething
        //[HttpPost]
        public JsonResult DoSomething()
        {
            var result = new { FirstName = "John", LastName = "Smith" };

            var result1 = WebApiHelper.CallApi();
            WebApiHelper.CallApi1();

            //return Json(result, JsonRequestBehavior.AllowGet);
            return Json(result1, JsonRequestBehavior.AllowGet);
        }

        public ActionResult TestAPI()
        {
            return View();
        }



        //Copy from ordr website
        //[HttpPost]
        //public JsonResult SearchDiseaseAutocomplete(string searchTerm, int maxResults)
        //{
        //    var items = _diseaseRepository.GetDiseasesFromSearchTerm(searchTerm, "DiseaseName ASC").Where(d => d.IsRare == true || d.HasGardPage == true).ToList();
        //    var disSynList = items.ToDiseaseSynonymModel();

        //    DiseaseSynonymModel.KeyWordForComparison = searchTerm;
        //    disSynList.Sort(DiseaseSynonymModel.CompareByKeywordDistance);

        //    return Json(disSynList.Select(d => new { label = HttpUtility.HtmlDecode(d.Name), id = d.DiseaseId, hasGardPage = d.HasGardPage }), JsonRequestBehavior.AllowGet);
        //}

        //private async Task<string> InvokeWebApi(string accessToken, string apiUrl)
        //{
        //    string json = "";
        //    var httpWebRequest = (HttpWebRequest)WebRequest.Create(apiUrl);
        //    httpWebRequest.Method = "GET";
        //    httpWebRequest.Accept = "application/json";
        //    httpWebRequest.Headers.Add("Authorization", accessToken);
        //    HttpWebResponse httpResponse = null;
        //    try
        //    {
        //        httpResponse = (HttpWebResponse)(await httpWebRequest.GetResponseAsync());
        //        using (Stream responseStream = httpResponse.GetResponseStream())
        //        {
        //            if (responseStream != null) json = new StreamReader(responseStream).ReadToEnd();
        //        }
        //    }
        //    finally
        //    {
        //        if (httpResponse != null) httpResponse.Close();
        //    }
        //    return json;
        //}
    }
}



//namespace ORDRPortal.ManageDiseases
//{
//    public partial class DiseaseWebService : System.Web.UI.Page
//    {
//        private string username;
//        private string password;
//        private string webApiHostUrl;
//        private string webApiDiseaseEndPoint;
//        private IDiseaseTypeAssociationRepository _diseaseTypeAssociationRepo = new DiseaseTypeAssociationRepository();

//        //grant_type=password&username=weili.li@icfi.com&password=bXm2LztWQoXmT*t9ox%8

//        protected void Page_Load(object sender, EventArgs e)
//        {
//            username = ConfigurationManager.AppSettings["WebServiceUsername"];
//            password = ConfigurationManager.AppSettings["WebServicePassword"];
//            webApiHostUrl = ConfigurationManager.AppSettings["WebServiceHostUrl"];
//            webApiDiseaseEndPoint = ConfigurationManager.AppSettings["WebSerivceDiseaseEndPoint"];

//            if (!IsPostBack)
//            {
//                var diseaseTypes = _diseaseTypeAssociationRepo.GetAllDiseaseTypes();
//                ddlCategory.DataSource = diseaseTypes;
//                ddlCategory.DataValueField = "DiseaseTypeID";
//                ddlCategory.DataTextField = "DiseaseTypeName";
//                ddlCategory.DataBind();
//                ddlCategory.Items.Insert(0, new ListItem("All", ""));
//            }
//        }

//        protected async void btnDownload_OnClick(object sender, EventArgs e)
//        {
//            var isRareOnly = chkRareDiseases.Checked;
//            var categoryId = ddlCategory.SelectedValue;

//            var questionMarkedAdded = false;
//            var webApiUrl = webApiHostUrl + webApiDiseaseEndPoint;
//            if (!isRareOnly)
//            {
//                webApiUrl += "?rareOnly=false";
//                questionMarkedAdded = true;
//            }

//            if (!string.IsNullOrEmpty(categoryId))
//            {
//                if (!questionMarkedAdded)
//                {
//                    webApiUrl += "?";
//                    questionMarkedAdded = true;
//                }
//                webApiUrl += "categoryid=" + categoryId;
//            }

//            var json = await GetDiseaseDataAsync(webApiUrl);
//            var diseases = JsonConvert.DeserializeObject<List<DiseaseWebServiceModel>>(json);

//            SendExcel(diseases);
//        }

//        //The downloaded file is in protected view. User needs to uncheck worksheet 2 in trusted center options
//        private void SendExcel(List<DiseaseWebServiceModel> diseases)
//        {
//            MemoryStream currentStream = null;
//            try
//            {
//                currentStream = new MemoryStream();
//                ExcelWriter writer = new ExcelWriter(currentStream);
//                writer.BeginWrite();
//                writer.WriteCell(0, 0, "Disease ID");
//                writer.WriteCell(0, 1, "Disease Name");
//                writer.WriteCell(0, 2, "Has Gard Page");
//                writer.WriteCell(0, 3, "Is Rare");
//                writer.WriteCell(0, 4, "Website URL");
//                writer.WriteCell(0, 5, "Synonyms");

//                if (diseases != null && diseases.Count > 0)
//                {
//                    for (int row = 0; row < diseases.Count; row++)
//                    {
//                        var disease = diseases[row];
//                        var synonymStr = string.Join(", ", disease.Synonyms);
//                        writer.WriteCell(row + 1, 0, disease.DiseaseId);
//                        writer.WriteCell(row + 1, 1, disease.DiseaseName);
//                        writer.WriteCell(row + 1, 2, disease.HasGardPage.ToString());
//                        writer.WriteCell(row + 1, 3, disease.IsRare.ToString());
//                        writer.WriteCell(row + 1, 4, disease.WebsiteUrl);
//                        writer.WriteCell(row + 1, 5, synonymStr);
//                    }
//                }

//                writer.EndWrite();

//                currentStream.Position = 0;
//                Response.AddHeader("Content-Length", currentStream.Length.ToString());
//                Response.AddHeader("Accept-Ranges", "bytes");
//                Response.Buffer = false;
//                Response.AddHeader("Connection", "Keep-Alive");
//                Response.ContentType = "application/vnd.ms-excel";
//                Response.AddHeader("Content-Disposition", "attachment;filename=RareDiseases.xls");
//                //Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
//                //Response.AddHeader("Content-Disposition", "attachment;filename=RareDiseases.xlsx");

//                long dataToRead = currentStream.Length;
//                //Response.ContentType = "application/vnd.ms-excel";
//                byte[] buffer = new byte[10000];
//                while (dataToRead > 0)
//                {
//                    if (Response.IsClientConnected)
//                    {
//                        var length = currentStream.Read(buffer, 0, 10000);
//                        Response.OutputStream.Write(buffer, 0, length);
//                        Response.Flush();
//                        buffer = new Byte[10000];
//                        dataToRead -= length;
//                    }
//                    else
//                    {
//                        dataToRead = -1;
//                    }
//                }
//            }
//            catch (Exception ex)
//            {
//                Response.Write(ex);
//            }
//            finally
//            {

//                if (currentStream != null)
//                {
//                    currentStream.Close();
//                    currentStream.Dispose();
//                }
//            }
//        }

//        public async Task<string> GetDiseaseDataAsync(string endPointUrl)
//        {
//            var json = await GetHttpRequest(endPointUrl);
//            return json;
//        }

//        private async Task<string> GetHttpRequest(string endPointUrl)
//        {
//            string json = "";
//            OWinAccessToken token;

//            OWinAuthentication owinAuth = new OWinAuthentication(username, password);
//            try
//            {
//                token = owinAuth.GetAccessToken();
//                var headervalue = string.Format("Bearer {0}", token.access_token);
//                json = await InvokeWebApi(headervalue, endPointUrl);
//                return json;
//            }
//            catch (WebException ex)
//            {
//                json = ProcessWebException(ex);
//                return json;
//            }
//        }

//        private async Task<string> InvokeWebApi(string accessToken, string apiUrl)
//        {
//            string json = "";
//            var httpWebRequest = (HttpWebRequest)WebRequest.Create(apiUrl);
//            httpWebRequest.Method = "GET";
//            httpWebRequest.Accept = "application/json";
//            httpWebRequest.Headers.Add("Authorization", accessToken);
//            HttpWebResponse httpResponse = null;
//            try
//            {
//                httpResponse = (HttpWebResponse)(await httpWebRequest.GetResponseAsync());
//                using (Stream responseStream = httpResponse.GetResponseStream())
//                {
//                    if (responseStream != null) json = new StreamReader(responseStream).ReadToEnd();
//                }
//            }
//            finally
//            {
//                if (httpResponse != null) httpResponse.Close();
//            }
//            return json;
//        }

//        private string ProcessWebException(WebException e)
//        {
//            string strResponse = string.Empty;
//            using (HttpWebResponse response = (HttpWebResponse)e.Response)
//            {
//                using (Stream responseStream = response.GetResponseStream())
//                {
//                    using (StreamReader sr = new StreamReader(responseStream, System.Text.Encoding.ASCII))
//                    {
//                        strResponse = sr.ReadToEnd();
//                    }
//                }
//            }
//            return string.Format("Http status code={0}, error message={1}", e.Status, strResponse);
//        }

//    }
//}