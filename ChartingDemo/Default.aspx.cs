using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dotnetCHARTING;

namespace ChartingDemo
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            #region 调用说明及范例

            //在要显示统计图的页面代码直接调用，方法类似如下：        
            var ch = new Charting();
            ch.Title = "2014年各月消费情况统计";
            ch.XName = "月份";
            ch.YName = "金额(万元)";
            ch.PicHight = 300;
            ch.PicWidth = 600;
            ch.SeriseName = "总金额";
            ch.PhaysicalImagePath = "images";
            ch.FileName = "Combo";
            Random myR = new Random();
            DataTable dt = new DataTable();
            dt.Columns.Add("month", typeof (string));
            dt.Columns.Add("money", typeof (string));
            dt.Columns["month"].AutoIncrement = true;
            for (int i = 1; i < 5; i++)
            {
                DataRow dr = dt.NewRow();
                dr["month"] = i.ToString();
                dr["money"] = myR.Next(60, 100);
                dt.Rows.Add(dr);
            }

            ch.DataSoure = dt;
            
            //ch.ColumnWidth = 30;
            ch.NumberPercision = 3;

            ch.CreateCombo(this.Chart1);//显示柱形图


            //ch = new Charting();
            //ch.Title = "2014年各月消费情况统计";
            //ch.XName = "月份";
            //ch.YName = "金额(万元)";
            //ch.PicHight = 300;
            //ch.PicWidth = 600;
            //ch.SeriseName = "总金额";
            //ch.PhaysicalImagePath = "images/chart";
            //ch.FileName = "Line";
            ////ch.IsUse3D = true;
            //ch.DataSoure = dt;
            //ch.ColumnWidth = 30;
            //ch.NumberPercision = 2;
            //ch.CreateComboHorizontal(this.Chart2);//显示曲线图

            ch = new Charting();
            ch.Title = "2014年各月消费情况统计";
            ch.XName = "月份";
            ch.YName = "金额(万元)";
            ch.PicHight = 300;
            ch.PicWidth = 600;
            ch.SeriseName = "总金额";
            ch.PhaysicalImagePath = "images";
            ch.FileName = "Pie";
            ch.DataSoure = dt;
            //ch.ColumnWidth = 30;
            ch.NumberPercision = 2;
            //ch.IsUse3D = true;
            ch.CreatePie(this.Chart2); //显示饼图

            //ch = new Charting();
            //ch.Title = "2014年各月消费情况统计";
            //ch.XName = "月份";
            //ch.YName = "金额(万元)";
            //ch.PicHight = 300;
            //ch.PicWidth = 600;
            //ch.SeriseName = "总金额";
            //ch.PhaysicalImagePath = "images";
            //ch.FileName = "Pie";
            //ch.DataSoure = dt;
            //DataTable dt2 = new DataTable();
            //dt2.Columns.Add("month", typeof(string));
            //dt2.Columns.Add("money", typeof(string));
            //dt2.Columns["month"].AutoIncrement = true;
            //for (int i = 1; i <3; i++)
            //{
            //    DataRow dr = dt2.NewRow();
            //    dr["month"] = i.ToString();
            //    dr["money"] = myR.Next(0,50);
            //    dt2.Rows.Add(dr);
            //}
            //ch.DataSoure2 = dt2;
            //ch.ColumnWidth = 30;
            //ch.NumberPercision = 2;
            ////ch.IsUse3D = true;
            //ch.CreateCombos(this.Chart3); //显示多序列

            #endregion

            //CreateCombo();
            //ch.CreateCombo(this.Chart2); //显示饼图
            //CreateCombo1();
        }


        public object CreateCombo()
        {
            var ch = new Charting();
            ch.Title = "2014年各月消费情况统计";
            ch.XName = "月份";
            ch.YName = "金额(万元)";
            ch.PicHight = 300;
            ch.PicWidth = 600;
            ch.SeriseName = "总金额";
            ch.PhaysicalImagePath = "images/chart";
            ch.FileName = DateTime.Now.ToString("yyyyMMddHHmmssffff");
            //DataTable dt = new DataTable();
            //dt.Columns.Add("month", typeof(string));
            //dt.Columns.Add("money", typeof(string));
            //dt.Columns["month"].AutoIncrement = true;
            //for (int i = 1; i < 13; i++)
            //{
            //    DataRow dr = dt.NewRow();
            //    dr["month"] = i.ToString();
            //    dr["money"] = 100 * i;
            //    dt.Rows.Add(dr);
            //}
            Random myR = new Random();
            DataTable dt = new DataTable();
            dt.Columns.Add("month", typeof(string));
            dt.Columns.Add("money", typeof(string));
            dt.Columns.Add("ee", typeof(string));
            dt.Columns["month"].AutoIncrement = true;
            for (int i = 1; i < 5; i++)
            {

                DataRow dr = dt.NewRow();
                dr["ee"] = "E" + i.ToString();

                for (int b = 0; b < 4; b++)
                {
                    DataRow dr1 = dt.NewRow();
                    dr1["month"] = i.ToString();
                    dr1["money"] = myR.Next(50);
                    dt.Rows.Add(dr1);
                }
                //dt.Rows.Add(dr);
            }
            //SeriesCollection SC = new SeriesCollection();
            //Random myR = new Random();
            //for (int a = 0; a < 4; a++)
            //{
            //    Series s = new Series();
            //    s.Name = "Series " + a;
            //    for (int b = 0; b < 5; b++)
            //    {
            //        Element e = new Element();
            //        e.Name = "E " + b;
            //        e.YValue = myR.Next(50);
            //        s.Elements.Add(e);
            //    }
            //    SC.Add(s);
            //}
            ch.DataSoure = dt;
            //ch.IsUse3D = true;
            //var char1 = new Chart();
            ch.ColumnWidth = 30;
            ch.NumberPercision = 3;
            ch.CreateCombo(this.Chart2);//显示柱形图

            return Chart1.TempDirectory + "/" + Chart1.FileName;
        }

        public object CreateCombo1()
        {
            var ch = new Charting();
            ch.Title = "2014年各月消费情况统计";
            ch.XName = "月份";
            ch.YName = "金额(万元)";
            ch.PicHight = 300;
            ch.PicWidth = 600;
            ch.SeriseName = "总金额";
            ch.PhaysicalImagePath = "images/chart";
            ch.FileName = DateTime.Now.ToString("yyyyMMddHHmmssffff");

            Random myR = new Random();
            DataTable dt = new DataTable();
            dt.Columns.Add("month", typeof(string));
            dt.Columns.Add("money", typeof(string));
            dt.Columns["month"].AutoIncrement = true;
            for (int i = 1; i < 5; i++)
            {

                DataRow dr = dt.NewRow();
                dr["month"] = i.ToString();

                for (int b = 0; b < 3; b++)
                {
                    DataRow dr1 = dt.NewRow();
                    dr1["month"] = i.ToString();
                    dr1["money"] = myR.Next(50);
                    dt.Rows.Add(dr1);
                }
               
            }
            ch.DataSoure = dt;
            ch.IsUse3D = false;
            var char1 = new Chart();
            ch.CreateCombo1(this.Chart1);//显示柱形图


            return Chart1.TempDirectory + "/" + Chart1.FileName;
        }
    }
}