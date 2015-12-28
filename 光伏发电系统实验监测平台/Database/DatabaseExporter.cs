using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using Microsoft.Office.Interop.Excel;
using 光伏发电系统实验监测平台.Tool;

namespace 光伏发电系统实验监测平台.Database
{
	class DatabaseExporter
	{
		DateTime _dt;
		public DatabaseExporter(DateTime dt)
		{
			_dt = dt;
		}
		public bool Export()
		{
			try
			{
				OleDbConnection dbCon = DatabaseConnection.GetConnection();
				dbCon.Open();
				DatabaseCore dbCore = new DatabaseCore(dbCon);
				Dictionary<string, string> query = new Dictionary<string, string>();
				query.Add("Year", _dt.Year.ToString());
				query.Add("Month", _dt.Month.ToString());
				query.Add("Day", _dt.Day.ToString());
				System.Data.DataTable ivDt = dbCore.SelectData("dbo_IVTable", query);
				System.Data.DataTable weatherDt = dbCore.SelectData("dbo_WeatherTable", query);
				dbCon.Close();
				if (ivDt.Rows.Count == 0 && weatherDt.Rows.Count == 0)
					return false;
				DataView dv = ivDt.DefaultView;
				dv.Sort = "[Hour] ASC, [Minute] ASC, [Second] ASC";
				ivDt = dv.ToTable();
				dv = weatherDt.DefaultView;
				dv.Sort = "[Hour] ASC, [Minute] ASC, [Second] ASC";
				weatherDt = dv.ToTable();
				string path = System.Environment.CurrentDirectory + "\\Excel\\";
				Application excel = new Application();
				Workbooks wbks = excel.Workbooks;
				Workbook wb = wbks.Add(path + "mb.xlsx");
				int row = 2;
				foreach (DataRow dr in weatherDt.Rows)
				{
					Worksheet wsh = wb.Sheets[2];
					int col = 1;
					wsh.Cells[row, col++] = dr["Hour"] + ":" + dr["Minute"] + ":" + dr["Second"];
					wsh.Cells[row, col++] = dr["WindSpeed(m/s)"];
					wsh.Cells[row, col++] = dr["AirTemperayure"];
					wsh.Cells[row, col++] = dr["Rasiation(W/m2)"];
					wsh.Cells[row, col++] = dr["WindDirection"];
					wsh.Cells[row, col++] = dr["Humidity(%RH)"];
					string str = "[Hour] = " + dr["Hour"] + " and " + "[Minute] = " + dr["Minute"];
					DataRow[] result = ivDt.Select(str);
					if (result.Length != 0)
						wsh.Cells[row, col++] = result[0]["Component1Temperature"];
					else
						col++;

					wsh.Cells[row, col++] = dr["Component2Temperature"];
					wsh.Cells[row, col++] = dr["Component3Temperature"];
					wsh.Cells[row, col++] = dr["Component4Temperature"];
					wsh.Cells[row, col++] = dr["Component5Temperature"];
					wsh.Cells[row, col++] = dr["Component6Temperature"];

					row++;
				}
				int sheet1Row = 2;
				int sheet3Row = 2;
				foreach (DataRow dr in ivDt.Rows)
				{
					int col = 1;
					int cols = 1;
					Worksheet wsh = wb.Sheets[1];
					wsh.Cells[sheet1Row, col++] = dr["Hour"] + ":" + dr["Minute"] + ":" + dr["Second"];
					wsh.Cells[sheet1Row, col++] = dr["ComponentId"];
					wsh.Cells[sheet1Row, col++] = dr["Azimuth"];
					wsh.Cells[sheet1Row, col++] = dr["Obliquity"];
					wsh.Cells[sheet1Row, col++] = dr["OpenCircuitVoltage"];
					wsh.Cells[sheet1Row, col++] = dr["ShortCircuitCurrent"];
					wsh.Cells[sheet1Row, col++] = dr["MaxPowerVoltage"];
					wsh.Cells[sheet1Row, col++] = dr["MaxPowerCurrent"];
					wsh.Cells[sheet1Row, col++] = dr["MaxPower"];
					++sheet1Row;

					Worksheet wshs = wb.Sheets[3];
					wshs.Cells[sheet3Row, cols++] = dr["Hour"] + ":" + dr["Minute"] + ":" + dr["Second"];
					wshs.Cells[sheet3Row, cols++] = dr["ComponentId"];
					wshs.Cells[sheet3Row, cols++] = dr["Azimuth"];
					wshs.Cells[sheet3Row, cols++] = dr["Obliquity"];

					int secondCols = cols;
					foreach (double currentSeq in IVTransfer.IVStransfer((string)dr["CurrentSeq"]))
					{
						wshs.Cells[sheet3Row, cols++] = currentSeq;
					}
					++sheet3Row;
					foreach (double voltageSeq in IVTransfer.IVStransfer((string)dr["VoltageSeq"]))
					{
						wshs.Cells[sheet3Row, secondCols++] = voltageSeq;
					}
					++sheet3Row;
				}
				excel.DisplayAlerts = false;
				excel.AlertBeforeOverwriting = false;
				wb.SaveAs(path + _dt.Year + "-" + _dt.Month + "-" + _dt.Day + ".xlsx");
				wb.Close();
				wbks.Close();
				return true;
			}
			catch(Exception ee)
			{
				throw new Exception("导出异常" + ee.Message, ee);
			}
		}
	}
}
