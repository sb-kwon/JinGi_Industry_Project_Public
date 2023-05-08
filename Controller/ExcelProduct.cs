using System;
using System.IO;
using System.Drawing;
using System.Globalization;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Microsoft.Office.Interop.Excel;
namespace Controller
{
	public class ExcelProduct
	{
		public String SaveAddress { get; set; }
		public String mPath { get; set; }
		public Application ExcellExe { get; set; }
		public ExcelProduct(String Address)
		{
			ExcellExe = new Application();
			SaveAddress = Address;
		}
		public ExcelProduct(String Address, String Path)
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
									//f (column == 2 || column == 3)
									//
									//	DateTime dt;
									//	if (obj is double)
									//	{
									//		dt = DateTime.FromOADate((double)obj);
									//	}
									//	else
									//	{
									//		DateTime.TryParse((string)obj, out dt);
									//	}
									//	str = dt.ToString();
									//
									//lse
									//
										str = obj.ToString(); // 셀 데이터 가져옴 
									//}
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
				wb.SaveAs(Filename: @SaveAddress + "\\New_Excel.xlsx");

				Worksheet ws = wb.Worksheets.Item[1];
				

				Range rg1 = ws.Cells[1, 1]; //"품목명"
				Range rg2 = ws.Cells[1, 2]; //"단가"
				Range rg3 = ws.Cells[1, 3]; //"단위"
				Range rg4 = ws.Cells[1, 4]; //"규격"
				Range rg5 = ws.Cells[1, 5]; //"도면번호"
				Range rg6 = ws.Cells[1, 6]; //"비고"

				rg1.Value = "품목명";
				rg2.Value = "단가";
				rg3.Value = "단위";
				rg4.Value = "규격";
				rg5.Value = "도면번호";
				rg6.Value = "비고";

				wb.Close();
				ExcellExe.Quit();

				Marshal.FinalReleaseComObject(rg1);
				Marshal.FinalReleaseComObject(rg2);
				Marshal.FinalReleaseComObject(rg3);
				Marshal.FinalReleaseComObject(rg4);
				Marshal.FinalReleaseComObject(rg5);
				Marshal.FinalReleaseComObject(rg6);
				Marshal.FinalReleaseComObject(wb);
				Marshal.FinalReleaseComObject(ExcellExe);
			}
			catch
			{
				Msg = "파일이열려있습니다. 파일을 닫고 다시 작업해주세요";
			}
			return Msg;
		}
		public string SaveExcelFile1(List<string[]> list)
		{
			//Workbook wb = ExcellExe.Workbooks.Add();
			Aspose.Cells.Workbook wkb = new Aspose.Cells.Workbook();
			wkb.Save(SaveAddress);
			Aspose.Cells.Workbook workbook = wkb;
			Aspose.Cells.Worksheet worksheet = workbook.Worksheets[0];

			string Msg = "";
			try
			{
				//wb.SaveAs(Filename: SaveAddress);
				//workbook.Save(SaveAddress);

				//Worksheet ws = wb.Worksheets.Item[1];
				Aspose.Cells.Cell c00 = worksheet.Cells["A1"];
				Aspose.Cells.Cell c01 = worksheet.Cells["B1"];
				Aspose.Cells.Cell c02 = worksheet.Cells["C1"];
				Aspose.Cells.Cell c03 = worksheet.Cells["D1"];
				Aspose.Cells.Cell c04 = worksheet.Cells["E1"];
				Aspose.Cells.Cell c05 = worksheet.Cells["F1"];
				Aspose.Cells.Cell c06 = worksheet.Cells["G1"];
				Aspose.Cells.Cell c07 = worksheet.Cells["H1"];
				Aspose.Cells.Cell c08 = worksheet.Cells["I1"];
				Aspose.Cells.Cell c09 = worksheet.Cells["J1"];
				Aspose.Cells.Cell c10 = worksheet.Cells["K1"];
				Aspose.Cells.Cell c11 = worksheet.Cells["L1"];
				Aspose.Cells.Cell c12 = worksheet.Cells["M1"];

				c00.PutValue("수주명");
				c01.PutValue("작업 번호");
				c02.PutValue("품목 명");
				c03.PutValue("공정 명");
				c04.PutValue("공정 타입");
				c05.PutValue("공정 상태");
				c06.PutValue("시작 기준일");
				c07.PutValue("종료 기준일");
				c08.PutValue("거래처");
				c09.PutValue("담당자");
				c10.PutValue("작업 시작 시간");
				c11.PutValue("작업 종료 시간");
				c12.PutValue("작업자");

				workbook.Worksheets.RemoveAt("Evaluation Warning");
				worksheet.AutoFilter.Range = "A1";
				workbook.Save(SaveAddress);
				//workbook.Worksheets.RemoveAt("Evaluation Warning (1)");

				/*Range rg1 = ws.Cells[1, 1]; //"수주명"
				Range rg2 = ws.Cells[1, 2]; //"작업 번호"
				Range rg3 = ws.Cells[1, 3]; //"품목 명"
				Range rg4 = ws.Cells[1, 4]; //"공정 명"
				Range rg5 = ws.Cells[1, 5]; //"공정 타입"
				Range rg6 = ws.Cells[1, 6]; //"공정 상태"
				Range rg7 = ws.Cells[1, 7]; //"시작 기준일"
				Range rg8 = ws.Cells[1, 8]; //"종료 기준일"
				Range rg9 = ws.Cells[1, 9]; //"거래처"
				Range rg10 = ws.Cells[1, 10]; //"담당자"
				Range rg11 = ws.Cells[1, 11]; //"작업 시작 시간"
				Range rg12 = ws.Cells[1, 12]; //"작업 종료 시간"
				Range rg13 = ws.Cells[1, 13]; //"작업자"

				rg1.Value = "수주명";
				rg2.Value = "작업 번호";
				rg3.Value = "품목 명";
				rg4.Value = "공정 명";
				rg5.Value = "공정 타입";
				rg6.Value = "공정 상태";
				rg7.Value = "시작 기준일";
				rg8.Value = "종료 기준일";
				rg9.Value = "거래처";
				rg10.Value = "담당자";
				rg11.Value = "작업 시작 시간";
				rg12.Value = "작업 종료 시간";
				rg13.Value = "작업자";*/

				/*int cnt = 2;
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
					Range rg9Value = ws.Cells[cnt, 9];
					Range rg10Value = ws.Cells[cnt, 10];
					Range rg11Value = ws.Cells[cnt, 11];
					Range rg12Value = ws.Cells[cnt, 12];
					Range rg13Value = ws.Cells[cnt, 13];

					rg1Value.Value = str[0];
					rg2Value.Value = str[1];
					rg3Value.Value = str[2];
					rg4Value.Value = str[3];
					rg5Value.Value = str[4];
					rg6Value.Value = str[5];
					rg7Value.Value = str[6];
					rg8Value.Value = str[7];
					rg9Value.Value = str[8];
					rg10Value.Value = str[9];
					rg11Value.Value = str[10];
					rg12Value.Value = str[11];
					rg13Value.Value = str[12];

					Marshal.FinalReleaseComObject(rg1Value);
					Marshal.FinalReleaseComObject(rg2Value);
					Marshal.FinalReleaseComObject(rg3Value);
					Marshal.FinalReleaseComObject(rg4Value);
					Marshal.FinalReleaseComObject(rg5Value);
					Marshal.FinalReleaseComObject(rg6Value);
					Marshal.FinalReleaseComObject(rg7Value);
					Marshal.FinalReleaseComObject(rg8Value);
					Marshal.FinalReleaseComObject(rg9Value);
					Marshal.FinalReleaseComObject(rg10Value);
					Marshal.FinalReleaseComObject(rg11Value);
					Marshal.FinalReleaseComObject(rg12Value);
					Marshal.FinalReleaseComObject(rg13Value);

					cnt++;
				}*/
				/*wb.Save();
				wb.Close();*/
				//workbook.Save(SaveAddress);
				ExcellExe.Quit();

				/*Marshal.FinalReleaseComObject(rg1);
				Marshal.FinalReleaseComObject(rg2);
				Marshal.FinalReleaseComObject(rg3);
				Marshal.FinalReleaseComObject(rg4);
				Marshal.FinalReleaseComObject(rg5);
				Marshal.FinalReleaseComObject(rg6);
				Marshal.FinalReleaseComObject(rg7);
				Marshal.FinalReleaseComObject(rg8);
				Marshal.FinalReleaseComObject(rg9);
				Marshal.FinalReleaseComObject(rg10);
				Marshal.FinalReleaseComObject(rg11);
				Marshal.FinalReleaseComObject(rg12);
				Marshal.FinalReleaseComObject(rg13);
				Marshal.FinalReleaseComObject(wb);*/
				Marshal.FinalReleaseComObject(ExcellExe);
			}
			catch (Exception e)
			{
				e.ToString();
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
				wb.SaveAs(Filename: SaveAddress);
				Worksheet ws = wb.Worksheets.Item[1];

				Range rg1 = ws.Cells[1, 1]; //"작업 번호"
                Range rg2 = ws.Cells[1, 2]; //"업체명"
                Range rg3 = ws.Cells[1, 3]; //"수주명"
                Range rg4 = ws.Cells[1, 4]; //"작업내용"
                Range rg5 = ws.Cells[1, 5]; //"발주일"
                Range rg6 = ws.Cells[1, 6]; //"납기일"
                Range rg7 = ws.Cells[1, 7]; //"실납기일"
                Range rg8 = ws.Cells[1, 8]; //"외주현황"
                Range rg9 = ws.Cells[1, 9]; //"비고"
				Range rg = ws.Range[ws.Cells[1, 1], ws.Cells[1, 9]];

				rg.Font.Name = "맑은 고딕";
				rg.Font.Size = 15;
				rg.Font.Bold = true;
				rg.RowHeight = 35;
				rg.HorizontalAlignment = 3;
				rg.Interior.Color = Color.FromArgb(207, 226, 243);
				rg.AutoFilter(1, Type.Missing, XlAutoFilterOperator.xlAnd, Type.Missing, true);
				rg.Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlInsideVertical].LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;

				rg1.ColumnWidth = 15;
				rg2.ColumnWidth = 14;
				rg3.ColumnWidth = 23;
				rg4.ColumnWidth = 40;
				rg5.ColumnWidth = 12;
				rg6.ColumnWidth = 12;
				rg7.ColumnWidth = 12;
				rg8.ColumnWidth = 22;
				rg9.ColumnWidth = 15;

				rg1.Value = "NO";
                rg2.Value = "업체명";
                rg3.Value = "수주명";
                rg4.Value = "작업내용";
                rg5.Value = "발주일";
                rg6.Value = "납기일";
                rg7.Value = "실납기일";
                rg8.Value = "외주현황";
                rg9.Value = "비고";

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
                    Range rg9Value = ws.Cells[cnt, 9];
					Range rg00 = ws.Range[rg1Value, rg3Value];
					Range rg01 = ws.Range[rg5Value, rg7Value];
					Range rg02 = ws.Range[rg8Value, rg9Value];
					Range rg03 = ws.Range[rg1Value, rg9Value];

                    rg1Value.Value = str[1];
                    rg2Value.Value = str[8];
                    rg3Value.Value = str[0];
                    rg4Value.Value = str[2];
                    rg5Value.Value = Convert.ToDateTime(str[6]).ToString("MM/d (ddd)", CultureInfo.InvariantCulture);
                    rg6Value.Value = Convert.ToDateTime(str[7]).ToString("MM/d (ddd)", CultureInfo.InvariantCulture);
					if (str[11].Equals("")) rg7Value.Value = str[11];
                    else rg7Value.Value = Convert.ToDateTime(str[11]).ToString("MM/d (ddd)", CultureInfo.InvariantCulture);
					rg8Value.Value = "";
                    rg9Value.Value = str[13];
					rg03.RowHeight = 35;
					rg00.HorizontalAlignment = rg01.HorizontalAlignment =  3;
					rg02.HorizontalAlignment = rg4Value.HorizontalAlignment = 2;
					rg03.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;

					Marshal.FinalReleaseComObject(rg1Value);
                    Marshal.FinalReleaseComObject(rg2Value);
                    Marshal.FinalReleaseComObject(rg3Value);
                    Marshal.FinalReleaseComObject(rg4Value);
                    Marshal.FinalReleaseComObject(rg5Value);
                    Marshal.FinalReleaseComObject(rg6Value);
                    Marshal.FinalReleaseComObject(rg7Value);
                    Marshal.FinalReleaseComObject(rg8Value);
                    Marshal.FinalReleaseComObject(rg9Value);

                    cnt++;
                }
                wb.Save();
                wb.Close();
                //workbook.Save(SaveAddress);
                ExcellExe.Quit();

                Marshal.FinalReleaseComObject(rg1);
                Marshal.FinalReleaseComObject(rg2);
                Marshal.FinalReleaseComObject(rg3);
                Marshal.FinalReleaseComObject(rg4);
                Marshal.FinalReleaseComObject(rg5);
                Marshal.FinalReleaseComObject(rg6);
                Marshal.FinalReleaseComObject(rg7);
                Marshal.FinalReleaseComObject(rg8);
                Marshal.FinalReleaseComObject(rg9);
                Marshal.FinalReleaseComObject(wb);
                Marshal.FinalReleaseComObject(ws);
                Marshal.FinalReleaseComObject(ExcellExe);
			}
			catch (Exception e)
			{
				e.ToString();
				wb.Close();
				ExcellExe.Quit();
				Marshal.FinalReleaseComObject(ExcellExe);
				Msg = "파일이열려있습니다. 파일을 닫고 다시 작업해주세요";
			}
			return Msg;
		}
	}
}
