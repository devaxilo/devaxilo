using System;
using System.Configuration;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using DevaxiloS.DataAccess.MsSql.EntityFramework;

namespace DevaxiloS.Services.Commands.Web.Dashboard
{
    public class KetQuaUtils
    {
        /// <summary>
        /// Lấy nội dung trang web
        /// </summary>
        /// <param name="linkWeb">Đường dẫn trang web</param>
        /// <returns></returns>
        public string GetWebContent(string linkWeb)
        {
            string contentHTML = string.Empty;

            try
            {
                //WebProxy p = new WebProxy("10.10.9.1:11000", true);
                //p.Credentials = new NetworkCredential("lethanhchung", "Meo123!@#");
                WebRequest objWebResquest = WebRequest.Create(linkWeb);
                //objWebResquest.Proxy = p;
                objWebResquest.Credentials = CredentialCache.DefaultCredentials;
                WebResponse objWebRespose = objWebResquest.GetResponse();
                Stream receiveStream = objWebRespose.GetResponseStream();
                StreamReader readStream = new StreamReader(receiveStream, System.Text.Encoding.UTF8);
                contentHTML = readStream.ReadToEnd();
                objWebRespose.Close();
                readStream.Close();
            }
            catch (System.Exception)
            {

            }

            return contentHTML;
        }

        public KetQuaXoSoMienBac AnalysisLotteryFromMinhNgoc(DateTime date, KetQuaXoSoMienBac objKetqua)
        {
            try
            {
                if (objKetqua == null)
                {
                    objKetqua = new KetQuaXoSoMienBac { CreatedDate = date };
                }

                Match matchDB;
                Match matchNhat;

                string strGiaiDb = string.Empty;
                string strGiaiNhat = string.Empty;
                string strGiaiNhi = string.Empty;
                string strGiaiBa = string.Empty;
                string strGiaiTu = string.Empty;
                string strGiaiNam = string.Empty;
                string strGiaiSau = string.Empty;
                string strGiaiBay = string.Empty;
                string strDe = string.Empty;
                string strLo = string.Empty;
                string strLoDau = string.Empty;

                string strDate = string.Empty;

                string url = $"http://www.minhngoc.net.vn/ket-qua-xo-so/mien-bac/{date.Day}-{date.Month}-{date.Year}.html";

                string strHtml = GetWebContent(url);

                string replacekey = ConfigurationManager.AppSettings["RegexDel"].ToString();

                strHtml = Regex.Replace(strHtml, replacekey, string.Empty);

                /*Lay ngay thang chuan*/
                Match matchDate = Regex.Match(strHtml, "title=\"Click xem KQXS 3 Miền Ngày: (.*?)\">");
                while (matchDate.Success)
                {
                    strDate = matchDate.Groups[1].Value.Trim();
                    matchDate = matchDate.NextMatch();
                    if (strDate != string.Empty)
                    {
                        break;
                    }
                }

                DateTime dateParse = new DateTime(2001, 01, 01);
                if (strDate != string.Empty)
                {
                    string[] arrayDate = strDate.Split('/');
                    dateParse = new DateTime(int.Parse(arrayDate[2]), int.Parse(arrayDate[1]), int.Parse(arrayDate[0]));
                }

                if (dateParse == date)
                {

                    #region GIAIDB
                    //Giai DB
                    matchDB = Regex.Match(strHtml, "<td class=\"giaidb\">(.*?)</td>");
                    while (matchDB.Success)
                    {
                        matchNhat = Regex.Match(matchDB.Groups[1].Value.Trim(), "<div>(.*?)</div>");
                        while (matchNhat.Success)
                        {
                            strGiaiDb = matchNhat.Groups[1].Value.Trim();
                            strDe = matchNhat.Groups[1].Value.Trim().Substring(matchNhat.Groups[1].Value.Trim().Length - 2, 2);
                            strLo += matchNhat.Groups[1].Value.Trim().Substring(matchNhat.Groups[1].Value.Trim().Length - 2, 2) + "|";
                            strLoDau += matchNhat.Groups[1].Value.Trim().Substring(0, 2) + "|";
                            matchNhat = matchNhat.NextMatch();
                        }
                        matchDB = matchDB.NextMatch();
                        break;
                    }

                    #endregion

                    #region GIAI NHAT
                    //Giai nhat
                    matchDB = Regex.Match(strHtml, "<td class=\"giai1\">(.*?)</td>");
                    while (matchDB.Success)
                    {
                        matchNhat = Regex.Match(matchDB.Groups[1].Value.Trim(), "<div>(.*?)</div>");
                        while (matchNhat.Success)
                        {
                            strGiaiNhat = matchNhat.Groups[1].Value.Trim();
                            strLo += matchNhat.Groups[1].Value.Trim().Substring(matchNhat.Groups[1].Value.Trim().Length - 2, 2) + "|";
                            strLoDau += matchNhat.Groups[1].Value.Trim().Substring(0, 2) + "|";
                            matchNhat = matchNhat.NextMatch();
                        }
                        break;
                    }
                    #endregion

                    #region GIAI HAI
                    //Giai hai
                    matchDB = Regex.Match(strHtml, "<td class=\"giai2\">(.*?)</td>");
                    while (matchDB.Success)
                    {
                        matchNhat = Regex.Match(matchDB.Groups[1].Value.Trim(), "<div>(.*?)</div>");
                        while (matchNhat.Success)
                        {
                            strGiaiNhi += matchNhat.Groups[1].Value.Trim() + "|";

                            strLo += matchNhat.Groups[1].Value.Trim().Substring(strGiaiDb.Length - 2, 2) + "|";
                            strLoDau += matchNhat.Groups[1].Value.Trim().Substring(0, 2) + "|";
                            matchNhat = matchNhat.NextMatch();
                        }
                        break;
                    }

                    #endregion

                    #region GIAI BA
                    //Giai ba
                    matchDB = Regex.Match(strHtml, "<td class=\"giai3\">(.*?)</td>");
                    while (matchDB.Success)
                    {
                        matchNhat = Regex.Match(matchDB.Groups[1].Value.Trim(), "<div>(.*?)</div>");
                        while (matchNhat.Success)
                        {
                            strGiaiBa += matchNhat.Groups[1].Value.Trim() + "|";

                            strLo += matchNhat.Groups[1].Value.Trim().Substring(strGiaiDb.Length - 2, 2) + "|";
                            strLoDau += matchNhat.Groups[1].Value.Trim().Substring(0, 2) + "|";
                            matchNhat = matchNhat.NextMatch();
                        }
                        break;
                    }
                    #endregion

                    #region GIAI TU
                    //Giai tu
                    matchDB = Regex.Match(strHtml, "<td class=\"giai4\">(.*?)</td>");
                    while (matchDB.Success)
                    {
                        matchNhat = Regex.Match(matchDB.Groups[1].Value.Trim(), "<div>(.*?)</div>");
                        while (matchNhat.Success)
                        {
                            strGiaiTu += matchNhat.Groups[1].Value.Trim() + "|";

                            strLo += matchNhat.Groups[1].Value.Trim().Substring(matchNhat.Groups[1].Value.Trim().Length - 2, 2) + "|";
                            strLoDau += matchNhat.Groups[1].Value.Trim().Substring(0, 2) + "|";
                            matchNhat = matchNhat.NextMatch();
                        }
                        break;
                    }
                    #endregion

                    #region GIAI NAM
                    //Giai nam
                    matchDB = Regex.Match(strHtml, "<td class=\"giai5\">(.*?)</td>");
                    while (matchDB.Success)
                    {
                        matchNhat = Regex.Match(matchDB.Groups[1].Value.Trim(), "<div>(.*?)</div>");
                        while (matchNhat.Success)
                        {
                            strGiaiNam += matchNhat.Groups[1].Value.Trim() + "|";

                            strLo += matchNhat.Groups[1].Value.Trim().Substring(matchNhat.Groups[1].Value.Trim().Length - 2, 2) + "|";
                            strLoDau += matchNhat.Groups[1].Value.Trim().Substring(0, 2) + "|";
                            matchNhat = matchNhat.NextMatch();
                        }
                        break;
                    }
                    #endregion

                    #region GIAI SAU
                    //Giai SAU
                    matchDB = Regex.Match(strHtml, "<td class=\"giai6\">(.*?)</td>");
                    while (matchDB.Success)
                    {
                        matchNhat = Regex.Match(matchDB.Groups[1].Value.Trim(), "<div>(.*?)</div>");
                        while (matchNhat.Success)
                        {
                            strGiaiSau += matchNhat.Groups[1].Value.Trim() + "|";

                            strLo += matchNhat.Groups[1].Value.Trim().Substring(matchNhat.Groups[1].Value.Trim().Length - 2, 2) + "|";
                            strLoDau += matchNhat.Groups[1].Value.Trim().Substring(0, 2) + "|";
                            matchNhat = matchNhat.NextMatch();
                        }
                        break;
                    }
                    #endregion

                    #region GIAI BAY
                    //Giai bay
                    matchDB = Regex.Match(strHtml, "<td class=\"giai7\">(.*?)</td>");
                    while (matchDB.Success)
                    {
                        matchNhat = Regex.Match(matchDB.Groups[1].Value.Trim(), "<div>(.*?)</div>");
                        while (matchNhat.Success)
                        {
                            strGiaiBay += matchNhat.Groups[1].Value.Trim() + "|";

                            strLo += matchNhat.Groups[1].Value.Trim().Substring(matchNhat.Groups[1].Value.Trim().Length - 2, 2) + "|";
                            strLoDau += matchNhat.Groups[1].Value.Trim().Substring(0, 2) + "|";
                            matchNhat = matchNhat.NextMatch();
                        }
                        break;
                    }
                    #endregion

                    #region "DAY VAO DB"
                    string[] array;
                    objKetqua.G0 = strGiaiDb.Trim();
                    objKetqua.G1 = strGiaiNhat.Trim();
                    array = strGiaiNhi.Split('|');
                    objKetqua.G21 = array[0].Trim();
                    objKetqua.G22 = array[1].Trim();
                    array = strGiaiBa.Split('|');
                    objKetqua.G31 = array[0].Trim();
                    objKetqua.G32 = array[1].Trim();
                    objKetqua.G33 = array[2].Trim();
                    objKetqua.G34 = array[3].Trim();
                    objKetqua.G35 = array[4].Trim();
                    objKetqua.G36 = array[5].Trim();
                    array = strGiaiTu.Split('|');
                    objKetqua.G41 = array[0].Trim();
                    objKetqua.G42 = array[1].Trim();
                    objKetqua.G43 = array[2].Trim();
                    objKetqua.G44 = array[3].Trim();
                    array = strGiaiNam.Split('|');
                    objKetqua.G51 = array[0].Trim();
                    objKetqua.G52 = array[1].Trim();
                    objKetqua.G53 = array[2].Trim();
                    objKetqua.G54 = array[3].Trim();
                    objKetqua.G55 = array[4].Trim();
                    objKetqua.G56 = array[5].Trim();
                    array = strGiaiSau.Split('|');
                    objKetqua.G61 = array[0].Trim();
                    objKetqua.G62 = array[1].Trim();
                    objKetqua.G63 = array[2].Trim();
                    array = strGiaiBay.Split('|');
                    objKetqua.G71 = array[0].Trim();
                    objKetqua.G72 = array[1].Trim();
                    objKetqua.G73 = array[2].Trim();
                    objKetqua.G74 = array[3].Trim();
                    objKetqua.LoCuoi = strLo;
                    objKetqua.De = strDe;
                    #endregion
                }

            }
            catch (Exception)
            {

            }
            return objKetqua;
        }

    }
}