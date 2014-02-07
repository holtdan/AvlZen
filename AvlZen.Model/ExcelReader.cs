using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvlZen.Model
{
    public class ExcelReader
    {

        public static IList<Place> GetPlaces(string path)
        {
            var list = new List<Place>();

            using (var connection = GetExcelConnection(path))
            {
                connection.Open();
                var dt = new DataTable();
                var dataAdapter = new OleDbDataAdapter("select * from [Places$]", connection);
                dataAdapter.Fill(dt);

                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new Place
                    {
                        Code = dr[0].ToString(),
                        Name = dr[1].ToString(),
                        Link = dr[2].ToString()
                    });
                }
            }

            return list.OrderBy(p => p.Code).ToList();
        }
        public static IList<Weekly> GetDayWeeklies(string path, string dow, params string[] places )
        {
            var list = new List<Weekly>();

            using (var connection = GetExcelConnection(path))
            {
                connection.Open();
                foreach (var place in places)
                {
                    var dt = new DataTable();
                    var dataAdapter = new OleDbDataAdapter("select * from [" + place + "$]", connection);
                    dataAdapter.Fill(dt);

                    var hits = from dr in dt.Rows.Cast<DataRow>()
                               where dr.ItemArray.Count() >= 5
                               && dr[0].ToString() == dow.ToString()
                               select new Weekly
                               {
                                   PlaceCode = place,
                                   DOW = dow,
                                   Start = DateTime.Parse(dr[1].ToString()).TimeOfDay,
                                   Stop = DateTime.Parse(dr[2].ToString()).TimeOfDay,
                                   What = dr[3].ToString(),
                                   Who = dr[4].ToString()
                               };
                    list.AddRange(hits);
                }
            }

            return list;
        }
        public static void GrokExcel(string path)
        {
            using ( var connection = GetExcelConnection ( path ) )
            {
                connection.Open();
                DataTable sheets = connection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                var ds = new DataSet();

                foreach (DataRow dr in sheets.Rows)
                {
                    string sheetName = dr[2].ToString().Replace("'", "");
                    var dataAdapter = new OleDbDataAdapter("select * from [" + sheetName + "]", connection);
                    var tableName = sheetName.TrimEnd('$');

                    ds.Tables.Add(tableName);
                    dataAdapter.Fill(ds.Tables[tableName]);
                }
            }
        }
        private static OleDbConnection GetExcelConnection(string path)
        {
            if (!File.Exists(path)) throw new FileNotFoundException(path);

            return new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + ";Extended Properties='Excel 12.0 xml;HDR=YES;'");
        }
    }
}
