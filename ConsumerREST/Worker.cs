using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using WoodPelletsLib;
using System.Net.Http;

namespace ConsumerREST
{
    public class Worker
    {


        public async Task<IEnumerable<WoodPellet>> GetAllWoodPelletsAsync()
        {
            var client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("https://restwoodpellets20241021104246.azurewebsites.net/Api/woodpellets");
            IEnumerable<WoodPellet> list = await response.Content.ReadFromJsonAsync<IEnumerable<WoodPellet>>();
            return list;
        }
        public async Task DoWork()
        {
            IEnumerable<WoodPellet> woodPellets = await GetAllWoodPelletsAsync();
            foreach (var woodpellet in woodPellets)
            {
                Console.WriteLine(woodpellet.ToString());
            }
        }
    }
}
