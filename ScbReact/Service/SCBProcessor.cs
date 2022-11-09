using ScbReact.Models;

namespace ScbReact.Service
{
    public class SCBProcessor
    {
        public async Task<SCBModel> LoadScbTask()
        {
            string url = "https://api.scb.se/OV0104/v1/doris/sv/ssd/START/BE/BE0101/BE0101H/FoddaK";

            using (HttpResponseMessage response = await ApiHelper.ApiFetch.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    SCBModel scb = await response.Content.ReadAsAsync<SCBModel>();
                    return scb;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        } 
    }
}
