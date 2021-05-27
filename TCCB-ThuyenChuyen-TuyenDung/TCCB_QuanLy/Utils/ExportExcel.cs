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
        public static Task GenerateXLSThuyenChuyen(List<ThuyenChuyen2020> thuyenChuyens, string filepath, string status)
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
                        if (thuyenChuyens.ElementAt(i).Province.Id != 79)
                        {
                            ws.Cells[i + 8, 3].Value = thuyenChuyens.ElementAt(i).DVDCTTenTruong;
                        }
                        else
                        {
                            ws.Cells[i + 8, 3].Value = thuyenChuyens.ElementAt(i).School1.TenTruong;
                        }
                        
                        ws.Cells[i + 8, 4].Value = thuyenChuyens.ElementAt(i).CapDayDVDCT;
                        ws.Cells[i + 8, 5].Value = thuyenChuyens.ElementAt(i).MonDuTuyen.Name;
                        if (thuyenChuyens.ElementAt(i).Province1.Id != 79)
                        {
                            ws.Cells[i + 8, 3].Value = thuyenChuyens.ElementAt(i).DVCDTenTruong;
                        }
                        else
                        {
                            ws.Cells[i + 8, 6].Value = thuyenChuyens.ElementAt(i).School.TenTruong;
                        }
                        
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
        public static Task GenerateXLSRegistrationCompleted(List<TuyenDung2021> registrationInterviews, string filePath)
        {
            return Task.Run(() =>
            {
                using (ExcelPackage pck = new ExcelPackage())
                {
                    //Create the worksheet 
                    ExcelWorksheet ws = pck.Workbook.Worksheets.Add(DateTime.Now.Date.ToString());
                    ws.Cells[2, 1].Value = "DANH SÁCH ỨNG VIÊN";
                    ws.Cells["A2:I2"].Merge = true;

                    
                    ws.Cells["A3:I3"].Merge = true;
                    ws.Cells[4, 1].Value = "Tính tới ngày " + DateTime.Now.ToString("dd/MM/yyyy");
                    ws.Cells["A4:I4"].Merge = true;
                    ws.Cells[6, 1].Value = "MÃ";
                    ws.Cells[6, 2].Value = "MÔN ĐĂNG KÍ";
                    //THONG TIN CA NHAN
                    ws.Cells[6, 3].Value = "HỌ VÀ TÊN";                    
                    ws.Cells[6, 4].Value = "NGÀY SINH";
                    ws.Cells[6, 5].Value = "GIỚI TÍNH";
                    ws.Cells[6, 6].Value = "DÂN TỘC";
                    ws.Cells[6, 7].Value = "TÔN GIÁO";
                    ws.Cells[6, 8].Value = "SỐ CMND/CCCD";
                    ws.Cells[6, 9].Value = "NGÀY CẤP";
                    ws.Cells[6, 10].Value = "NƠI CẤP";
                    ws.Cells[6, 11].Value = "SĐT";
                    ws.Cells[6, 12].Value = "EMAIL";                
                    ws.Cells[6, 13].Value = "QUÊ QUÁN";
                    ws.Cells[6, 14].Value = "NƠI Ở HIỆN NAY";
                    ws.Cells[6, 15].Value = "HÔ KHẨU THƯỜNG TRÚ";
                    ws.Cells[6, 16].Value = "TÌNH TRẠNG SỨC KHỎE";
                    ws.Cells[6, 17].Value = "CHIỀU CAO (cm)";
                    ws.Cells[6, 18].Value = "CÂN NẶNG (kg)";
                    ws.Cells[6, 19].Value = "THÀNH PHẦN BẢN THÂN HIỆN TẠI";
                    //BANG DAI HOC
                    ws.Cells[6, 20].Value = "TỐT NGHIỆP";
                    ws.Cells[6, 21].Value = "CHUYÊN NGHÀNH ĐÀO TẠO";
                    ws.Cells[6, 22].Value = "HỆ";
                    ws.Cells[6, 23].Value = "TÊN TRƯỜNG";
                    ws.Cells[6, 24].Value = "TRƯỜNG NÀY Ở";
                    ws.Cells[6, 25].Value = "PHƯƠNG THỨC ĐÀO TẠO";
                    ws.Cells[6, 26].Value = "NĂM TỐT NGHIỆP";                   
                    ws.Cells[6, 27].Value = "ĐIỂM TB";
                    ws.Cells[6, 28].Value = "ĐIỂM ĐỒ ÁN";
                    ws.Cells[6, 29].Value = "XẾP LOẠI";
                    ws.Cells[6, 30].Value = "SỐ HIỆU VĂN BẰNG";
                    //CHUNG CHI KHÁC
                    ws.Cells[6, 31].Value = "CHỨNG CHỈ";                    
                    ws.Cells[6, 32].Value = "SỐ HIỆU VĂN BẰNG";       
                    //TIN HOC
                    ws.Cells[6, 33].Value = "TIN HỌC";
                    ws.Cells[6, 34].Value = "SỐ HIỆU VĂN BẰNG";
                    //NGOAI NGHU
                    ws.Cells[6, 35].Value = "NGOẠI NGỮ";
                    ws.Cells[6, 36].Value = "SỐ HIỆU VĂN BẰNG";
                    //NGOAI NGU KHAC
                    ws.Cells[6, 37].Value = "NGOẠI NGỮ KHÁC";
                    ws.Cells[6, 38].Value = "SỐ HIỆU VĂN BẰNG";
                    //THONG TIN KHAC
                    ws.Cells[6, 39].Value = "ĐỐI TƯỢNG ƯU TIÊN";
                    //ws.Cells[6, 40].Value = "TRƯỜNG HỢP ĐẶC BIỆT";
                    //NGUYEN VONG
                    ws.Cells[6, 40].Value = "TRƯỜNG DỰ TUYỂN";
                   
                    ws.Cells[6, 41].Value = "TRÌNH DỘ CAO NHẤT";
                    ws.Cells[6, 42].Value = "TRẠNG THÁI";
                    for (int i = 0; i < registrationInterviews.Count(); i++)
                    {
                        ws.Cells[i + 7, 1].Value = registrationInterviews.ElementAt(i).TienTo + registrationInterviews.ElementAt(i).Id;
                        ws.Cells[i + 7, 2].Value = registrationInterviews.ElementAt(i).MonDuTuyen.Name;
                        //THONG TIN CA NHAN
                        ws.Cells[i + 7, 3].Value = registrationInterviews.ElementAt(i).LastName + " " + registrationInterviews.ElementAt(i).FirstName;
                        ws.Cells[i + 7, 4].Value = registrationInterviews.ElementAt(i).DOB.Value.ToString("dd/MM/yyyy");                        
                        ws.Cells[i + 7, 5].Value = registrationInterviews.ElementAt(i).IsMale == true ? "Nam" : "Nữ";
                        ws.Cells[i + 7, 6].Value = registrationInterviews.ElementAt(i).DanToc.Name;
                        ws.Cells[i + 7, 7].Value = registrationInterviews.ElementAt(i).TonGiao.Name;
                        ws.Cells[i + 7, 8].Value = registrationInterviews.ElementAt(i).IdentifyCard;
                        ws.Cells[i + 7, 9].Value = registrationInterviews.ElementAt(i).CMNDNgayCap.Value.ToString("dd/MM/yyyy");
                        ws.Cells[i + 7, 10].Value = registrationInterviews.ElementAt(i).Province1.Type + " " + registrationInterviews.ElementAt(i).Province1.Name;
                        ws.Cells[i + 7, 11].Value = registrationInterviews.ElementAt(i).SDT;
                        ws.Cells[i + 7, 12].Value = registrationInterviews.ElementAt(i).Email;
                        ws.Cells[i + 7, 13].Value = registrationInterviews.ElementAt(i).Province2.Type + " " + registrationInterviews.ElementAt(i).Province2.Name;
                        ws.Cells[i + 7, 14].Value = registrationInterviews.ElementAt(i).HKTTSoNhaTenDuong + ", " + registrationInterviews.ElementAt(i).Ward.Type + " " + registrationInterviews.ElementAt(i).Ward.Name + ", " + registrationInterviews.ElementAt(i).Ward.District.Type + " " + registrationInterviews.ElementAt(i).Ward.District.Name + ", " + registrationInterviews.ElementAt(i).Ward.District.Province. Type + " " + registrationInterviews.ElementAt(i).Ward.District.Province.Name;
                        ws.Cells[i + 7, 15].Value = registrationInterviews.ElementAt(i).HKTTSoNhaTenDuong + ", " + registrationInterviews.ElementAt(i).Ward1.Type + " " + registrationInterviews.ElementAt(i).Ward1.Name + ", " + registrationInterviews.ElementAt(i).Ward1.District.Type + " " + registrationInterviews.ElementAt(i).Ward1.District.Name + ", " + registrationInterviews.ElementAt(i).Ward1.District.Province.Type + " " + registrationInterviews.ElementAt(i).Ward1.District.Province.Name;
                        ws.Cells[i + 7, 16].Value = registrationInterviews.ElementAt(i).TinhTrangSucKhoe;
                        ws.Cells[i + 7, 17].Value = registrationInterviews.ElementAt(i).Chieucao;
                        ws.Cells[i + 7, 18].Value = registrationInterviews.ElementAt(i).CanNang;
                        ws.Cells[i + 7, 19].Value = registrationInterviews.ElementAt(i).ThanhPhanBanThanHienTai.Name;
                        //TRINH DO DAI HOC
                        ws.Cells[i + 7, 20].Value = registrationInterviews.ElementAt(i).BangTotNghiep.Name;
                        ws.Cells[i + 7, 21].Value = registrationInterviews.ElementAt(i).ChuyenNganhDaoTao.Name;
                        ws.Cells[i + 7, 22].Value = registrationInterviews.ElementAt(i).HinhThucDaoTao.Name;
                        ws.Cells[i + 7, 23].Value = registrationInterviews.ElementAt(i).TenTruongDaiHoc;
                        ws.Cells[i + 7, 24].Value = registrationInterviews.ElementAt(i).Province.Type + " " + registrationInterviews.ElementAt(i).Province.Name;
                        ws.Cells[i + 7, 25].Value = registrationInterviews.ElementAt(i).IsNienChe == true ? "Niên chế" : "Tín chỉ";
                        ws.Cells[i + 7, 26].Value = registrationInterviews.ElementAt(i).NamTotNghiep;
                        ws.Cells[i + 7, 27].Value = registrationInterviews.ElementAt(i).GPA;
                        ws.Cells[i + 7, 28].Value = registrationInterviews.ElementAt(i).DiemLuanVan;
                        ws.Cells[i + 7, 29].Value = registrationInterviews.ElementAt(i).XepLoaiHocLuc.Name;
                        ws.Cells[i + 7, 30].Value = registrationInterviews.ElementAt(i).SoVanBangChungChiDaiHoc;
                        //CHUNG CHI
                        ws.Cells[i + 7, 31].Value = registrationInterviews.ElementAt(i).ChungChiNghiepVuSuPham.Name;
                        ws.Cells[i + 7, 32].Value = registrationInterviews.ElementAt(i).ChungChiNghiepVuSuPhamSoVanBang;
                        //TIN HOC
                        ws.Cells[i + 7, 33].Value = registrationInterviews.ElementAt(i).TrinhDoTinHoc.Name;
                        ws.Cells[i + 7, 34].Value = registrationInterviews.ElementAt(i).SoVanBangChungChiTinHoc;
                        //NGOAI NGU
                        ws.Cells[i + 7, 35].Value = registrationInterviews.ElementAt(i).TrinhDoNgoaiNgu.Name;
                        ws.Cells[i + 7, 36].Value = registrationInterviews.ElementAt(i).SoVanBangChungChiNgoaiNgu;
                        //NGOAI NGU KHAC
                        ws.Cells[i + 7, 37].Value = registrationInterviews.ElementAt(i).TrinhDoNgoaiNguKhac.Name;
                        ws.Cells[i + 7, 38].Value = registrationInterviews.ElementAt(i).SoVanBangChungChiNgoaiNguKhac;
                        //THONG TIN KHAC
                        ws.Cells[i + 7, 39].Value = registrationInterviews.ElementAt(i).DoiTuongUuTien1.Name;
                        //ws.Cells[i + 7, 40].Value = registrationInterviews.ElementAt(i).TruongHopDacBiet.Name;
                        //NGUYEN VONG
                        ws.Cells[i + 7, 40].Value = registrationInterviews.ElementAt(i).School.TenTruong;
                       
                        ws.Cells[i + 7, 41].Value = registrationInterviews.ElementAt(i).TrinhDoCaoNhat.Name;
                        ws.Cells[i + 7, 42].Value = registrationInterviews.ElementAt(i).TrangThaiHosoTuyenDungId == null? "Chưa trình hồ sơ" : registrationInterviews.ElementAt(i).TrangThaiHoSoTuyenDung.Name;

                    }
                    using (ExcelRange rng = ws.Cells["A2:I2"])
                    {
                        rng.Style.Font.Bold = true;
                        rng.Style.Font.Size = 18;
                        rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        rng.Style.Font.Color.SetColor(Color.Black);
                    }
                    using (ExcelRange rng = ws.Cells["A3:I3"])
                    {
                        rng.Style.Font.Bold = true;
                        rng.Style.Font.Size = 14;
                        rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        rng.Style.Font.Color.SetColor(Color.Black);
                    }
                    using (ExcelRange rng = ws.Cells["A4:I4"])
                    {
                        rng.Style.Font.Bold = true;
                        rng.Style.Font.Size = 14;
                        rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        rng.Style.Font.Color.SetColor(Color.Red);
                    }
                    using (ExcelRange rng = ws.Cells["A6:AR6"])
                    {
                        rng.Style.Font.Bold = true;
                        rng.Style.Fill.PatternType = ExcelFillStyle.Solid;        //Set Pattern for the background to Solid 
                        rng.Style.Fill.BackgroundColor.SetColor(Color.SkyBlue);  //Set color to blue 
                        rng.Style.Font.Color.SetColor(Color.Black);
                        rng.AutoFitColumns();
                    }


                    pck.SaveAs(new FileInfo(filePath));
                }
            });
        }
        public static Task GenerateXLSRegistrationIsAccepted(List<HoSoHopLe> registrationInterviews, string filePath)
        {
            return Task.Run(() =>
            {
                using (ExcelPackage pck = new ExcelPackage())
                {
                    //Create the worksheet 
                    ExcelWorksheet ws = pck.Workbook.Worksheets.Add(DateTime.Now.Date.ToString());
                    ws.Cells[2, 1].Value = "DANH SÁCH ỨNG VIÊN CÓ HỒ SƠ HỢP LỆ";
                    ws.Cells["A2:I2"].Merge = true;


                    ws.Cells["A3:I3"].Merge = true;
                    ws.Cells[4, 1].Value = "Tính tới ngày " + DateTime.Now.ToString("dd/MM/yyyy");
                    ws.Cells["A4:I4"].Merge = true;
                    ws.Cells[6, 1].Value = "MÃ";
                    ws.Cells[6, 2].Value = "MÔN ĐĂNG KÍ";
                    //THONG TIN CA NHAN
                    ws.Cells[6, 3].Value = "HỌ VÀ TÊN";
                    ws.Cells[6, 4].Value = "NGÀY SINH";
                    ws.Cells[6, 5].Value = "GIỚI TÍNH";
                    ws.Cells[6, 6].Value = "DÂN TỘC";
                    ws.Cells[6, 7].Value = "TÔN GIÁO";
                    ws.Cells[6, 8].Value = "SỐ CMND/CCCD";
                    ws.Cells[6, 9].Value = "NGÀY CẤP";
                    ws.Cells[6, 10].Value = "NƠI CẤP";
                    ws.Cells[6, 11].Value = "SĐT";
                    ws.Cells[6, 12].Value = "EMAIL";
                    ws.Cells[6, 13].Value = "QUÊ QUÁN";
                    ws.Cells[6, 14].Value = "NƠI Ở HIỆN NAY";
                    ws.Cells[6, 15].Value = "HÔ KHẨU THƯỜNG TRÚ";
                    ws.Cells[6, 16].Value = "TÌNH TRẠNG SỨC KHỎE";
                    ws.Cells[6, 17].Value = "CHIỀU CAO (cm)";
                    ws.Cells[6, 18].Value = "CÂN NẶNG (kg)";
                    ws.Cells[6, 19].Value = "THÀNH PHẦN BẢN THÂN HIỆN TẠI";
                    //BANG DAI HOC
                    ws.Cells[6, 20].Value = "TỐT NGHIỆP";
                    ws.Cells[6, 21].Value = "CHUYÊN NGHÀNH ĐÀO TẠO";
                    ws.Cells[6, 22].Value = "HỆ";
                    ws.Cells[6, 23].Value = "TÊN TRƯỜNG";
                    ws.Cells[6, 24].Value = "TRƯỜNG NÀY Ở";
                    ws.Cells[6, 25].Value = "PHƯƠNG THỨC ĐÀO TẠO";
                    ws.Cells[6, 26].Value = "NĂM TỐT NGHIỆP";
                    ws.Cells[6, 27].Value = "ĐIỂM TB";
                    ws.Cells[6, 28].Value = "ĐIỂM ĐỒ ÁN";
                    ws.Cells[6, 29].Value = "XẾP LOẠI";
                    ws.Cells[6, 30].Value = "SỐ HIỆU VĂN BẰNG";
                    //CHUNG CHI KHÁC
                    ws.Cells[6, 31].Value = "CHỨNG CHỈ";
                    ws.Cells[6, 32].Value = "SỐ HIỆU VĂN BẰNG";
                    //TIN HOC
                    ws.Cells[6, 33].Value = "TIN HỌC";
                    ws.Cells[6, 34].Value = "SỐ HIỆU VĂN BẰNG";
                    //NGOAI NGHU
                    ws.Cells[6, 35].Value = "NGOẠI NGỮ";
                    ws.Cells[6, 36].Value = "SỐ HIỆU VĂN BẰNG";
                    //NGOAI NGU KHAC
                    ws.Cells[6, 37].Value = "NGOẠI NGỮ KHÁC";
                    ws.Cells[6, 38].Value = "SỐ HIỆU VĂN BẰNG";
                    //THONG TIN KHAC
                    ws.Cells[6, 39].Value = "ĐỐI TƯỢNG ƯU TIÊN";
                    ws.Cells[6, 40].Value = "TRƯỜNG HỢP ĐẶC BIỆT";
                    //NGUYEN VONG
                    ws.Cells[6, 41].Value = "NGUYỆN VỌNG 1";
                    ws.Cells[6, 42].Value = "NGUYỆN VỌNG 2";
                    ws.Cells[6, 43].Value = "NGUYỆN VỌNG 3";
                    ws.Cells[6, 44].Value = "MÃ VÒNG 2";
                    ws.Cells[6, 45].Value = "NGÀY RÀ XOÁT";
                    ws.Cells[6, 46].Value = "TRÌNH ĐỘ CAO NHẤT";
                    for (int i = 0; i < registrationInterviews.Count(); i++)
                    {
                        ws.Cells[i + 7, 1].Value = registrationInterviews.ElementAt(i).RegistrationInterview.TienTo + registrationInterviews.ElementAt(i).HoSoId;
                        ws.Cells[i + 7, 2].Value = registrationInterviews.ElementAt(i).RegistrationInterview.MonDuTuyen.ViTriUngTuyen.Name.Trim() + " " + registrationInterviews.ElementAt(i).RegistrationInterview.MonDuTuyen.Name;
                        //THONG TIN CA NHAN
                        ws.Cells[i + 7, 3].Value = registrationInterviews.ElementAt(i).RegistrationInterview.LastName + " " + registrationInterviews.ElementAt(i).RegistrationInterview.FirstName;
                        ws.Cells[i + 7, 4].Value = registrationInterviews.ElementAt(i).RegistrationInterview.DOB.Value.ToString("dd/MM/yyyy");
                        ws.Cells[i + 7, 5].Value = registrationInterviews.ElementAt(i).RegistrationInterview.IsMale == true ? "Nam" : "Nữ";
                        ws.Cells[i + 7, 6].Value = registrationInterviews.ElementAt(i).RegistrationInterview.DanToc.Name;
                        ws.Cells[i + 7, 7].Value = registrationInterviews.ElementAt(i).RegistrationInterview.TonGiao.Name;
                        ws.Cells[i + 7, 8].Value = registrationInterviews.ElementAt(i).RegistrationInterview.IdentifyCard;
                        ws.Cells[i + 7, 9].Value = registrationInterviews.ElementAt(i).RegistrationInterview.CMNDNgayCap.Value.ToString("dd/MM/yyyy");
                        ws.Cells[i + 7, 10].Value = registrationInterviews.ElementAt(i).RegistrationInterview.Province1.Type + " " + registrationInterviews.ElementAt(i).RegistrationInterview.Province1.Name;
                        ws.Cells[i + 7, 11].Value = registrationInterviews.ElementAt(i).RegistrationInterview.SDT;
                        ws.Cells[i + 7, 12].Value = registrationInterviews.ElementAt(i).RegistrationInterview.Email;
                        ws.Cells[i + 7, 13].Value = registrationInterviews.ElementAt(i).RegistrationInterview.Province2.Type + " " + registrationInterviews.ElementAt(i).RegistrationInterview.Province2.Name;
                        ws.Cells[i + 7, 14].Value = registrationInterviews.ElementAt(i).RegistrationInterview.HKTTSoNhaTenDuong + ", " + registrationInterviews.ElementAt(i).RegistrationInterview.Ward.Type + " " + registrationInterviews.ElementAt(i).RegistrationInterview.Ward.Name + ", " + registrationInterviews.ElementAt(i).RegistrationInterview.Ward.District.Type + " " + registrationInterviews.ElementAt(i).RegistrationInterview.Ward.District.Name + ", " + registrationInterviews.ElementAt(i).RegistrationInterview.Ward.District.Province.Type + " " + registrationInterviews.ElementAt(i).RegistrationInterview.Ward.District.Province.Name;
                        ws.Cells[i + 7, 15].Value = registrationInterviews.ElementAt(i).RegistrationInterview.HKTTSoNhaTenDuong + ", " + registrationInterviews.ElementAt(i).RegistrationInterview.Ward1.Type + " " + registrationInterviews.ElementAt(i).RegistrationInterview.Ward1.Name + ", " + registrationInterviews.ElementAt(i).RegistrationInterview.Ward1.District.Type + " " + registrationInterviews.ElementAt(i).RegistrationInterview.Ward1.District.Name + ", " + registrationInterviews.ElementAt(i).RegistrationInterview.Ward1.District.Province.Type + " " + registrationInterviews.ElementAt(i).RegistrationInterview.Ward1.District.Province.Name;
                        ws.Cells[i + 7, 16].Value = registrationInterviews.ElementAt(i).RegistrationInterview.TinhTrangSucKhoe;
                        ws.Cells[i + 7, 17].Value = registrationInterviews.ElementAt(i).RegistrationInterview.Chieucao;
                        ws.Cells[i + 7, 18].Value = registrationInterviews.ElementAt(i).RegistrationInterview.CanNang;
                        ws.Cells[i + 7, 19].Value = registrationInterviews.ElementAt(i).RegistrationInterview.ThanhPhanBanThanHienTai.Name;
                        //TRINH DO DAI HOC
                        ws.Cells[i + 7, 20].Value = registrationInterviews.ElementAt(i).RegistrationInterview.BangTotNghiep.Name;
                        ws.Cells[i + 7, 21].Value = registrationInterviews.ElementAt(i).RegistrationInterview.ChuyenNganhDaoTao.Name;
                        ws.Cells[i + 7, 22].Value = registrationInterviews.ElementAt(i).RegistrationInterview.HinhThucDaoTao.Name;
                        ws.Cells[i + 7, 23].Value = registrationInterviews.ElementAt(i).RegistrationInterview.TenTruongDaiHoc;
                        ws.Cells[i + 7, 24].Value = registrationInterviews.ElementAt(i).RegistrationInterview.Province.Type + " " + registrationInterviews.ElementAt(i).RegistrationInterview.Province.Name;
                        ws.Cells[i + 7, 25].Value = registrationInterviews.ElementAt(i).RegistrationInterview.IsNienChe == true ? "Niên chế" : "Tín chỉ";
                        ws.Cells[i + 7, 26].Value = registrationInterviews.ElementAt(i).RegistrationInterview.NamTotNghiep;
                        ws.Cells[i + 7, 27].Value = registrationInterviews.ElementAt(i).RegistrationInterview.GPA;
                        ws.Cells[i + 7, 28].Value = registrationInterviews.ElementAt(i).RegistrationInterview.DiemLuanVan;
                        ws.Cells[i + 7, 29].Value = registrationInterviews.ElementAt(i).RegistrationInterview.XepLoaiHocLuc.Name;
                        ws.Cells[i + 7, 30].Value = registrationInterviews.ElementAt(i).RegistrationInterview.SoVanBangChungChiDaiHoc;
                        //CHUNG CHI
                        ws.Cells[i + 7, 31].Value = registrationInterviews.ElementAt(i).RegistrationInterview.ChungChiNghiepVuSuPham.Name;
                        ws.Cells[i + 7, 32].Value = registrationInterviews.ElementAt(i).RegistrationInterview.ChungChiNghiepVuSuPhamSoVanBang;
                        //TIN HOC
                        ws.Cells[i + 7, 33].Value = registrationInterviews.ElementAt(i).RegistrationInterview.TrinhDoTinHoc.Name;
                        ws.Cells[i + 7, 34].Value = registrationInterviews.ElementAt(i).RegistrationInterview.SoVanBangChungChiTinHoc;
                        //NGOAI NGU
                        ws.Cells[i + 7, 35].Value = registrationInterviews.ElementAt(i).RegistrationInterview.TrinhDoNgoaiNgu.Name;
                        ws.Cells[i + 7, 36].Value = registrationInterviews.ElementAt(i).RegistrationInterview.SoVanBangChungChiNgoaiNgu;
                        //NGOAI NGU KHAC
                        ws.Cells[i + 7, 37].Value = registrationInterviews.ElementAt(i).RegistrationInterview.TrinhDoNgoaiNguKhac.Name;
                        ws.Cells[i + 7, 38].Value = registrationInterviews.ElementAt(i).RegistrationInterview.SoVanBangChungChiNgoaiNguKhac;
                        //THONG TIN KHAC
                        ws.Cells[i + 7, 39].Value = registrationInterviews.ElementAt(i).RegistrationInterview.DoiTuongUuTien1.Name;
                        //ws.Cells[i + 7, 40].Value = registrationInterviews.ElementAt(i).RegistrationInterview.TruongHopDacBiet.Name;
                        //NGUYEN VONG
                        ws.Cells[i + 7, 41].Value = registrationInterviews.ElementAt(i).RegistrationInterview.District.Type + " " + registrationInterviews.ElementAt(i).RegistrationInterview.District.Name;
                        ws.Cells[i + 7, 42].Value = registrationInterviews.ElementAt(i).RegistrationInterview.District1.Type + " " + registrationInterviews.ElementAt(i).RegistrationInterview.District1.Name;
                        ws.Cells[i + 7, 43].Value = registrationInterviews.ElementAt(i).RegistrationInterview.District2.Type + " " + registrationInterviews.ElementAt(i).RegistrationInterview.District2.Name;
                        ws.Cells[i + 7, 44].Value = registrationInterviews.ElementAt(i).TienTo + registrationInterviews.ElementAt(i).MaVong2;
                        ws.Cells[i + 7, 45].Value = registrationInterviews.ElementAt(i).RegistrationInterview.NgayRaXoat.Value.ToString("dd/MM/yyyy");
                        ws.Cells[i + 7, 46].Value = registrationInterviews.ElementAt(i).RegistrationInterview.TrinhDoCaoNhat.Name;

                    }
                    using (ExcelRange rng = ws.Cells["A2:I2"])
                    {
                        rng.Style.Font.Bold = true;
                        rng.Style.Font.Size = 18;
                        rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        rng.Style.Font.Color.SetColor(Color.Black);
                    }
                    using (ExcelRange rng = ws.Cells["A3:I3"])
                    {
                        rng.Style.Font.Bold = true;
                        rng.Style.Font.Size = 14;
                        rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        rng.Style.Font.Color.SetColor(Color.Black);
                    }
                    using (ExcelRange rng = ws.Cells["A4:I4"])
                    {
                        rng.Style.Font.Bold = true;
                        rng.Style.Font.Size = 14;
                        rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        rng.Style.Font.Color.SetColor(Color.Red);
                    }
                    using (ExcelRange rng = ws.Cells["A6:AT6"])
                    {
                        rng.Style.Font.Bold = true;
                        rng.Style.Fill.PatternType = ExcelFillStyle.Solid;        //Set Pattern for the background to Solid 
                        rng.Style.Fill.BackgroundColor.SetColor(Color.SkyBlue);  //Set color to blue 
                        rng.Style.Font.Color.SetColor(Color.Black);
                        rng.AutoFitColumns();
                    }


                    pck.SaveAs(new FileInfo(filePath));
                }
            });
        }
    }
}