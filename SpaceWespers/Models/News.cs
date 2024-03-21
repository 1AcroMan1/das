namespace SpaceWespers.Models
{
    public class News
    {
        public string dataId { get; private set; }
        public string dataName { get; private set; }
        public string dataDescription { get; private set; }
        public string dataLoadTime { get; private set; }
        public string dataUrl { get; private set; }
        public News(string _id, string _name, string _desc, string _loadTime, string _url)
        {
            dataId = _id;
            dataName = _name;
            dataDescription = _desc;
            dataUrl = _url;
            dataLoadTime = _loadTime;
        }
    }
}
