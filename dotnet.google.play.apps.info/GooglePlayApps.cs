using googleplayCrawler.Model;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace googleplayCrawler
{
    public class GooglePlayApps
    {
        private string _url = "https://play.google.com/store/apps/details?id=";
        private string _comName = string.Empty;
        private readonly HttpClientHandler handler;

        public GooglePlayApps(string ComName)
        {
            _comName = ComName;
            _url += _comName;
            handler = new HttpClientHandler();
            handler.UseDefaultCredentials = true;
        }

        public GooglePlayApps(string URL, bool IsUrl)
        {
            if (IsUrl)
            {
                _url = URL;
                handler = new HttpClientHandler();
                handler.UseDefaultCredentials = true;
                _comName = _url.Replace("https://play.google.com/store/apps/details?id=", string.Empty);
            }
            else
            {
                _comName = URL;
                _url += _comName;
                handler = new HttpClientHandler();
                handler.UseDefaultCredentials = true;
            }
        }


        public async Task<AppInfo> GetAppInfo()
        {
            HttpClient client = new HttpClient(handler);
            var response = await client.GetStringAsync(_url);
            AppInfo appInfo = new AppInfo();
            if (!string.IsNullOrEmpty(response))
            {
                Crawler crawler = new Crawler(response);

                appInfo.Name = crawler.GetName();
                appInfo.Developer = crawler.GetDeveloperName();
                appInfo.DeveloperUrlAddress = crawler.GetDeveloperURL();
                appInfo.Rate = crawler.GetRate();
                appInfo.NumberOfReviews = crawler.GetNumberOfReviews();
                appInfo.AgeBasedRating = crawler.GetAgeRating();
                appInfo.AgeBasedRatingIcon = crawler.GetAgeRatingImage();
                appInfo.Downloads = crawler.GetDownloadCount();
                appInfo.Images = crawler.GetImages();

                appInfo.UpdatedOn = crawler.GetUpdatedOn();

                //appInfo.Version = crawler.GetAboutAppInfo(0);
                //appInfo.UpdatedOn = crawler.GetAboutAppInfo(1);
                //appInfo.RequiresAndroid = crawler.GetAboutAppInfo(2);
                //appInfo.ExactDownloads = crawler.GetAboutAppInfo(3);
                //appInfo.ReleasedOn = crawler.GetAboutAppInfo(7);

                appInfo.COMName = _comName;
                appInfo.URL = _url;
                return appInfo;
            }
            throw new Exception("get problem");
        }


    }
}
