namespace Disc
{
    public static class Constants
    {
        // URL of REST service
        //public static string RestUrl = "https://discuit.net/api/posts/{0}";

        // URL of REST service (Android does not use localhost)
        // Use http cleartext for local deployment. Change to https for production
        public static string HostUrl = DeviceInfo.Platform == DevicePlatform.Android ? "140.82.49.253" : "discuit.net";
        public static string Scheme = "https"; // or http
        //public static string Port = "";
        //public static string RestUrl = $"{Scheme}://{HostUrl}:{Port}/api/posts/{{0}}";
        //removed port
        public static string RestUrl = $"{Scheme}://{HostUrl}/api/posts/{{0}}";
    }
}