using PlatformExcercise.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlatformExcercise.Data
{
    public class DataRepository
    {
		public static List<OpombaModel> LoadOpombe()
		{
			string sql = "select Id, Opomba, DatumOpombe from Opombe";
			return DataAccess.LoadData<OpombaModel>(sql);
		}

		public static int CreateOpomba(OpombaModel data) 
		{
			string sql = @"insert into Opombe(Id, Opomba) values(@Id, @Opomba);";

			return DataAccess.ExecuteSql(sql, data);
		}

		public static List<OpombaModel> LoadOpombaById(OpombaModel data)
		{
			string sql = "select Id, Opomba, DatumOpombe from Opombe where Id = @Id";
			return DataAccess.LoadDataWithParameters<OpombaModel>(sql, data);
		}

		public static int UpdateOpomba(OpombaModel data)
		{
			string sql = "update Opombe set Opomba = @Opomba, DatumOpombe = getdate() where Id = @Id";
			return DataAccess.ExecuteSql(sql, data);
		}
	}
}