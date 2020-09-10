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
			string sql = @"select Id, Opomba, DatumOpombe from Opombe";
			return DataAccess.LoadData<OpombaModel>(sql);
		}
	}
}