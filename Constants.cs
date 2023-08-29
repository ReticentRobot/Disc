namespace Disc
{
    public static class Constants
    {
        // URL of REST service
        public static string HostUrl = "discuit.net";
        public static string Scheme = "https"; // or http
        public static string RestUrl = $"{Scheme}://{HostUrl}/api";

        // # of Posts to grab at once
        public static int PageSize = 20;
    }
}