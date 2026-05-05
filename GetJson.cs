namespace SensorAPI
{
    public class getJson
    {

        // Helper method to perform the HTTP GET request and return the response as a string

        public static async Task<string> GetJson(string url)
        {
            using HttpClient client = new HttpClient();
            return await client.GetStringAsync(url);
        }

    }
}
