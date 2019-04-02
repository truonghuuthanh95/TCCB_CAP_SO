using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using TCCB_QuanLy.Models.DAO;

namespace TCCB_QuanLy.Utils
{
    public class ExportExcel
    {
        public static Task GenerateXLSThuyenChuyen(List<ThuyenChuyen> thuyenChuyens, string filepath, string status)
        {
            return Task.Run(() =>
            {
                using (ExcelPackage pck = new ExcelPackage())
                {
                    //Create the worksheet 
                    ExcelWorksheet ws = pck.Workbook.Worksheets.Add("ThuyenChuyen");
                    ws.Cells[2, 1].Value = "DANH SÁCH THUYÊN CHUYỂN " + status.ToUpper();
                    ws.Cells["A2:N2"].Merge = true;
                    ws.Cells[7, 1].Value = "STT";
                    ws.Cells[7, 2].Value = "MÃ HỒ SƠ";
                    ws.Cells[6, 3].Value = "ĐƠN VỊ ĐANG CÔNG TÁC";
                    ws.Cells["C6:E6"].Merge = true;
                    ws.Cells[7, 3].Value = "TÊN TRƯỜNG";
                    ws.Cells[7, 4].Value = "CẤP TRƯỜNG";
                    ws.Cells[7, 5].Value = "MÔN DẠY";
                    ws.Cells[6, 6].Value = "ĐƠN VỊ CHUYỂN ĐẾN";
                    ws.Cells["F6:H6"].Merge = true;
                    ws.Cells[7, 6].Value = "TÊN TRƯỜNG";
                    ws.Cells[7, 7].Value = "CẤP TRƯỜNG";
                    ws.Cells[7, 8].Value = "MÔN DẠY";
                    ws.Cells[6, 9].Value = "THÔNG TIN CÁ NHÂN";
                    ws.Cells["I6:P6"].Merge = true;
                    ws.Cells[7, 9].Value = "HỌ TÊN";
                    ws.Cells[7, 10].Value = "CMND";
                    ws.Cells[7, 11].Value = "GIỚI TÍNH";
                    ws.Cells[7, 12].Value = "NĂM SINH";
                    ws.Cells[7, 13].Value = "NƠI SINH";
                    ws.Cells[7, 14].Value = "HKTT";
                    ws.Cells[7, 15].Value = "SĐT";
                    ws.Cells[7, 16].Value = "EMAIL";
                    ws.Cells[6, 17].Value = "TRÌNH ĐỘ HỌC VẤN";
                    ws.Cells["Q6:U6"].Merge = true;
                    ws.Cells[7, 17].Value = "HỆ ĐÀO TẠO";
                    ws.Cells[7, 18].Value = "NGÀNH ĐÀO TẠO";
                    ws.Cells[7, 19].Value = "HÌNH THỨC ĐÀO TẠO";
                    ws.Cells[7, 20].Value = "XẾP LOẠI TỐT NGHIỆP";
                    ws.Cells[7, 21].Value = "TRÌNH ĐỘ CÁO NHẤT";
                    ws.Cells["V6:y6"].Merge = true;
                    ws.Cells[7, 22].Value = "MÃ NGẠCH";
                    ws.Cells[7, 23].Value = "HỆ SỐ";
                    ws.Cells[7, 24].Value = "BẬC LƯƠNG";
                    ws.Cells[7, 25].Value = "MỐC NÂNG LƯƠNG";
                    for (int i = 0; i < thuyenChuyens.Count(); i++)
                    {
                        ws.Cells[i + 8, 1].Value = i + 1;
                        ws.Cells[i + 8, 2].Value = thuyenChuyens.ElementAt(i).TienTo + thuyenChuyens.ElementAt(i).Id;
                        ws.Cells[i + 8, 3].Value = thuyenChuyens.ElementAt(i).School.TenTruong;
                        ws.Cells[i + 8, 4].Value = thuyenChuyens.ElementAt(i).CapDayDVDCT;
                        ws.Cells[i + 8, 5].Value = thuyenChuyens.ElementAt(i).MonDuTuyen.Name;
                        ws.Cells[i + 8, 6].Value = thuyenChuyens.ElementAt(i).School1.TenTruong;
                        ws.Cells[i + 8, 7].Value = thuyenChuyens.ElementAt(i).CapDayDVCD;
                        ws.Cells[i + 8, 8].Value = thuyenChuyens.ElementAt(i).MonDuTuyen.Name;
                        ws.Cells[i + 8, 9].Value = thuyenChuyens.ElementAt(i).HoTen;
                        ws.Cells[i + 8, 10].Value = thuyenChuyens.ElementAt(i).CMND;
                        ws.Cells[i + 8, 11].Value = thuyenChuyens.ElementAt(i).IsMale == true? "Nam" : "Nữ";
                        ws.Cells[i + 8, 12].Value = thuyenChuyens.ElementAt(i).NamSinh.Value.ToString("dd/MM/yyyy");
                        ws.Cells[i + 8, 13].Value = thuyenChuyens.ElementAt(i).Ward.Type + " " + thuyenChuyens.ElementAt(i).Ward.Name + ", " + thuyenChuyens.ElementAt(i).Ward.District.Type + " " + thuyenChuyens.ElementAt(i).Ward.District.Name + ", " + thuyenChuyens.ElementAt(i).Ward.District.Province.Type + " " + thuyenChuyens.ElementAt(i).Ward.District.Province.Name;
                        ws.Cells[i + 8, 14].Value = thuyenChuyens.ElementAt(i).SoNhaTenDuong + ", " + thuyenChuyens.ElementAt(i).Ward1.Type + " " + thuyenChuyens.ElementAt(i).Ward1.Name + ", " + thuyenChuyens.ElementAt(i).Ward1.District.Type + " " + thuyenChuyens.ElementAt(i).Ward1.District.Name + ", " + thuyenChuyens.ElementAt(i).Ward1.District.Province.Type + " " + thuyenChuyens.ElementAt(i).Ward1.District.Province.Name;
                        ws.Cells[i + 8, 15].Value = thuyenChuyens.ElementAt(i).SDT;
                        ws.Cells[i + 8, 16].Value = thuyenChuyens.ElementAt(i).Email;
                        ws.Cells[i + 8, 17].Value = thuyenChuyens.ElementAt(i).BangTotNghiep.Name;
                        ws.Cells[i + 8, 18].Value = thuyenChuyens.ElementAt(i).ChuyenNganhDaoTao.Name;
                        ws.Cells[i + 8, 19].Value = thuyenChuyens.ElementAt(i).HinhThucDaoTao.Name;
                        ws.Cells[i + 8, 20].Value = thuyenChuyens.ElementAt(i).XepLoaiHocLuc.Name;
                        ws.Cells[i + 8, 21].Value = thuyenChuyens.ElementAt(i).TrinhDoCaoNhat.Name;
                        ws.Cells[i + 8, 22].Value = thuyenChuyens.ElementAt(i).MaNghach;
                        ws.Cells[i + 8, 23].Value = thuyenChuyens.ElementAt(i).HeSo;
                        ws.Cells[i + 8, 24].Value = thuyenChuyens.ElementAt(i).BacLuong;
                        ws.Cells[i + 8, 25].Value = thuyenChuyens.ElementAt(i).MocNangLuong.Value.ToString("dd/MM/yyyy");
                       
                    }
                       
                        using (ExcelRange rng = ws.Cells["A2:N2"])
                    {
                        rng.Style.Font.Bold = true;
                        rng.Style.Font.Size = 18;
                        rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        rng.Style.Font.Color.SetColor(Color.Blue);
                    }
                    using (ExcelRange rng = ws.Cells["A3:N3"])
                    {
                        rng.Style.Font.Bold = true;
                        rng.Style.Font.Size = 14;
                        rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        rng.Style.Font.Color.SetColor(Color.Blue);
                    }
                    using (ExcelRange rng = ws.Cells["A4:N4"])
                    {
                        rng.Style.Font.Bold = true;
                        rng.Style.Font.Size = 14;
                        rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        rng.Style.Font.Color.SetColor(Color.Blue);
                    }
                    using (ExcelRange rng = ws.Cells["A6:Y6"])
                    {
                        rng.Style.Font.Bold = true;
                        rng.Style.Fill.PatternType = ExcelFillStyle.Solid;        //Set Pattern for the background to Solid 
                        rng.Style.Fill.BackgroundColor.SetColor(Color.LightGray);  //Set color to blue 
                        rng.Style.Font.Color.SetColor(Color.Black);
                        rng.AutoFitColumns();
                    }
                    using (ExcelRange rng = ws.Cells["A7:Y7"])
                    {
                        rng.Style.Font.Bold = true;
                        rng.Style.Fill.PatternType = ExcelFillStyle.Solid;        //Set Pattern for the background to Solid 
                        rng.Style.Fill.BackgroundColor.SetColor(Color.SkyBlue);  //Set color to blue 
                        rng.Style.Font.Color.SetColor(Color.Black);
                        rng.AutoFitColumns();
                    }
                    pck.SaveAs(new FileInfo(filepath));
                }
            });
        }
        public static Task GenerateXLSThuyenChuyenNgoaiTinh(List<ThuyenChuyenNgoaiTinh> thuyenChuyens, string filepath, string status)
        {
            return Task.Run(() =>
            {
                using (ExcelPackage pck = new ExcelPackage())
                {
                    //Create the worksheet 
                    ExcelWorksheet ws = pck.Workbook.Worksheets.Add("ThuyenChuyenNgoaiTinh");
                    ws.Cells[2, 1].Value = "DANH SÁCH THUYÊN CHUYỂN " + status.ToUpper();
                    ws.Cells["A2:N2"].Merge = true;
                    ws.Cells[7, 1].Value = "STT";
                    ws.Cells[7, 2].Value = "MÃ HỒ SƠ";
                    ws.Cells[6, 3].Value = "ĐƠN VỊ ĐANG CÔNG TÁC";
                    ws.Cells["C6:F6"].Merge = true;
                    ws.Cells[7, 3].Value = "TỈNH/THÀNH PHỐ";
                    ws.Cells[7, 4].Value = "TÊN TRƯỜNG";
                    ws.Cells[7, 5].Value = "CẤP TRƯỜNG";
                    ws.Cells[7, 6].Value = "MÔN DẠY";
                    ws.Cells[6, 6].Value = "ĐƠN VỊ CHUYỂN ĐẾN";
                    ws.Cells["G6:I6"].Merge = true;
                    ws.Cells[7, 7].Value = "TÊN TRƯỜNG";
                    ws.Cells[7, 8].Value = "CẤP TRƯỜNG";
                    ws.Cells[7, 9].Value = "MÔN DẠY";
                    ws.Cells[6, 9].Value = "THÔNG TIN CÁ NHÂN";
                    ws.Cells["K6:Q6"].Merge = true;
                    ws.Cells[7, 10].Value = "HỌ TÊN";
                    ws.Cells[7, 11].Value = "CMND";
                    ws.Cells[7, 12].Value = "GIỚI TÍNH";
                    ws.Cells[7, 13].Value = "NĂM SINH";
                    ws.Cells[7, 14].Value = "NƠI SINH";
                    ws.Cells[7, 15].Value = "HKTT";
                    ws.Cells[7, 16].Value = "SĐT";
                    ws.Cells[7, 17].Value = "EMAIL";
                    ws.Cells[6, 17].Value = "TRÌNH ĐỘ HỌC VẤN";
                    ws.Cells["R6:V6"].Merge = true;
                    ws.Cells[7, 18].Value = "HỆ ĐÀO TẠO";
                    ws.Cells[7, 19].Value = "NGÀNH ĐÀO TẠO";
                    ws.Cells[7, 20].Value = "HÌNH THỨC ĐÀO TẠO";
                    ws.Cells[7, 21].Value = "XẾP LOẠI TỐT NGHIỆP";
                    ws.Cells[7, 22].Value = "TRÌNH ĐỘ CÁO NHẤT";
                    ws.Cells["W6:Z6"].Merge = true;
                    ws.Cells[7, 23].Value = "MÃ NGẠCH";
                    ws.Cells[7, 24].Value = "HỆ SỐ";
                    ws.Cells[7, 25].Value = "BẬC LƯƠNG";
                    ws.Cells[7, 26].Value = "MỐC NÂNG LƯƠNG";
                    for (int i = 0; i < thuyenChuyens.Count(); i++)
                    {
                        ws.Cells[i + 8, 1].Value = i + 1;
                        ws.Cells[i + 8, 2].Value = thuyenChuyens.ElementAt(i).TienTo + thuyenChuyens.ElementAt(i).Id;
                        ws.Cells[i + 8, 3].Value = thuyenChuyens.ElementAt(i).Province.Type + " " + thuyenChuyens.ElementAt(i).Province.Name;
                        ws.Cells[i + 8, 4].Value = thuyenChuyens.ElementAt(i).School.TenTruong;
                        ws.Cells[i + 8, 5].Value = thuyenChuyens.ElementAt(i).CapDayDVDCT;
                        ws.Cells[i + 8, 6].Value = thuyenChuyens.ElementAt(i).MonDuTuyen.Name;
                        ws.Cells[i + 8, 7].Value = thuyenChuyens.ElementAt(i).School.TenTruong;
                        ws.Cells[i + 8, 8].Value = thuyenChuyens.ElementAt(i).CapDayDVCD;
                        ws.Cells[i + 8, 9].Value = thuyenChuyens.ElementAt(i).MonDuTuyen.Name;
                        ws.Cells[i + 8, 10].Value = thuyenChuyens.ElementAt(i).HoTen;
                        ws.Cells[i + 8, 11].Value = thuyenChuyens.ElementAt(i).CMND;
                        ws.Cells[i + 8, 12].Value = thuyenChuyens.ElementAt(i).IsMale == true ? "Nam" : "Nữ";
                        ws.Cells[i + 8, 13].Value = thuyenChuyens.ElementAt(i).NamSinh.Value.ToString("dd/MM/yyyy");
                        ws.Cells[i + 8, 14].Value = thuyenChuyens.ElementAt(i).Ward.Type + " " + thuyenChuyens.ElementAt(i).Ward.Name + ", " + thuyenChuyens.ElementAt(i).Ward.District.Type + " " + thuyenChuyens.ElementAt(i).Ward.District.Name + ", " + thuyenChuyens.ElementAt(i).Ward.District.Province.Type + " " + thuyenChuyens.ElementAt(i).Ward.District.Province.Name;
                        ws.Cells[i + 8, 15].Value = thuyenChuyens.ElementAt(i).SoNhaTenDuong + ", " + thuyenChuyens.ElementAt(i).Ward1.Type + " " + thuyenChuyens.ElementAt(i).Ward1.Name + ", " + thuyenChuyens.ElementAt(i).Ward1.District.Type + " " + thuyenChuyens.ElementAt(i).Ward1.District.Name + ", " + thuyenChuyens.ElementAt(i).Ward1.District.Province.Type + " " + thuyenChuyens.ElementAt(i).Ward1.District.Province.Name;
                        ws.Cells[i + 8, 16].Value = thuyenChuyens.ElementAt(i).SDT;
                        ws.Cells[i + 8, 17].Value = thuyenChuyens.ElementAt(i).Email;
                        ws.Cells[i + 8, 18].Value = thuyenChuyens.ElementAt(i).BangTotNghiep.Name;
                        ws.Cells[i + 8, 19].Value = thuyenChuyens.ElementAt(i).ChuyenNganhDaoTao.Name;
                        ws.Cells[i + 8, 20].Value = thuyenChuyens.ElementAt(i).HinhThucDaoTao.Name;
                        ws.Cells[i + 8, 21].Value = thuyenChuyens.ElementAt(i).XepLoaiHocLuc.Name;
                        ws.Cells[i + 8, 22].Value = thuyenChuyens.ElementAt(i).TrinhDoCaoNhat.Name;
                        ws.Cells[i + 8, 23].Value = thuyenChuyens.ElementAt(i).MaNghach;
                        ws.Cells[i + 8, 24].Value = thuyenChuyens.ElementAt(i).HeSo;
                        ws.Cells[i + 8, 25].Value = thuyenChuyens.ElementAt(i).BacLuong;
                        ws.Cells[i + 8, 26].Value = thuyenChuyens.ElementAt(i).MocNangLuong.Value.ToString("dd/MM/yyyy");

                    }

                    using (ExcelRange rng = ws.Cells["A2:N2"])
                    {
                        rng.Style.Font.Bold = true;
                        rng.Style.Font.Size = 18;
                        rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        rng.Style.Font.Color.SetColor(Color.Blue);
                    }
                    using (ExcelRange rng = ws.Cells["A3:N3"])
                    {
                        rng.Style.Font.Bold = true;
                        rng.Style.Font.Size = 14;
                        rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        rng.Style.Font.Color.SetColor(Color.Blue);
                    }
                    using (ExcelRange rng = ws.Cells["A4:N4"])
                    {
                        rng.Style.Font.Bold = true;
                        rng.Style.Font.Size = 14;
                        rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        rng.Style.Font.Color.SetColor(Color.Blue);
                    }
                    using (ExcelRange rng = ws.Cells["A6:Y6"])
                    {
                        rng.Style.Font.Bold = true;
                        rng.Style.Fill.PatternType = ExcelFillStyle.Solid;        //Set Pattern for the background to Solid 
                        rng.Style.Fill.BackgroundColor.SetColor(Color.LightGray);  //Set color to blue 
                        rng.Style.Font.Color.SetColor(Color.Black);
                        rng.AutoFitColumns();
                    }
                    using (ExcelRange rng = ws.Cells["A7:Y7"])
                    {
                        rng.Style.Font.Bold = true;
                        rng.Style.Fill.PatternType = ExcelFillStyle.Solid;        //Set Pattern for the background to Solid 
                        rng.Style.Fill.BackgroundColor.SetColor(Color.SkyBlue);  //Set color to blue 
                        rng.Style.Font.Color.SetColor(Color.Black);
                        rng.AutoFitColumns();
                    }
                    pck.SaveAs(new FileInfo(filepath));
                }
            });
        }
    }
}