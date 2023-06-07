using SerhatBilenIBB_TestApp_API.Models;
using SerhatBilenIBB_TestApp_API.Models.ibb;
using SerhatBilenIBB_TestApp_API.Models.IsParkDB;
using Serilog;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SerhatBilenIBB_TestApp_API.Controllers
{
    //[Authorize]
    public class IsParkController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Liste()
        {
            List<ISPARKLAR> isParklar = new List<ISPARKLAR>();
            try
            {
                using (Definitions def = new Definitions())
                {
                    using (SqlConnection sqlConnection = new SqlConnection(string.Format("SERVER={0};Database={1};User Id={2};Password={3}", def.Srv, def.DBase, def.Usr, def.Pwd)))
                    {
                        sqlConnection.Open();

                        SqlCommand sqlCommand = new SqlCommand();
                        sqlCommand.Connection = sqlConnection;

                        sqlCommand.CommandText = "SELECT * FROM ISPARKLAR WITH (NOLOCK)";

                        DataTable dataTable = new DataTable();
                        dataTable.Load(sqlCommand.ExecuteReader());

                        if (dataTable.Rows.Count > 0)
                        {
                            foreach (DataRow item in dataTable.Rows)
                            {
                                isParklar.Add(new ISPARKLAR()
                                {
                                    capacity_of_park = item.Field<int>("capacity_of_park"), //capacity_of_park
                                    country_name = item.Field<string>("country_name"),
                                    latitude = item.Field<decimal>("latitude"),
                                    location_name = item.Field<string>("location_name"),
                                    longitude = item.Field<decimal>("longitude"),
                                    park_name = item.Field<string>("park_name"),
                                    park_type_desc = item.Field<string>("park_type_desc"),
                                    park_type_id = item.Field<string>("park_type_id"),
                                    working_time = item.Field<string>("working_time"),
                                    _id = item.Field<int>("_id"),
                                    Id = item.Field<string>("Id")
                                });
                            }
                        }

                    }

                }
                return Json<List<ISPARKLAR>>(isParklar);
            }
            catch (Exception ex)
            {

            }

            return Json<List<Properties>>(new List<Properties>());
        }

        [HttpPost]
        public IHttpActionResult Detay([FromBody] RequestObj model)
        {
            ISPARKLAR isParklar = new ISPARKLAR();
            try
            {
                using (Definitions def = new Definitions())
                {
                    using (SqlConnection sqlConnection = new SqlConnection(string.Format("SERVER={0};Database={1};User Id={2};Password={3}", def.Srv, def.DBase, def.Usr, def.Pwd)))
                    {
                        sqlConnection.Open();

                        SqlCommand sqlCommand = new SqlCommand();
                        sqlCommand.Connection = sqlConnection;

                        sqlCommand.CommandText = "SELECT * FROM ISPARKLAR WITH (NOLOCK) WHERE Id = @Id";
                        sqlCommand.Parameters.Add(new SqlParameter() { ParameterName = "@Id", SqlDbType = SqlDbType.NVarChar, Value = model.uid });


                        DataTable dataTable = new DataTable();
                        dataTable.Load(sqlCommand.ExecuteReader());

                        if (dataTable.Rows.Count > 0)
                        {
                            foreach (DataRow item in dataTable.Rows)
                            {
                                isParklar = new ISPARKLAR()
                                {
                                    capacity_of_park = item.Field<int>("capacity_of_park"), //capacity_of_park
                                    country_name = item.Field<string>("country_name"),
                                    latitude = item.Field<decimal>("latitude"),
                                    location_name = item.Field<string>("location_name"),
                                    longitude = item.Field<decimal>("longitude"),
                                    park_name = item.Field<string>("park_name"),
                                    park_type_desc = item.Field<string>("park_type_desc"),
                                    park_type_id = item.Field<string>("park_type_id"),
                                    working_time = item.Field<string>("working_time"),
                                    _id = item.Field<int>("_id"),
                                    Id = item.Field<string>("Id")
                                };
                            }
                        }

                    }

                }
                return Json<ISPARKLAR>(isParklar);
            }
            catch (Exception ex)
            {

            }

            return Json<ISPARKLAR>(new ISPARKLAR());
        }

        [HttpPost]
        public IHttpActionResult Kaydet(ISPARKLAR model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Json(new
                    {
                        status = false,
                        aciklama = "Model Hatalı",
                        hatalar = string.Join("; ", ModelState.Values
                                            .SelectMany(x => x.Errors)
                                            .Select(x => x.ErrorMessage))
                    });
                }
                else
                {
                    using (Definitions def = new Definitions())
                    {
                        using (SqlConnection sqlConnection = new SqlConnection(string.Format("SERVER={0};Database={1};User Id={2};Password={3}", def.Srv, def.DBase, def.Usr, def.Pwd)))
                        {
                            sqlConnection.Open();
                            SqlCommand sqlCommand = new SqlCommand();
                            sqlCommand.Connection = sqlConnection;

                            string sorgu = string.Empty;
                            string id = model.Id;
                            if (string.IsNullOrEmpty(id))
                            {
                                id = Guid.NewGuid().ToString();
                                sorgu = "INSERT INTO [dbo].[ISPARKLAR] ([park_name],[location_name],[park_type_id],[park_type_desc],[capacity_of_park],[working_time],[country_name],[longitude],[latitude],[author],[updated],[Id]) VALUES " +
                                                                                       "( @park_name, @location_name, @park_type_id, @park_type_desc, @capacity_of_park, @working_time, @country_name, @longitude, @latitude, @author, @updated, @Id)";
                            }
                            else
                            {
                                sorgu = "UPDATE ISPARKLAR SET park_name = @park_name, location_name = @location_name,park_type_id = @park_type_id, park_type_desc = @park_type_desc, capacity_of_park = @capacity_of_park, working_time = @working_time, country_name = @country_name, longitude = @longitude, latitude = @latitude, author = @author, updated = @updated  WHERE Id = @Id";
                            }

                            sqlCommand.Parameters.Clear();
                            sqlCommand.CommandText = sorgu;
                            sqlCommand.Parameters.Add(new SqlParameter() { ParameterName = "@park_name", SqlDbType = SqlDbType.NVarChar, Value = string.IsNullOrEmpty(model.park_name) ? DBNull.Value : (object)model.park_name });
                            sqlCommand.Parameters.Add(new SqlParameter() { ParameterName = "@location_name", SqlDbType = SqlDbType.NVarChar, Value = string.IsNullOrEmpty(model.location_name) ? DBNull.Value : (object)model.location_name });
                            sqlCommand.Parameters.Add(new SqlParameter() { ParameterName = "@park_type_id", SqlDbType = SqlDbType.NVarChar, Value = string.IsNullOrEmpty(model.park_type_id) ? DBNull.Value : (object)model.park_type_id });
                            sqlCommand.Parameters.Add(new SqlParameter() { ParameterName = "@park_type_desc", SqlDbType = SqlDbType.NVarChar, Value = string.IsNullOrEmpty(model.park_type_desc) ? DBNull.Value : (object)model.park_type_desc });
                            sqlCommand.Parameters.Add(new SqlParameter() { ParameterName = "@capacity_of_park", SqlDbType = SqlDbType.Int, Value = model.capacity_of_park });
                            sqlCommand.Parameters.Add(new SqlParameter() { ParameterName = "@working_time", SqlDbType = SqlDbType.NVarChar, Value = string.IsNullOrEmpty(model.working_time) ? DBNull.Value : (object)model.working_time });
                            sqlCommand.Parameters.Add(new SqlParameter() { ParameterName = "@country_name", SqlDbType = SqlDbType.NVarChar, Value = string.IsNullOrEmpty(model.country_name) ? DBNull.Value : (object)model.country_name });
                            sqlCommand.Parameters.Add(new SqlParameter() { ParameterName = "@longitude", SqlDbType = SqlDbType.Decimal, Value = model.longitude });
                            sqlCommand.Parameters.Add(new SqlParameter() { ParameterName = "@latitude", SqlDbType = SqlDbType.Decimal, Value = model.latitude });
                            sqlCommand.Parameters.Add(new SqlParameter() { ParameterName = "@author", SqlDbType = SqlDbType.UniqueIdentifier, Value = Guid.Empty });
                            sqlCommand.Parameters.Add(new SqlParameter() { ParameterName = "@updated", SqlDbType = SqlDbType.DateTime, Value = DateTime.Now });
                            sqlCommand.Parameters.Add(new SqlParameter() { ParameterName = "@Id", SqlDbType = SqlDbType.NVarChar, Value = id });

                            if (sqlCommand.ExecuteNonQuery() > 0)
                            {

                                sqlCommand.Parameters.Clear();
                                sqlCommand.CommandText = "SELECT * FROM ISPARKLAR WITH (NOLOCK) WHERE Id = @Id";
                                sqlCommand.Parameters.Add(new SqlParameter() { ParameterName = "@Id", SqlDbType = SqlDbType.NVarChar, Value = id });


                                DataTable dataTable = new DataTable();
                                dataTable.Load(sqlCommand.ExecuteReader());
                                ISPARKLAR ispark = new ISPARKLAR();
                                if (dataTable.Rows.Count > 0)
                                {
                                    foreach (DataRow item in dataTable.Rows)
                                    {
                                        ispark = new ISPARKLAR()
                                        {
                                            capacity_of_park = item.Field<int>("capacity_of_park"), //capacity_of_park
                                            country_name = item.Field<string>("country_name"),
                                            latitude = item.Field<decimal>("latitude"),
                                            location_name = item.Field<string>("location_name"),
                                            longitude = item.Field<decimal>("longitude"),
                                            park_name = item.Field<string>("park_name"),
                                            park_type_desc = item.Field<string>("park_type_desc"),
                                            park_type_id = item.Field<string>("park_type_id"),
                                            working_time = item.Field<string>("working_time"),
                                            _id = item.Field<int>("_id"),
                                            Id = item.Field<string>("Id")
                                        };
                                    }
                                }

                                return Json(new { status = true, nesne = ispark });
                            }
                            return Json(new { status = false });

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                return Json(new { status = false, aciklama = ex.Message });
            }
            return Json(new { status = false, aciklama = "Sebebi Bilinmeyen Hata" });
        }


        [HttpPost]
        public IHttpActionResult Sil([FromBody] RequestObj model)
        {
            try
            {
                using (Definitions def = new Definitions())
                {
                    using (SqlConnection sqlConnection = new SqlConnection(string.Format("SERVER={0};Database={1};User Id={2};Password={3}", def.Srv, def.DBase, def.Usr, def.Pwd)))
                    {
                        sqlConnection.Open();

                        SqlCommand sqlCommand = new SqlCommand();
                        sqlCommand.Connection = sqlConnection;

                        sqlCommand.CommandText = "DELETE FROM ISPARKLAR WHERE Id = @Id";
                        sqlCommand.Parameters.Add(new SqlParameter() { ParameterName = "@Id", SqlDbType = SqlDbType.NVarChar, Value = model.uid });

                        //sqlCommand.CommandText = "UPDATE ISPARKLAR SET silindi = 1 WHERE Id = @Id";
                        //sqlCommand.Parameters.Add(new SqlParameter() { ParameterName = "@Id", SqlDbType = SqlDbType.NVarChar, Value = model.uid });

                        if (sqlCommand.ExecuteNonQuery() > 0)
                        {
                            return Json(new { status = true });
                        }
                        return Json(new { status = false });

                    }

                }
                return Json(new { status = false });
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
            }

            return Json(new { status = false });
        }

    }
}
