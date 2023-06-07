using RestSharp;
using SerhatBilenIBB_TestApp_API.Models;
using SerhatBilenIBB_TestApp_API.Models.ibb;
using Serilog;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using System.Xml.Serialization;

namespace SerhatBilenIBB_TestApp_API.Controllers
{
    //[Authorize]
    public class IbbCronJobController : ApiController
    {
        public IHttpActionResult GetAllIsPark()
        {
            try
            {
                var client = new RestClient("https://data.ibb.gov.tr/datastore/odata3.0/f4f56e58-5210-4f17-b852-effe356a890c");
                var request = new RestRequest(Method.GET);
                var response = client.Execute(request);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var xml = new XmlSerializer(typeof(Feed));
                    string icerik = Encoding.UTF8.GetString(response.RawBytes);
                    using (TextReader reader = new StringReader(icerik))
                    {
                        Feed feed = (Feed)xml.Deserialize(reader);

                        if (feed != null && feed.Entry != null && feed.Entry.Count > 0)
                        {
                            using (Definitions def = new Definitions())
                            {
                                using (SqlConnection sqlConnection = new SqlConnection(string.Format("SERVER={0};Database={1};User Id={2};Password={3};", def.Srv, def.DBase, def.Usr, def.Pwd)))
                                {
									sqlConnection.Open();

                                    SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();

                                    SqlCommand sqlCommand = new SqlCommand();
                                    sqlCommand.Connection = sqlConnection;
                                    sqlCommand.Transaction = sqlTransaction;

                                    foreach (Entry item in feed.Entry)
                                    {
                                        sqlCommand.CommandText = "SELECT COUNT(*) FROM ISPARKLAR WITH (NOLOCK) WHERE Id = @Id";
                                        sqlCommand.Parameters.Clear();
                                        sqlCommand.Parameters.Add(new SqlParameter() { ParameterName = "@Id", SqlDbType = SqlDbType.NVarChar, Value = item.Id });

                                        int sayi = int.Parse(sqlCommand.ExecuteScalar().ToString());
                                        if (sayi == 0)
                                        {
                                            string sorgu = "INSERT INTO [dbo].[ISPARKLAR] ([park_name],[location_name],[park_type_id],[park_type_desc],[capacity_of_park],[working_time],[country_name],[longitude],[latitude],[author],[updated],[Id]) VALUES " +
                                                                                        "( @park_name, @location_name, @park_type_id, @park_type_desc, @capacity_of_park, @working_time, @country_name, @longitude, @latitude, @author, @updated, @Id)";
                                            sqlCommand.Parameters.Clear();
                                            sqlCommand.CommandText = sorgu;
                                            sqlCommand.Parameters.Add(new SqlParameter() { ParameterName = "@park_name", SqlDbType = SqlDbType.NVarChar, Value = item.Content.Properties.PARK_NAME });
                                            sqlCommand.Parameters.Add(new SqlParameter() { ParameterName = "@location_name", SqlDbType = SqlDbType.NVarChar, Value = item.Content.Properties.LOCATION_NAME });
                                            sqlCommand.Parameters.Add(new SqlParameter() { ParameterName = "@park_type_id", SqlDbType = SqlDbType.NVarChar, Value = item.Content.Properties.PARK_TYPE_ID });
                                            sqlCommand.Parameters.Add(new SqlParameter() { ParameterName = "@park_type_desc", SqlDbType = SqlDbType.NVarChar, Value = item.Content.Properties.PARK_TYPE_DESC });
                                            sqlCommand.Parameters.Add(new SqlParameter() { ParameterName = "@capacity_of_park", SqlDbType = SqlDbType.Int, Value = item.Content.Properties.CAPACITY_OF_PARK });
                                            sqlCommand.Parameters.Add(new SqlParameter() { ParameterName = "@working_time", SqlDbType = SqlDbType.NVarChar, Value = item.Content.Properties.WORKING_TIME });
                                            sqlCommand.Parameters.Add(new SqlParameter() { ParameterName = "@country_name", SqlDbType = SqlDbType.NVarChar, Value = item.Content.Properties.COUNTY_NAME });
                                            sqlCommand.Parameters.Add(new SqlParameter() { ParameterName = "@longitude", SqlDbType = SqlDbType.Decimal, Value = item.Content.Properties.LONGITUDE });
                                            sqlCommand.Parameters.Add(new SqlParameter() { ParameterName = "@latitude", SqlDbType = SqlDbType.Decimal, Value = item.Content.Properties.LATITUDE });
                                            sqlCommand.Parameters.Add(new SqlParameter() { ParameterName = "@author", SqlDbType = SqlDbType.UniqueIdentifier, Value = Guid.Empty });
                                            sqlCommand.Parameters.Add(new SqlParameter() { ParameterName = "@updated", SqlDbType = SqlDbType.DateTime, Value = item.Updated });
                                            sqlCommand.Parameters.Add(new SqlParameter() { ParameterName = "@Id", SqlDbType = SqlDbType.NVarChar, Value = item.Id });

                                            if (sqlCommand.ExecuteNonQuery() == 0)
                                            {
                                                sqlTransaction.Rollback();
                                                Log.Error("İspark Cron İşlemi Hatası => {@ispark}", item);
                                                return BadRequest();
                                            }
                                        }
                                        else
                                        {
                                            string sorgu = "UPDATE [dbo].[ISPARKLAR] SET park_name = @park_name, location_name = @location_name, park_type_id = @park_type_id, park_type_desc = @park_type_desc, capacity_of_park = @capacity_of_park, working_time = @working_time, " +
                                                "country_name = @country_name, longitude = @longitude, latitude = @latitude, author = @author, updated = @updated WHERE Id = @Id";
                                            sqlCommand.Parameters.Clear();
                                            sqlCommand.CommandText = sorgu;
                                            sqlCommand.Parameters.Add(new SqlParameter() { ParameterName = "@park_name", SqlDbType = SqlDbType.NVarChar, Value = item.Content.Properties.PARK_NAME });
                                            sqlCommand.Parameters.Add(new SqlParameter() { ParameterName = "@location_name", SqlDbType = SqlDbType.NVarChar, Value = item.Content.Properties.LOCATION_NAME });
                                            sqlCommand.Parameters.Add(new SqlParameter() { ParameterName = "@park_type_id", SqlDbType = SqlDbType.NVarChar, Value = item.Content.Properties.PARK_TYPE_ID });
                                            sqlCommand.Parameters.Add(new SqlParameter() { ParameterName = "@park_type_desc", SqlDbType = SqlDbType.NVarChar, Value = item.Content.Properties.PARK_TYPE_DESC });
                                            sqlCommand.Parameters.Add(new SqlParameter() { ParameterName = "@capacity_of_park", SqlDbType = SqlDbType.Int, Value = item.Content.Properties.CAPACITY_OF_PARK });
                                            sqlCommand.Parameters.Add(new SqlParameter() { ParameterName = "@working_time", SqlDbType = SqlDbType.NVarChar, Value = item.Content.Properties.WORKING_TIME });
                                            sqlCommand.Parameters.Add(new SqlParameter() { ParameterName = "@country_name", SqlDbType = SqlDbType.NVarChar, Value = item.Content.Properties.COUNTY_NAME });
                                            sqlCommand.Parameters.Add(new SqlParameter() { ParameterName = "@longitude", SqlDbType = SqlDbType.Decimal, Value = item.Content.Properties.LONGITUDE });
                                            sqlCommand.Parameters.Add(new SqlParameter() { ParameterName = "@latitude", SqlDbType = SqlDbType.Decimal, Value = item.Content.Properties.LATITUDE });
                                            sqlCommand.Parameters.Add(new SqlParameter() { ParameterName = "@author", SqlDbType = SqlDbType.UniqueIdentifier, Value = Guid.Empty });
                                            sqlCommand.Parameters.Add(new SqlParameter() { ParameterName = "@updated", SqlDbType = SqlDbType.DateTime, Value = item.Updated });
                                            sqlCommand.Parameters.Add(new SqlParameter() { ParameterName = "@Id", SqlDbType = SqlDbType.NVarChar, Value = item.Id });

                                            if (sqlCommand.ExecuteNonQuery() == 0)
                                            {
                                                sqlTransaction.Rollback();
                                                Log.Error("İspark Cron İşlemi Hatası => {@ispark}", item);
                                                return BadRequest();
                                            }
                                        }

                                    }
                                    sqlTransaction.Commit();

                                }
                            }
                        }

                        return Json<Feed>(feed);    
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, "IBB Ispark Data Getirme işlemi Hatası => {@ex}");
            }
            return BadRequest();
        }
    }
}
