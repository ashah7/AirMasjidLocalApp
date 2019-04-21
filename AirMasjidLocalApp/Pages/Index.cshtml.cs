using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;

namespace AirMasjidLocalApp.Pages
{

    [IgnoreAntiforgeryToken]


    public class IndexModel : PageModel
    {

        private readonly ILogger _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;


        }

        // string serial = "cat /proc/cpuinfo | grep Serial | awk '{print $3}'".Bash().Split(';').First();

        string serial = "00000000d86d6b5c";

        public void OnGet()
        {


        }

        public ContentResult OnPostGetUserPreferencesAsync()
        {
           
            
            var autoscreen = "";
            var tahajjud = "";
            int? establishid=null;
            int? events=null;
            int? viewmode=null;
            var estdescription = "";
            var tweetid = "";
            var audiourl = "";
            var videourl = "";






            {
                MemoryStream stream = new MemoryStream();
                Request.Body.CopyTo(stream);
                stream.Position = 0;
                using (StreamReader reader = new StreamReader(stream))
                {
                    string requestBody = reader.ReadToEnd();
                    if (requestBody.Length > 0)
                    {
                        var obj = JsonConvert.DeserializeObject(requestBody);
                        if (obj != null)
                        {
                            //viewmode = obj.ToString();

                        }
                    }
                }
            }


            IConfigurationRoot configuration = new ConfigurationBuilder()
          .SetBasePath(Directory.GetCurrentDirectory())
          .AddJsonFile("appsettings.json")
          .Build();
            var connectionString = configuration.GetConnectionString("DefaultConnection");


            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    using (MySqlCommand cmd = new MySqlCommand("getuserpreferences", conn))
                    {

                        //  cmd.CommandText = "updateestablishment";

                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        conn.Open();

                        var serialno = serial;
                        cmd.Parameters.AddWithValue("@serialno", serial);


                        MySql.Data.MySqlClient.MySqlDataReader myReader = default(MySql.Data.MySqlClient.MySqlDataReader);

                        myReader = cmd.ExecuteReader();

                        while (myReader.Read())
                        {

                            autoscreen = myReader.GetString(0);
                            tahajjud = myReader.GetString(1);
                            establishid = myReader.GetInt16(2);
                            events = myReader.GetInt16(3);
                            viewmode = myReader.GetInt16(4);
                            estdescription = myReader.GetString(5);
                            tweetid = myReader.GetString(6);
                            audiourl = myReader.GetString(7);
                            videourl = myReader.GetString(8);
                            
                            //  establishid = myReader.GetString(2);


                        }

                            // cmd.ExecuteNonQuery();
                            conn.Close();

                      //  return Content(autoscreen,tahajjud);

                        return Content("{ " +
                            "\"autoscreen\":"+"\""+autoscreen+"\""+ 
                            ",\"tahajjud\":" + "\"" + tahajjud + "\"" + 
                            ",\"establishid\":" + establishid + 
                            ",\"events\":" + events + 
                            ",\"viewmode\":" + viewmode + 
                            ",\"estdescription\":" + "\"" + estdescription + "\"" +
                            ",\"tweetid\":" + "\"" + tweetid + "\"" +
                            ",\"audiourl\":" + "\"" + audiourl + "\"" +
                            ",\"videourl\":" + "\"" + videourl + "\"" +
                            "}", "application/json");

                        //  return Content("{ \"name\":\"John\", \"age\":31, \"city\":\"New York\" }", "application/json");




                    }
                }
            }
            catch (Exception ex)
            {
                var Message = $"Failed to get user preferences " + ex.Message;
                _logger.LogWarning(Message);

                return Content("failed");
                
            }

        }
    }
}
        
