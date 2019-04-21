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

        string serial = "cat /proc/cpuinfo | grep Serial | awk '{print $3}'".Bash().Split(';').First();


        public void OnGet()
        {


        }

        public ContentResult OnPostUpdateViewModeAsync()
        {
            var viewmode = "";

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
                            viewmode = obj.ToString();

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


                    using (MySqlCommand cmd = new MySqlCommand("updateviewmode", conn))
                    {

                        //  cmd.CommandText = "updateestablishment";

                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        conn.Open();

                        var serialno = serial;
                        cmd.Parameters.AddWithValue("@serialno", serial);
                        cmd.Parameters.AddWithValue("@viewmode", viewmode);


                        cmd.ExecuteNonQuery();
                        conn.Close();

                        return Content("success");
                    }


                }
            }
            catch (Exception ex)
            {

                var Message = $"Failed ViewMode update " + ex.Message;
                _logger.LogWarning(Message);

                return Content("failed");





            }

        }
        }
