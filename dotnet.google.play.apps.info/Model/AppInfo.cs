using System.Collections.Generic;

namespace googleplayCrawler.Model
{
    public class AppInfo
    {
        public string Name { get; set; } = string.Empty;
        public string Developer { get; set; } = string.Empty;
        public string DeveloperUrlAddress { get; set; } = string.Empty;
        public string Rate { get; set; } = string.Empty;
        public string NumberOfReviews { get; set; } = string.Empty;
        public string AgeBasedRating { get; set; } = string.Empty;
        public string AgeBasedRatingIcon { get; set; } = string.Empty;
        public string Downloads { get; set; } = string.Empty;
        public string ExactDownloads { get; set; } = string.Empty;

        public string UpdatedOn { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Version { get; set; } = string.Empty;
        public string RequiresAndroid { get; set; } = string.Empty;
        public string InAppPurchases { get; set; } = string.Empty;
        public string ReleasedOn { get; set; } = string.Empty;
        public string URL { get; set; } = string.Empty;
        public string COMName { get; set; } = string.Empty;
        public List<string> Images { get; set; } = new List<string>();
    }
}
