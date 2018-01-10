using System.Linq;
using System.Threading.Tasks;
using DevaxiloS.DataAccess.MsSql.EntityFramework;
using DevaxiloS.Infras.Commands;
using DevaxiloS.Infras.Messaging;

namespace DevaxiloS.Services.Commands.Web.Dashboard
{

    public class GetKetQuaXoSoCommand : Command
    {

        public CommandResponse<string> Response { get; set; }

        public GetKetQuaXoSoCommand(int id) : base(id)
        {

        }
    }

    public class GetKetQuaXoSoCommandHandler : ICommandHandler<GetKetQuaXoSoCommand>
    {
        public async Task Execute(GetKetQuaXoSoCommand command)
        {
            using (var context = new DevaxiloContext())
            {
                string[] dayOfweek = { "CHỦ NHẬT", "THỨ 2", "THỨ 3", "THỨ 4", "THỨ 5", "THỨ 6", "THỨ 7" };

                KetQuaXoSoMienBac objKetQua = context.KetQuaXoSoMienBacs.OrderByDescending(u => u.Id).Take(1).FirstOrDefault();

                string strContent = "";
                string strBodyFormat = "<div class=\"row col-md-10\"><div class=\"row show-grid\"><div class=\"col-md-6\"><div class=\"widget result-box\"><div class=\"result-header\"><h3>Kết quả xổ số Miền Bắc</h3><h4 class=\"mb_date_info\">XSMB {0} ngày {1:dd/MM/yyyy}</h4></div><table cellspacing=\"0\" border=\"1\" cellpadding=\"0\"><tbody><tr><td class=\"first-col red\">Đặc Biệt</td><td colspan=\"12\" class=\"mb_g0 red\">{2}</td></tr><tr><td class=\"first-col\">Giải Nhất</td><td colspan=\"12\" class=\"mb_g1\">{3}</td></tr><tr><td class=\"first-col\">Giải Nhì</td><td colspan=\"6\" class=\"mb_g21\">{4}</td><td colspan=\"6\" class=\"mb_g22\">{5}</td></tr><tr><td rowspan=\"2\" class=\"first-col\">Giải Ba</td><td colspan=\"4\" class=\"mb_g31\">{6}</td><td colspan=\"4\" class=\"mb_g32\">{7}</td><td colspan=\"4\" class=\"mb_g33\">{8}</td></tr><tr><td colspan=\"4\" class=\"mb_g34\">{9}</td><td colspan=\"4\" class=\"mb_g35\">{10}</td><td colspan=\"4\" class=\"mb_g36\">{11}</td></tr><tr><td class=\"first-col\">Giải Tư</td><td colspan=\"3\" class=\"mb_g41\">{12}</td><td colspan=\"3\" class=\"mb_g42\">{13}</td><td colspan=\"3\" class=\"mb_g43\">{14}</td><td colspan=\"3\" class=\"mb_g44\">{15}</td></tr><tr><td rowspan=\"2\" class=\"first-col\">Giải Năm</td><td colspan=\"4\" class=\"mb_g51\">{16}</td><td colspan=\"4\" class=\"mb_g52\">{17}</td><td colspan=\"4\" class=\"mb_g53\">{18}</td></tr><tr><td colspan=\"4\" class=\"mb_g54\">{19}</td><td colspan=\"4\" class=\"mb_g55\">{20}</td><td colspan=\"4\" class=\"mb_g56\">{21}</td></tr><tr><td class=\"first-col\">Giải Sáu</td><td colspan=\"4\" class=\"mb_g61\">{22}</td><td colspan=\"4\" class=\"mb_g62\">{23}</td><td colspan=\"4\" class=\"mb_g63\">{24}</td></tr><tr><td class=\"first-col\">Giải Bảy</td><td colspan=\"3\" class=\"mb_g71\">{25}</td><td colspan=\"3\" class=\"mb_g72\">{26}</td><td colspan=\"3\" class=\"mb_g73\">{27}</td><td colspan=\"3\" class=\"mb_g74\">{28}</td></tr></tbody></table></div></div><div class=\"col-md-2\"><div class=\"widget dd-loto-widget\"><table><thead><tr><th>Đầu</th><th>Loto</th></tr></thead><tbody class=\"loto-first\"><tr><td class=\"dd-stt\">0</td><td class=\"dd-kq mb_dau_0\">{29}</td></tr><tr><td class=\"dd-stt\">1</td><td class=\"dd-kq mb_dau_1\">{30}</td></tr><tr><td class=\"dd-stt\">2</td><td class=\"dd-kq mb_dau_2\">{31}</td></tr><tr><td class=\"dd-stt\">3</td><td class=\"dd-kq mb_dau_3\">{32}</td></tr><tr><td class=\"dd-stt\">4</td><td class=\"dd-kq mb_dau_4\">{33}</td></tr><tr><td class=\"dd-stt\">5</td><td class=\"dd-kq mb_dau_5\">{34}</td></tr><tr><td class=\"dd-stt\">6</td><td class=\"dd-kq mb_dau_6\">{35}</td></tr><tr><td class=\"dd-stt\">7</td><td class=\"dd-kq mb_dau_7\">{36}</td></tr><tr><td class=\"dd-stt\">8</td><td class=\"dd-kq mb_dau_8\">{37}</td></tr><tr><td class=\"dd-stt\">9</td><td class=\"dd-kq mb_dau_9\">{38}</td></tr></tbody></table><div class=\"clear\"></div></div></div><div class=\"col-md-2\"><div class=\"widget dd-loto-widget\"><table class=\"dit-loto\"><thead><tr><th>Đuôi</th><th>Loto</th></tr></thead><tbody class=\"loto-last\"><tr><td class=\"dd-stt\">0</td><td class=\"dd-kq mb_duoi_0\">{39}</td></tr><tr><td class=\"dd-stt\">1</td><td class=\"dd-kq mb_duoi_1\">{40}</td></tr><tr><td class=\"dd-stt\">2</td><td class=\"dd-kq mb_duoi_2\">{41}</td></tr><tr><td class=\"dd-stt\">3</td><td class=\"dd-kq mb_duoi_3\">{42}</td></tr><tr><td class=\"dd-stt\">4</td><td class=\"dd-kq mb_duoi_4\">{43}</td></tr><tr><td class=\"dd-stt\">5</td><td class=\"dd-kq mb_duoi_5\">{44}</td></tr><tr><td class=\"dd-stt\">6</td><td class=\"dd-kq mb_duoi_6\">{45}</td></tr><tr><td class=\"dd-stt\">7</td><td class=\"dd-kq mb_duoi_7\">{46}</td></tr><tr><td class=\"dd-stt\">8</td><td class=\"dd-kq mb_duoi_8\">{47}</td></tr><tr><td class=\"dd-stt\">9</td><td class=\"dd-kq mb_duoi_9\">{48}</td></tr></tbody></table><div class=\"clear\"></div></div></div><div class=\"col-md-2\"><div class=\"widget dd-loto-widget\"><table class=\"dit-loto\"><thead><tr><th>TỔNG</th><th>Loto</th></tr></thead><tbody class=\"loto-last\"><tr><td class=\"dd-stt\">0</td><td class=\"dd-kq mb_duoi_0\">{49}</td></tr><tr><td class=\"dd-stt\">1</td><td class=\"dd-kq mb_duoi_1\">{50}</td></tr><tr><td class=\"dd-stt\">2</td><td class=\"dd-kq mb_duoi_2\">{51}</td></tr><tr><td class=\"dd-stt\">3</td><td class=\"dd-kq mb_duoi_3\">{52}</td></tr><tr><td class=\"dd-stt\">4</td><td class=\"dd-kq mb_duoi_4\">{53}</td></tr><tr><td class=\"dd-stt\">5</td><td class=\"dd-kq mb_duoi_5\">{54}</td></tr><tr><td class=\"dd-stt\">6</td><td class=\"dd-kq mb_duoi_6\">{55}</td></tr><tr><td class=\"dd-stt\">7</td><td class=\"dd-kq mb_duoi_7\">{56}</td></tr><tr><td class=\"dd-stt\">8</td><td class=\"dd-kq mb_duoi_8\">{57}</td></tr><tr><td class=\"dd-stt\">9</td><td class=\"dd-kq mb_duoi_9\">{58}</td></tr></tbody></table><div class=\"clear\"></div></div></div></div></div>";
                string H0 = ""; string H1 = ""; string H2 = ""; string H3 = ""; string H4 = ""; string H5 = ""; string H6 = ""; string H7 = ""; string H8 = ""; string H9 = "";
                string D0 = ""; string D1 = ""; string D2 = ""; string D3 = ""; string D4 = ""; string D5 = ""; string D6 = ""; string D7 = ""; string D8 = ""; string D9 = "";
                string T0 = ""; string T1 = ""; string T2 = ""; string T3 = ""; string T4 = ""; string T5 = ""; string T6 = ""; string T7 = ""; string T8 = ""; string T9 = "";

                if (objKetQua != null)
                {
                    H0 = ""; H1 = ""; H2 = ""; H3 = ""; H4 = ""; H5 = ""; H6 = ""; H7 = ""; H8 = ""; H9 = "";
                    D0 = ""; D1 = ""; D2 = ""; D3 = ""; D4 = ""; D5 = ""; D6 = ""; D7 = ""; D8 = ""; D9 = "";
                    T0 = ""; T1 = ""; T2 = ""; T3 = ""; T4 = ""; T5 = ""; T6 = ""; T7 = ""; T8 = ""; T9 = "";

                    string[] array = objKetQua.LoCuoi.Split('|');
                    string strDE = objKetQua.De;

                    #region FOR DAU LOTO

                    foreach (var objKetQualo in array)
                    {
                        if (string.IsNullOrEmpty(objKetQualo))
                        {
                            break;
                        }
                        if (objKetQualo[0].ToString() == "0")
                        {
                            if (objKetQualo.ToString() == strDE)
                            {
                                H0 += string.Format(" <span class=\"red\">{0}</span>,", objKetQualo);
                            }
                            else
                            {
                                H0 += string.Format(" {0},", objKetQualo);
                            }
                        }
                        else if (objKetQualo[0].ToString() == "1")
                        {
                            if (objKetQualo.ToString() == strDE)
                            {
                                H1 += string.Format(" <span class=\"red\">{0}</span>,", objKetQualo);
                            }
                            else
                            {
                                H1 += string.Format(" {0},", objKetQualo);
                            }
                        }
                        else if (objKetQualo[0].ToString() == "2")
                        {
                            if (objKetQualo.ToString() == strDE)
                            {
                                H2 += string.Format(" <span class=\"red\">{0}</span>,", objKetQualo);
                            }
                            else
                            {
                                H2 += string.Format(" {0},", objKetQualo);
                            }
                        }
                        else if (objKetQualo[0].ToString() == "3")
                        {
                            if (objKetQualo.ToString() == strDE)
                            {
                                H3 += string.Format(" <span class=\"red\">{0}</span>,", objKetQualo);
                            }
                            else
                            {
                                H3 += string.Format(" {0},", objKetQualo);
                            }
                        }
                        else if (objKetQualo[0].ToString() == "4")
                        {
                            if (objKetQualo.ToString() == strDE)
                            {
                                H4 += string.Format(" <span class=\"red\">{0}</span>,", objKetQualo);
                            }
                            else
                            {
                                H4 += string.Format(" {0},", objKetQualo);
                            }
                        }
                        else if (objKetQualo[0].ToString() == "5")
                        {
                            if (objKetQualo.ToString() == strDE)
                            {
                                H5 += string.Format(" <span class=\"red\">{0}</span>,", objKetQualo);
                            }
                            else
                            {
                                H5 += string.Format(" {0},", objKetQualo);
                            }
                        }
                        else if (objKetQualo[0].ToString() == "6")
                        {
                            if (objKetQualo.ToString() == strDE)
                            {
                                H6 += string.Format(" <span class=\"red\">{0}</span>,", objKetQualo);
                            }
                            else
                            {
                                H6 += string.Format(" {0},", objKetQualo);
                            }
                        }
                        else if (objKetQualo[0].ToString() == "7")
                        {
                            if (objKetQualo.ToString() == strDE)
                            {
                                H7 += string.Format(" <span class=\"red\">{0}</span>,", objKetQualo);
                            }
                            else
                            {
                                H7 += string.Format("{0},", objKetQualo);
                            }
                        }
                        else if (objKetQualo[0].ToString() == "8")
                        {
                            if (objKetQualo.ToString() == strDE)
                            {
                                H8 += string.Format(" <span class=\"red\">{0}</span>,", objKetQualo);
                            }
                            else
                            {
                                H8 += string.Format(" {0},", objKetQualo);
                            }
                        }
                        else if (objKetQualo[0].ToString() == "9")
                        {
                            if (objKetQualo.ToString() == strDE)
                            {
                                H9 += string.Format(" <span class=\"red\">{0}</span>,", objKetQualo);
                            }
                            else
                            {
                                H9 += string.Format(" {0},", objKetQualo);
                            }
                        }
                    }

                    #endregion

                    #region FOR DUOI LOTO

                    foreach (var objKetQualo in array)
                    {
                        if (string.IsNullOrEmpty(objKetQualo))
                        {
                            break;
                        }
                        if (objKetQualo[1].ToString() == "0")
                        {
                            if (objKetQualo.ToString() == strDE)
                            {
                                D0 += string.Format(" <span class=\"red\">{0}</span>,", objKetQualo);
                            }
                            else
                            {
                                D0 += string.Format(" {0},", objKetQualo);
                            }
                        }
                        else if (objKetQualo[1].ToString() == "1")
                        {
                            if (objKetQualo.ToString() == strDE)
                            {
                                D1 += string.Format(" <span class=\"red\">{0}</span>,", objKetQualo);
                            }
                            else
                            {
                                D1 += string.Format(" {0},", objKetQualo);
                            }
                        }
                        else if (objKetQualo[1].ToString() == "2")
                        {
                            if (objKetQualo.ToString() == strDE)
                            {
                                D2 += string.Format(" <span class=\"red\">{0}</span>,", objKetQualo);
                            }
                            else
                            {
                                D2 += string.Format(" {0},", objKetQualo);
                            }
                        }
                        else if (objKetQualo[1].ToString() == "3")
                        {
                            if (objKetQualo.ToString() == strDE)
                            {
                                D3 += string.Format(" <span class=\"red\">{0}</span>,", objKetQualo);
                            }
                            else
                            {
                                D3 += string.Format(" {0},", objKetQualo);
                            }
                        }
                        else if (objKetQualo[1].ToString() == "4")
                        {
                            if (objKetQualo.ToString() == strDE)
                            {
                                D4 += string.Format(" <span class=\"red\">{0}</span>,", objKetQualo);
                            }
                            else
                            {
                                D4 += string.Format(" {0},", objKetQualo);
                            }
                        }
                        else if (objKetQualo[1].ToString() == "5")
                        {
                            if (objKetQualo.ToString() == strDE)
                            {
                                D5 += string.Format(" <span class=\"red\">{0}</span>,", objKetQualo);
                            }
                            else
                            {
                                D5 += string.Format(" {0},", objKetQualo);
                            }
                        }
                        else if (objKetQualo[1].ToString() == "6")
                        {
                            if (objKetQualo.ToString() == strDE)
                            {
                                D6 += string.Format(" <span class=\"red\">{0}</span>,", objKetQualo);
                            }
                            else
                            {
                                D6 += string.Format(" {0},", objKetQualo);
                            }
                        }
                        else if (objKetQualo[1].ToString() == "7")
                        {
                            if (objKetQualo.ToString() == strDE)
                            {
                                D7 += string.Format(" <span class=\"red\">{0}</span>,", objKetQualo);
                            }
                            else
                            {
                                D7 += string.Format("{0},", objKetQualo);
                            }
                        }
                        else if (objKetQualo[1].ToString() == "8")
                        {
                            if (objKetQualo.ToString() == strDE)
                            {
                                D8 += string.Format(" <span class=\"red\">{0}</span>,", objKetQualo);
                            }
                            else
                            {
                                D8 += string.Format(" {0},", objKetQualo);
                            }
                        }
                        else if (objKetQualo[1].ToString() == "9")
                        {
                            if (objKetQualo.ToString() == strDE)
                            {
                                D9 += string.Format(" <span class=\"red\">{0}</span>,", objKetQualo);
                            }
                            else
                            {
                                D9 += string.Format(" {0},", objKetQualo);
                            }
                        }
                    }

                    #endregion

                    #region FOR TONG LOTO
                    string tong = "";
                    foreach (var objKetQualo in array)
                    {
                        if (string.IsNullOrEmpty(objKetQualo))
                        {
                            break;
                        }
                        tong = string.Empty;
                        tong = (int.Parse(objKetQualo[0].ToString()) + int.Parse(objKetQualo[1].ToString())).ToString();
                        tong = tong.Length == 2 ? tong[1].ToString() : tong;
                        if (tong == "0")
                        {
                            if (objKetQualo.ToString() == strDE)
                            {
                                T0 += string.Format(" <span class=\"red\">{0}</span>,", objKetQualo);
                            }
                            else
                            {
                                T0 += string.Format(" {0},", objKetQualo);
                            }
                        }
                        else if (tong == "1")
                        {
                            if (objKetQualo.ToString() == strDE)
                            {
                                T1 += string.Format(" <span class=\"red\">{0}</span>,", objKetQualo);
                            }
                            else
                            {
                                T1 += string.Format(" {0},", objKetQualo);
                            }
                        }
                        else if (tong == "2")
                        {
                            if (objKetQualo.ToString() == strDE)
                            {
                                T2 += string.Format(" <span class=\"red\">{0}</span>,", objKetQualo);
                            }
                            else
                            {
                                T2 += string.Format(" {0},", objKetQualo);
                            }
                        }
                        else if (tong == "3")
                        {
                            if (objKetQualo.ToString() == strDE)
                            {
                                T3 += string.Format(" <span class=\"red\">{0}</span>,", objKetQualo);
                            }
                            else
                            {
                                T3 += string.Format(" {0},", objKetQualo);
                            }
                        }
                        else if (tong == "4")
                        {
                            if (objKetQualo.ToString() == strDE)
                            {
                                T4 += string.Format(" <span class=\"red\">{0}</span>,", objKetQualo);
                            }
                            else
                            {
                                T4 += string.Format(" {0},", objKetQualo);
                            }
                        }
                        else if (tong == "5")
                        {
                            if (objKetQualo.ToString() == strDE)
                            {
                                T5 += string.Format(" <span class=\"red\">{0}</span>,", objKetQualo);
                            }
                            else
                            {
                                T5 += string.Format(" {0},", objKetQualo);
                            }
                        }
                        else if (tong == "6")
                        {
                            if (objKetQualo.ToString() == strDE)
                            {
                                T6 += string.Format(" <span class=\"red\">{0}</span>,", objKetQualo);
                            }
                            else
                            {
                                T6 += string.Format(" {0},", objKetQualo);
                            }
                        }
                        else if (tong == "7")
                        {
                            if (objKetQualo.ToString() == strDE)
                            {
                                T7 += string.Format(" <span class=\"red\">{0}</span>,", objKetQualo);
                            }
                            else
                            {
                                T7 += string.Format("{0},", objKetQualo);
                            }
                        }
                        else if (tong == "8")
                        {
                            if (objKetQualo.ToString() == strDE)
                            {
                                T8 += string.Format(" <span class=\"red\">{0}</span>,", objKetQualo);
                            }
                            else
                            {
                                T8 += string.Format(" {0},", objKetQualo);
                            }
                        }
                        else if (tong == "9")
                        {
                            if (objKetQualo.ToString() == strDE)
                            {
                                T9 += string.Format(" <span class=\"red\">{0}</span>,", objKetQualo);
                            }
                            else
                            {
                                T9 += string.Format(" {0},", objKetQualo);
                            }
                        }
                    }
                    #endregion

                    strContent = strContent + string.Format(strBodyFormat, dayOfweek[(int)objKetQua.CreatedDate.DayOfWeek], objKetQua.CreatedDate, objKetQua.G0, objKetQua.G1, objKetQua.G21
                        , objKetQua.G22, objKetQua.G31, objKetQua.G32, objKetQua.G33, objKetQua.G34, objKetQua.G35, objKetQua.G36, objKetQua.G41, objKetQua.G42, objKetQua.G43, objKetQua.G44, objKetQua.G51, objKetQua.G52, objKetQua.G53, objKetQua.G54, objKetQua.G55, objKetQua.G56
                        , objKetQua.G61, objKetQua.G62, objKetQua.G63, objKetQua.G71, objKetQua.G72, objKetQua.G73, objKetQua.G74
                        , H0, H1, H2, H3, H4, H5, H6, H7, H8, H9
                        , D0, D1, D2, D3, D4, D5, D6, D7, D8, D9
                        , T0, T1, T2, T3, T4, T5, T6, T7, T8, T9);
                }
                await context.SaveChangesAsync();
                command.Response = new CommandResponse<string>(strContent, false, "Lay ket qua is ok");
            }
        }
    }


}
