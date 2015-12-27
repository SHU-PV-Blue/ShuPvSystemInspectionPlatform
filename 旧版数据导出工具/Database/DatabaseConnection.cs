using System;
using System.Data;
using System.Data.OleDb;

namespace 光伏发电系统实验监测平台.Database
{
	/// <summary>
	/// 数据库连接管理
	/// </summary>
	static class DatabaseConnection
	{
		/// <summary>
		/// 返回数据库连接
		/// </summary>
		/// <returns>Access数据类连接</returns>
		static public OleDbConnection GetConnection()
		{
			try
			{
				String strConn = @"Provider = Microsoft.Jet.OLEDB.4.0;
							Data Source=.\Database.mdb";
				//这里采用了低版本的access数据库格式以避免不兼容的坑
				return new OleDbConnection(strConn);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
	}
}
