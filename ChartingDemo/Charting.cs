using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Threading;
using dotnetCHARTING;

namespace ChartingDemo
{
    /// <summary>
    /// Charting 的摘要说明
    /// </summary>
    public class Charting
    {
        #region 共有变量

        /// <summary>        
        /// 图片存放路径        
        /// </summary>        
        public string PhaysicalImagePath { get; set; }

        /// <summary>        
        /// 标题        
        /// </summary>        
        public string Title { get; set; }

        /// <summary>        
        /// X轴名称        
        /// </summary>        
        public string XName { get; set; }

        /// <summary>        
        /// Y轴名称        
        /// </summary>        
        public string YName { get; set; }

        /// <summary>        
        /// 图例名称        
        /// </summary>        
        public string SeriseName { get; set; }

        /// <summary>        
        /// 图片宽度        
        /// </summary>        
        public int PicWidth { get; set; }

        /// <summary>        
        /// 图片高度        
        /// </summary>        
        public int PicHight { get; set; }

        /// <summary>        
        /// 数据源        
        /// </summary>        
        public DataTable DataSoure { get; set; }

        /// <summary>        
        /// 数据源2    
        /// </summary>        
        public DataTable DataSoure2 { get; set; }

        /// <summary>
        /// 图片名称
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// 是否是3d
        /// </summary>
        public bool IsUse3D { get; set; }

        /// <summary>
        /// 设置柱状图每个单元格的宽度        
        /// </summary>
        public int ColumnWidth { get; set; } //

        /// <summary>
        /// 设置数值小数点 
        /// </summary>
        public int NumberPercision { get; set; }


        public ChartType type { get; set; }

        #region 构造函数

        public Charting()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }

        #endregion

        #endregion

        /// <summary>        
        /// 柱形图        
        /// </summary>        
        /// <returns></returns>        
        public void CreateCombo(dotnetCHARTING.Chart chart1)
        {
            chart1.Title = Title;
            //chart1.ChartArea.Background.Color = Color.White;//图片背景
            //chart1.BackColor = Color.FromArgb(0xe1, 0xe1, 0xe1);//整个图表的背景颜色(外延伸部分)
            chart1.TitleBox.CornerTopLeft = BoxCorner.Square; //标题框四角的样式
            chart1.LegendBox.Position = LegendBoxPosition.Top; //提示说明框的位置
            chart1.FileManager.FileName = FileName;
            chart1.XAxis.Label.Text = XName;
            //chart1.XAxis.StaticColumnWidth = 100;//每个单元格的宽度   
            //chart1.XAxis.StaticColumnWidth = ColumnWidth; //每个单元格的宽度  

            chart1.YAxis.Label.Text = this.YName;
            chart1.TempDirectory = this.PhaysicalImagePath;
            chart1.Width = this.PicWidth;
            chart1.Height = this.PicHight;
            chart1.Type = ChartType.Combo;
            chart1.Series.Type = SeriesType.Bar;
            chart1.Series.Name = this.SeriseName;
            //chart1.Series.Data = this.DataSoure;
            chart1.SeriesCollection.Add(getArrayData());
            //chart1.DefaultSeries.DefaultElement.ShowValue = true;

            //chart1.DefaultSeries.Type = SeriesType.Bar;//
            //chart1.DefaultSeries.Type = SeriesType.Bar;//方形
            chart1.ShadingEffect = true;
            chart1.Use3D = IsUse3D;
            //chart1.YAxis.NumberPercision = NumberPercision; //设置小数点  
            chart1.YAxis.NumberPrecision = 2; //很多朋友在使用的时候发现不能显示小数，同事帮忙解决。
            chart1.YAxis.Maximum = 110;
            chart1.YAxis.Percent = true; //启用百分比
            //BarBrush = new SolidBrush(Color.FromArgb(AP3, BarBrushColor[i % 12]));
            chart1.Series.DefaultElement.ShowValue = true;

            //刻度
            chart1.XAxis.Name = Title;
            chart1.YAxis.TickLabelPadding = 0;
            chart1.YAxis.Line.StartCap = System.Drawing.Drawing2D.LineCap.Square;
            chart1.YAxis.Line.EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;
            chart1.YAxis.Line.Width = 5;//左侧label
            chart1.YAxis.Line.Color = Color.Gray;
            //chart1.YAxis.Interval = 50;间隔大小
            //chart1.YAxis.LabelMarker = new ElementMarker().Type;
            

            //X轴说明
            //chart1.XAxis.Label.Font = new Font("Arial Black", 9, FontStyle.Bold);
            //chart1.XAxis.Line.EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;
            //chart1.XAxis.Line.Width = 2;
            chart1.XAxis.StaticColumnWidth = 80; //每个单元格的宽度
            chart1.XAxis.SweepAngle = 45;
            //chart1.XAxis.Line.Color = Color.Gray;
            //chart1.XAxis.MinorInterval = 5;
            //chart1.DefaultBox.Visible = true;
        }

        /// <summary>        
        /// 多序列柱形图        
        /// </summary>        
        /// <returns></returns>        
        public void CreateCombos(dotnetCHARTING.Chart chart1)
        {
            chart1.Title = Title;
            //chart1.ChartArea.Background.Color = Color.White;//图片背景
            chart1.FileManager.FileName = FileName;
            //chart1.XAxis.Label.Text = XName;
            chart1.XAxis.StaticColumnWidth = 80;//每个单元格的宽度   
            chart1.YAxis.NumberPercision = NumberPercision; //设置小数点  
            //chart1.YAxis.Label.Text = this.YName;
            chart1.TempDirectory = this.PhaysicalImagePath;
            chart1.Width = this.PicWidth;
            chart1.Height = this.PicHight;
            chart1.Type = ChartType.Combo;
            chart1.Series.Type = SeriesType.Bar;
            chart1.Series.Name = "图例名称"+this.SeriseName;
            //chart1.Series.Data = this.DataSoure;
            chart1.SeriesCollection.Add(getArrayData2());
            chart1.YAxis.Percent = true; //启用百分比
            chart1.DefaultSeries.DefaultElement.ShowValue = true;

            //chart1.DefaultSeries.Type = SeriesType.Bar;//
            //chart1.DefaultSeries.Type = SeriesType.Bar;//方形
            chart1.ShadingEffect = true;
            chart1.Use3D = IsUse3D;
            chart1.Series.DefaultElement.ShowValue = true;
        }

        /// <summary>
        ///     横行柱形图
        /// </summary>
        /// <returns></returns>
        public void CreateComboHorizontal(dotnetCHARTING.Chart chart1)
        {
            //chart1.XAxis.StaticColumnWidth = ColumnWidth; //每个单元格的宽度  
            //chart1.YAxis.StaticColumnWidth = ColumnWidth; //每个单元格的宽度  
            //chart1.XAxis.NumberPercision = NumberPercision; //设置小数点  
            //chart1.YAxis.Line.Width = 5;//箭头宽度 
            //chart1.XAxis.Line.Width = 5;//箭头宽度 
            chart1.YAxis.StaticColumnWidth = 8000; //每个单元格的宽度
            chart1.XAxis.StaticColumnWidth = 8000; //每个单元格的宽度
            chart1.Title = Title;
            chart1.FileManager.FileName = FileName;
            chart1.XAxis.Label.Text = XName;
            chart1.YAxis.Label.Text = YName;
            chart1.TempDirectory = PhaysicalImagePath;
            chart1.Width = PicWidth;
            chart1.Height = PicHight;
            chart1.Type = ChartType.ComboHorizontal;
            chart1.Series.Type = SeriesType.Cylinder;
            chart1.Series.Name = SeriseName;
            chart1.Series.Data = DataSoure;
            chart1.SeriesCollection.Add(getArrayData());
            chart1.DefaultSeries.DefaultElement.ShowValue = true;
            chart1.DefaultSeries.Type = SeriesType.Cylinder;
            chart1.ShadingEffect = true;
            chart1.XAxis.Percent = true; //启用百分比
            chart1.Use3D = IsUse3D;
            chart1.Series.DefaultElement.ShowValue = true;


        }


        /// <summary>        
        /// 柱形图        
        /// </summary>        
        /// <returns></returns>        
        public void CreateCombo1(dotnetCHARTING.Chart chart1)
        {
            chart1.Title = Title;
            chart1.FileManager.FileName = FileName;
            chart1.XAxis.Label.Text = XName;
            chart1.YAxis.Label.Text = this.YName;
            chart1.TempDirectory = this.PhaysicalImagePath;
            chart1.Width = this.PicWidth;
            chart1.Height = this.PicHight;
            chart1.Type = ChartType.Combo;
            chart1.Series.Type = SeriesType.Cylinder;
            chart1.Series.Name = this.SeriseName;
            //chart1.Series.Data = this.DataSoure;
            chart1.SeriesCollection.Add(getArrayData());
            chart1.DefaultSeries.DefaultElement.ShowValue = true;
            chart1.DefaultSeries.Type = SeriesType.Cylinder;
            chart1.ShadingEffect = true;
            chart1.Use3D = IsUse3D;
            chart1.Series.DefaultElement.ShowValue = true;
        }

        /// <summary>        
        /// 柱形图        
        /// </summary>        
        /// <returns></returns>        
        public void CreateDonut(dotnetCHARTING.Chart chart1)
        {
            chart1.Title = Title;
            chart1.FileManager.FileName = FileName;
            chart1.XAxis.Label.Text = XName;
            chart1.YAxis.Label.Text = this.YName;
            chart1.TempDirectory = this.PhaysicalImagePath;
            chart1.Width = this.PicWidth;
            chart1.Height = this.PicHight;
            chart1.Type = ChartType.Donut;
            chart1.Series.Type = SeriesType.Cylinder;
            chart1.Series.Name = this.SeriseName;
            //chart1.Series.Data = this.DataSoure;
            chart1.SeriesCollection.Add(getArrayData());
            chart1.DefaultSeries.DefaultElement.ShowValue = true;
            //chart1.DefaultSeries.Type = SeriesType.Cylinder;
            chart1.ShadingEffect = true;
            chart1.Use3D = IsUse3D;
            chart1.Series.DefaultElement.ShowValue = true;

            chart1.LegendBox.Label = new dotnetCHARTING.Label("图表说明",
                new Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point,
                    134));
            //chart.LegendBox.HeaderLabel.Font = new Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
            chart1.LegendBox.Label.Font = new Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold,
                System.Drawing.GraphicsUnit.Point, 134);
            //chart1.Palette = new Color[] { Color.FromArgb(0, 156, 255), Color.FromArgb(255, 99, 49), Color.FromArgb(49, 255, 49), Color.FromArgb(255, 255, 0), };

        }


        /// <summary>        
        /// 饼图        
        /// </summary>        
        /// <returns></returns>  
        public void CreatePie(dotnetCHARTING.Chart chart1)
        {
            chart1.Title = Title;
            // chart1.LegendBox.Label = new dotnetCHARTING.Label("图表说明", new Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134));
            //chart.LegendBox.HeaderLabel.Font = new Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
            //chart1.LegendBox.Label.Font = new Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
            //chart1.Palette = new Color[] { Color.FromArgb(0, 156, 255), Color.FromArgb(255, 99, 49), Color.FromArgb(49, 255, 49), Color.FromArgb(255, 255, 0), };

            chart1.ChartArea.Background.Color = Color.White; //图片背景
            chart1.FileManager.FileName = FileName;
            chart1.XAxis.Label.Text = XName;
            chart1.XAxis.StaticColumnWidth = ColumnWidth; //每个单元格的宽度  
            chart1.XAxis.Label.Color = Color.Red;
            chart1.YAxis.Label.Text = this.YName;
            chart1.YAxis.Label.Color = Color.Black;
            chart1.YAxis.NumberPercision = NumberPercision; //设置小数点  
            chart1.TempDirectory = this.PhaysicalImagePath;
            chart1.Width = this.PicWidth;
            chart1.Height = this.PicHight;
            //chart1.Type = ChartType.ComboSideBySide;
            chart1.Type = ChartType.Pie;
            chart1.Series.Type = SeriesType.Cylinder;
            chart1.Series.Name = this.SeriseName;
            chart1.ShadingEffect = true;
            //chart1.ShadingEffect = false;
            chart1.Use3D = IsUse3D;
            //chart1.DefaultSeries.DefaultElement.Transparency = 60;
            chart1.DefaultSeries.DefaultElement.ShowValue = true;
            //chart1.DefaultSeries.Type = SeriesType.Column;
            chart1.PieLabelMode = PieLabelMode.Outside;
            chart1.SeriesCollection.Add(getArrayData());
            chart1.Series.DefaultElement.ShowValue = true;

            //SeriesCollection mySC = getArrayData();

            // Add the random data.
            //chart1.SeriesCollection.Add(mySC);

            //chart1.LegendBox.Label = new dotnetCHARTING.Label("图表说明", new Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134));
            ////chart.LegendBox.HeaderLabel.Font = new Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
            //chart1.LegendBox.Label.Font = new Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
        }

        private SeriesCollection getArrayData()
        {
            SeriesCollection SC = new SeriesCollection();

            DataTable dt = this.DataSoure;

            Random rd1 = new Random((int) DateTime.Now.Ticks);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Series s = new Series();
                s.Name = dt.Rows[i][0].ToString();

                Element e = new Element();
                // 每元素的名称  
                e.Name = dt.Rows[i][0].ToString();
                e.SmartLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold,
                    System.Drawing.GraphicsUnit.Point, 134); //设置柱状图字体大小
                e.SmartLabel.Color = Color.White; //设置柱状图字体颜色

                // 每元素的大小数值                
                e.YValue = Convert.ToDouble(dt.Rows[i][1].ToString());
                
                s.Elements.Add(e);

                //表示0-255取随机值int
                var r = rd1.Next(255);
                int g = rd1.Next(255);
                int b = rd1.Next(255);
                Color cr = Color.FromArgb(r, g, b);
                s.DefaultElement.Color = cr;
                SC.Add(s);
            }

            return SC;
        }

         public enum SeriesBy
        {
            /// <summary>
            /// 按照列名出序列
            /// </summary>
            columns,
            /// <summary>
            /// 按照每条记录的field值的出序列
            /// </summary>
            field,
        }


        /// <summary>
        /// 多序列元素名字段（例如：指标名）
        /// </summary>
        /// <param name="columnName"></param>
        /// <returns></returns>
        private SeriesCollection getSeriesData(string columnName, SeriesBy seriesBy)
        {
            if (!string.IsNullOrEmpty(columnName))
            {
                //--多序列测试
                //序列集合（年份序列）
                SeriesCollection SC = new SeriesCollection();
                //x轴名字集合
                System.Collections.Generic.List<string> xNames = new System.Collections.Generic.List<string>();
                if (seriesBy.Equals(SeriesBy.columns))
                {
                    //序列名
                    for (int i = 1; i < DataSoure.Columns.Count; i++)
                    {
                        xNames.Add(DataSoure.Columns[i].ColumnName);
                    }
                    for (int k = 0; k < xNames.Count; k++)
                    {
                        Series series = new Series(xNames[k]);
                        for (int j = 0; j < DataSoure.Rows.Count; j++)
                        {
                            Element e = new Element();
                            e.Name = DataSoure.Rows[j][columnName].ToString();
                            e.YValue = Convert.ToDouble(DataSoure.Rows[j][k + 1]);
                            series.Elements.Add(e);
                        }
                        SC.Add(series);
                    }
                }
                else if (seriesBy.Equals(SeriesBy.field))
                {
                    //序列名
                    for (int i = 1; i < DataSoure.Columns.Count; i++)
                    {
                        xNames.Add(DataSoure.Columns[i].ColumnName);
                    }
                    for (int j = 0; j < DataSoure.Rows.Count; j++)
                    {
                        Series series = new Series(DataSoure.Rows[j][columnName].ToString());
                        for (int k = 0; k < xNames.Count; k++)
                        {
                            Element e = new Element();
                            e.Name = xNames[k];
                            e.YValue = Convert.ToDouble(DataSoure.Rows[j][k + 1]);
                            series.Elements.Add(e);
                        }
                        SC.Add(series);
                    }
                }
                //序列颜色设置
                //List<Color> colorObjs = Util.OperationUtil.GetRandomObject.GetListColor();
                //int icolorCount = colorObjs.Count;
                //for (int i = 0; i < SC.Count; i++)
                //{
                    //if (i + i > colorObjs.Count)
                    //{
                    //    SC[i].DefaultElement.Color = Util.OperationUtil.GetRandomObject.GetRandomColor();
                    //}
                    //else
                    //{
                    //SC[i].DefaultElement.Color = colorObjs[i];
                    //}
                //}
                return SC;
            }
            else
            {
                return getArrayData();
            }
        }
    
        private SeriesCollection getArrayData2()
        {
            SeriesCollection SC = new SeriesCollection();

            DataTable dt = this.DataSoure;
            DataTable dt2 = this.DataSoure2;

            Random rd1 = new Random((int)DateTime.Now.Ticks);
            Random myR = new Random();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Series s = new Series();
                s.Name = dt.Rows[i][0].ToString()+"月项目执行进度";
                for (int j= 0; j < dt2.Rows.Count; j++)
                {
                    Element e = new Element();
                    // 每元素的名称  
                    e.Name = "部门"+dt2.Rows[j][0].ToString();
                    e.SmartLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F,
                        System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134); //设置柱状图字体大小
                    e.SmartLabel.Color = Color.White; //设置柱状图字体颜色

                    // 每元素的大小数值                
                    e.YValue = Convert.ToDouble(dt.Rows[i][1].ToString());
                    //e.YValue = myR.Next(50);
                    s.Elements.Add(e);

                    //表示0-255取随机值int
                    var r = rd1.Next(255);
                    int g = rd1.Next(255);
                    int b = rd1.Next(255);
                    Color cr = Color.FromArgb(r, g, b);
                    s.DefaultElement.Color = cr;
                }
                SC.Add(s);
            }

            return SC;
        }

        SeriesCollection getArrayData1()
        {
            SeriesCollection SC = new SeriesCollection();
            Random myR = new Random();
            for (int a = 0; a < 2; a++)
            {
                Series s = new Series();
                s.Name = "Series " + a;
                for (int b = 0; b < 4; b++)
                {
                    Element e = new Element();
                    e.Name = "Element " + b;
                    e.YValue = myR.Next(50);
                    s.Elements.Add(e);
                }
                SC.Add(s);
            }

            // Set Different Colors for our Series
            //SC[0].DefaultElement.Color = Color.FromArgb(49, 255, 49);
            //SC[1].DefaultElement.Color = Color.FromArgb(255, 255, 0);
            //SC[2].DefaultElement.Color = Color.FromArgb(255, 99, 49);
            //SC[3].DefaultElement.Color = Color.FromArgb(0, 156, 255);
            return SC;
        }

        /// <summary>       
        /// 曲线图     
        /// </summary>        
        /// <returns></returns> 
        public void CreateLine(dotnetCHARTING.Chart chart1)
        {
            chart1.Title = Title;
            chart1.FileManager.FileName = FileName;
            chart1.XAxis.Label.Text = XName;
            chart1.XAxis.Label.Color = Color.Red;
            //chart1.XAxis.Label.Font = System.Drawing.Font.FromHdc(11);
            
            chart1.YAxis.Label.Text = this.YName;
            chart1.YAxis.Label.Color = Color.Black;
            chart1.TempDirectory = this.PhaysicalImagePath;
            chart1.Width = this.PicWidth;
            chart1.Height = this.PicHight;
            chart1.Type = ChartType.Combo;
            //此处一定要用DefaultSeries.Type = SeriesType.Line 否则没效果
            chart1.DefaultSeries.Type = SeriesType.Line;
            chart1.Series.Name = this.SeriseName;
            chart1.Series.Data = this.DataSoure;
            chart1.SeriesCollection.Add();
            chart1.DefaultSeries.DefaultElement.ShowValue = true;
            chart1.ShadingEffect = false;
            chart1.Use3D = IsUse3D;
            chart1.Series.DefaultElement.ShowValue = true;
        }

    }
}