using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using Microsoft.Office.Interop.Excel;

namespace Controller
{
	public class ExcelApp
	{

		public String SaveAddress { get; set; }
		public String mPath { get; set; }
		public Application ExcellExe { get; set; }

		public ExcelApp(String Address)
		{
			ExcellExe = new Application();
			SaveAddress = Address;
		}
		public ExcelApp(String Address, String Path)
		{
			ExcellExe = new Application();
			mPath = Path;
		}
		public List<string[]> ReadExcel()
		{
			List<string[]> list = new List<string[]>();


			List<string> buff = new List<string>();
			if (File.Exists(mPath) == false) { return null; }

			Application excelApp = null;
			Workbook workBook = null;
			try
			{
				excelApp = new Application(); // 엑셀 어플리케이션 생성
				workBook = excelApp.Workbooks.Open(mPath, 0, true, 5, "", "", true, XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0); // Sheet항목들을 돌아가면서 내용을 확인 

				foreach (Worksheet workSheet in workBook.Worksheets)
				//여기서 sheet1 확인해서 적용하기
				{
					if (workSheet.Name.Equals("Sheet1"))
					{
						Range range = workSheet.UsedRange; // 사용중인 셀 범위를 가져오기 
														   // 가져온 행(row) 만큼 반복 
						for (int row = 2; row <= range.Rows.Count; row++)
						{
							string[] strArr = new string[7];
							for (int column = 1; column <= range.Columns.Count; column++)
							{
								if (column > 7) break;
								if ((range.Cells[row, column] as Range).Value2 is null && column == 1) break;


								string str;
								if ((range.Cells[row, column] as Range).Value2 is null) str = "";
								else
								{
									object obj = (range.Cells[row, column] as Range).Value2;
									if (column == 2 || column == 3)
									{
										DateTime dt;
										if (obj is double)
										{
											dt = DateTime.FromOADate((double)obj);
										}
										else
										{
											DateTime.TryParse((string)obj, out dt);
										}
										str = dt.ToString();
									}
									else
									{
										str = obj.ToString(); // 셀 데이터 가져옴 

									}
								}
								strArr[column - 1] = str;
							}
							list.Add(strArr);
						}
					}
					object missing = Type.Missing;
					object noSave = false;
					workBook.Close(noSave, missing, missing); // 엑셀 웨크북 종료
					excelApp.Quit(); // 엑셀 어플리케이션 종료
				}
			}
			finally { Marshal.FinalReleaseComObject(workBook); Marshal.FinalReleaseComObject(excelApp); }

			return list;
		}

		public string CreatExcelFile()
		{
			Workbook wb = ExcellExe.Workbooks.Add();
			string Msg = "";
			try
			{
				wb.SaveAs(Filename: @SaveAddress + "\\test.xlsx");

				Worksheet ws = wb.Worksheets.Item[1];

				Range rg1 = ws.Cells[1, 1]; //"수주명"
				Range rg2 = ws.Cells[1, 2]; //"작성 일자"
				Range rg3 = ws.Cells[1, 3]; //"출하예정일"
				Range rg4 = ws.Cells[1, 4]; //"고객사"
				Range rg5 = ws.Cells[1, 5]; //"고객사 담당자"
				Range rg6 = ws.Cells[1, 6]; //"비고"
				Range rg7 = ws.Cells[1, 7]; //"수주 금액"


				rg1.Value = "수주명";
				rg2.Value = "작성 일자";
				rg3.Value = "출하예정일";
				rg4.Value = "고객사";
				rg5.Value = "고객사 담당자";
				rg6.Value = "비고";
				rg7.Value = "수주 금액";

				wb.Close();
				ExcellExe.Quit();

				Marshal.FinalReleaseComObject(rg1);
				Marshal.FinalReleaseComObject(rg2);
				Marshal.FinalReleaseComObject(rg3);
				Marshal.FinalReleaseComObject(rg4);
				Marshal.FinalReleaseComObject(rg5);
				Marshal.FinalReleaseComObject(rg6);
				Marshal.FinalReleaseComObject(rg7);
				Marshal.FinalReleaseComObject(wb);
				Marshal.FinalReleaseComObject(ExcellExe);
			}
			catch
			{
				Msg = "파일이열려있습니다. 파일을 닫고 다시 작업해주세요";
			}

			return Msg;

		}

		public string SaveExcelFile(List<string[]> list)
		{
			Workbook wb = ExcellExe.Workbooks.Add();
			string Msg = "";
			try
			{
				wb.SaveAs(Filename: @SaveAddress + "\\test2.xlsx");

				Worksheet ws = wb.Worksheets.Item[1];

				Range rg1 = ws.Cells[1, 1]; //"수주명"
				Range rg2 = ws.Cells[1, 2]; //"상태"
				Range rg3 = ws.Cells[1, 3]; //"거래처"
				Range rg4 = ws.Cells[1, 4]; //"거래처 담당자"
				Range rg5 = ws.Cells[1, 5]; //"수주일자"
				Range rg6 = ws.Cells[1, 6]; //"출하 예정일"
				Range rg7 = ws.Cells[1, 7]; //"수주 금액(원)"
				Range rg8 = ws.Cells[1, 8]; //"비고"


				rg1.Value = "수주명";
				rg2.Value = "수주 상태";
				rg3.Value = "고객사";
				rg4.Value = "고객 담당자";
				rg5.Value = "수주 일자";
				rg6.Value = "출하 / 출하예정일";
				rg7.Value = "수주 액";
				rg8.Value = "비고";

				int cnt = 2;
				foreach (string[] str in list)
				{
					Range rg1Value = ws.Cells[cnt, 1];
					Range rg2Value = ws.Cells[cnt, 2];
					Range rg3Value = ws.Cells[cnt, 3];
					Range rg4Value = ws.Cells[cnt, 4];
					Range rg5Value = ws.Cells[cnt, 5];
					Range rg6Value = ws.Cells[cnt, 6];
					Range rg7Value = ws.Cells[cnt, 7];
					Range rg8Value = ws.Cells[cnt, 8];

					rg1Value.Value = str[0];
					rg2Value.Value = str[1];
					rg3Value.Value = str[2];
					rg4Value.Value = str[3];
					rg5Value.Value = str[4];
					rg6Value.Value = str[5];
					rg7Value.Value = str[6];
					rg8Value.Value = str[7];


					Marshal.FinalReleaseComObject(rg1Value);
					Marshal.FinalReleaseComObject(rg2Value);
					Marshal.FinalReleaseComObject(rg3Value);
					Marshal.FinalReleaseComObject(rg4Value);
					Marshal.FinalReleaseComObject(rg5Value);
					Marshal.FinalReleaseComObject(rg6Value);
					Marshal.FinalReleaseComObject(rg7Value);
					Marshal.FinalReleaseComObject(rg8Value);

					cnt++;
				}



				wb.Close();
				ExcellExe.Quit();

				Marshal.FinalReleaseComObject(rg1);
				Marshal.FinalReleaseComObject(rg2);
				Marshal.FinalReleaseComObject(rg3);
				Marshal.FinalReleaseComObject(rg4);
				Marshal.FinalReleaseComObject(rg5);
				Marshal.FinalReleaseComObject(rg6);
				Marshal.FinalReleaseComObject(rg7);
				Marshal.FinalReleaseComObject(rg8);
				Marshal.FinalReleaseComObject(wb);
				Marshal.FinalReleaseComObject(ExcellExe);
			}
			catch (Exception e)
			{
				e.ToString();
				Msg = "파일이열려있습니다. 파일을 닫고 다시 작업해주세요";
			}

			return Msg;

		}

	}
}
