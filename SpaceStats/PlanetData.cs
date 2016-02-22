using System;
using System.IO;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Windows.Forms.DataVisualization.Charting;

public class PlanetData : Form
{
    private DataGridView dataGridView1;
	private Chart massBarGraph;
	private Chart diameterPieChart;
    private Label title;
	private Button nextButton;
	private Button previousButton;
	private Planet[] planets;

    [STAThread]
    static void Main()
    {
        // Run Linq test
		linqTest();
		
		Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Application.Run(new PlanetData());
    }

    static void linqTest()
    {
		// Data source
		int [] numbers = new int[8] {0, 1, 2, 3, 4, 5, 6, 7};

		// Query creation
		var numQuery = 
			from num in numbers
			where (num % 2) == 0
			select num;

		// Query execution
		foreach (int num in numQuery)
		{
			Console.Write(num + " ");
		}
    }

	public PlanetData()
	{
		planets = new Planet[10];

		for (int i = 0; i < 10; i++)
		{
			planets[i] = new Planet();


			// Name planets accordingly
			switch (i)
			{
				case 0:
					planets[i].setName("Mercury");
					break;
				case 1:
					planets[i].setName("Venus");
					break;
				case 2:
					planets[i].setName("Earth");
					break;
				case 3:
					planets[i].setName("Moon");
					break;
				case 4:
					planets[i].setName("Mars");
					break;
				case 5:
					planets[i].setName("Jupiter");
					break;
				case 6:
					planets[i].setName("Saturn");
					break;
				case 7:
					planets[i].setName("Uranus");
					break;
				case 8:
					planets[i].setName("Neptune");
					break;
				case 9:
					planets[i].setName("Pluto");
					break;
				default:
					planets[i].setName("THE VOID");
					break;
			}
		}
		
		try
		{
			int planetIndex = 0;
			int fieldIndex = -1;

			using (StreamReader sr = new StreamReader("planet_data.txt"))
			{
				string line;

				while ((line = sr.ReadLine()) != null)
				{
					if (line.Length > 0)
					{
						if (char.IsLetter(line[0]))
						{
							planetIndex = 0;
							fieldIndex++;
						}
						else if (char.IsDigit(line[0]))
						{
							switch (fieldIndex)
							{
								case 0:
									planets[planetIndex].setMass(float.Parse(line));
									break;
								case 1:
                                    planets[planetIndex].setDiameter(Int32.Parse(line));
									break;
								case 2:
									planets[planetIndex].setDensity(Int32.Parse(line));
									break;
								case 3:
									planets[planetIndex].setGravity(float.Parse(line));
									break;
								case 4:
									planets[planetIndex].setEscapeVelocity(float.Parse(line));
									break;
								default:
									break;

							}

							planetIndex++;
						}
					}	
				}
			}
		}
		catch (Exception e)
		{
			Console.WriteLine("Planet data could not be read from file!");
			Console.WriteLine(e.Message);
		}

		// Make sure to call this in constructor!
		InitializeComponent();
	}

    private void InitializeComponent()
    {
        this.dataGridView1 = new System.Windows.Forms.DataGridView();
		this.massBarGraph = new System.Windows.Forms.DataVisualization.Charting.Chart ();
		this.diameterPieChart = new System.Windows.Forms.DataVisualization.Charting.Chart ();
        this.title = new System.Windows.Forms.Label();
		this.nextButton = new System.Windows.Forms.Button ();
		this.previousButton = new System.Windows.Forms.Button ();
        ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
		//((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
        this.SuspendLayout();

        // 
        // dataGridView1
        // 
        this.dataGridView1.AllowUserToAddRows = false;
        this.dataGridView1.AllowUserToDeleteRows = false;
        this.dataGridView1.AllowUserToResizeColumns = false;
        this.dataGridView1.AllowUserToResizeRows = false;
		this.dataGridView1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
        this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
        this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
        this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		this.dataGridView1.Location = new System.Drawing.Point (90, 50);
        this.dataGridView1.Name = "dataGridView1";
        this.dataGridView1.ReadOnly = true;
		this.dataGridView1.AutoSize = true;
        this.dataGridView1.TabIndex = 0;
		this.dataGridView1.Anchor = AnchorStyles.Top;

		//
		// massBarGraph
		//
		/*this.massBarGraph.Location = new Point(0, 0);
		this.massBarGraph.Palette = ChartColorPalette.EarthTones;
		System.Windows.Forms.DataVisualization.Charting.Series series = new Series 
		{
			Name = "series",
			IsVisibleInLegend = true,
			ChartType = SeriesChartType.Column
		};*/

		//this.massBarGraph.Series.Add (series);
		// TODO: Apparently adding to the list of series is an undefined function (the 'add' function itself)
		//this.massBarGraph.Series.Add(series);
		/*for (int i = 0; i < planets.Length; i++) 
		{
			series.Points.Add (planets [i].getMass ());
			series.Points [i].AxisLabel = planets [i].getName ();
			series.Points [i].Label = planets [i].getMass ().ToString ();
		}
		this.massBarGraph.Invalidate ();*/

        // 
        // title
        // 
		Padding pad = this.title.Padding;
		pad.Top = 10;
		this.title.Padding = pad;
        this.title.AutoSize = false;
        this.title.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.title.Name = "title";
        this.title.Text = "Space Stats";
        this.title.TextAlign = System.Drawing.ContentAlignment.TopCenter;
		this.title.Anchor = AnchorStyles.None;
		this.title.Dock = DockStyle.Fill;

		//
		// nextButton
		//
		this.nextButton.Text = ">";
		this.nextButton.AutoSize = true;
		this.nextButton.TextAlign = ContentAlignment.MiddleCenter;
		this.nextButton.Location = new Point (500, 310);
		this.nextButton.Name = "nextButton";
		this.nextButton.Anchor = AnchorStyles.None;
		this.nextButton.Click += new EventHandler (nextChart);

		//
		// previousButton
		//
		this.previousButton.Text = "<";
		this.previousButton.AutoSize = true;
		this.previousButton.TextAlign = ContentAlignment.MiddleCenter;
		this.previousButton.Location = new Point (230, 310);
		this.previousButton.Name = "previousButton";
		this.previousButton.Anchor = AnchorStyles.None;
		this.previousButton.Click += new EventHandler (previousChart);

        // 
        // PlanetData
        // 
        this.ClientSize = new System.Drawing.Size(800, 600);
		this.Controls.Add(this.dataGridView1);
		this.Controls.Add (this.massBarGraph);
		this.Controls.Add (this.nextButton);
		this.Controls.Add (this.previousButton);
		this.Controls.Add(this.title);
        
        this.Name = "PlanetData";
        this.Load += new System.EventHandler(this.PlanetData_Load);
        ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
        this.ResumeLayout(false);
        this.PerformLayout();

		CenterToScreen ();
    }

	private void nextChart(object sender, EventArgs e)
	{
		this.dataGridView1.Show ();
	}

	private void previousChart(object sender, EventArgs e)
	{
		this.dataGridView1.Hide ();
	}

    private void PlanetData_Load(object sender, EventArgs e)
    {
        DataTable dt = new DataTable("PlanetInfo");

        dt.Columns.Add("Name", System.Type.GetType("System.String"));
        dt.Columns.Add("Mass (10^21 T)", System.Type.GetType("System.Single"));
        dt.Columns.Add("Diameter (mi)", System.Type.GetType("System.Int32"));
        dt.Columns.Add("Density (lbs/ft^3)", System.Type.GetType("System.Int32"));
        dt.Columns.Add("Gravity (ft/s^2)", System.Type.GetType("System.Single"));
        dt.Columns.Add("Escape Velocity (mi/s)", System.Type.GetType("System.Single"));

        for (int i = 0; i < planets.Length; i++)
        {
            dt.Rows.Add(new object[] {planets[i].getName(), planets[i].getMass(), planets[i].getDiameter(), planets[i].getDensity(),
                                        planets[i].getGravity(), planets[i].getEscapeVelocity()});
            
        }

        
        dataGridView1.DataSource = dt;

        // Change color of cell background depending on variance from average value
        foreach (DataGridViewRow row in dataGridView1.Rows)
        {
            // Mass cell coloration
            if (Convert.ToSingle(row.Cells[1].Value) > 100)
            {
                row.Cells[1].Style.BackColor = Color.LightGreen;
            }
            else if (Convert.ToSingle(row.Cells[1].Value) < 1)
            {
                row.Cells[1].Style.BackColor = Color.LightPink;
            }

            // Diameter cell coloration
            if (Convert.ToInt32(row.Cells[2].Value) > 10000)
            {
                row.Cells[2].Style.BackColor = Color.LightGreen;
            }
            else if (Convert.ToInt32(row.Cells[2].Value) < 5000)
            {
                row.Cells[2].Style.BackColor = Color.LightPink;
            }

            // Density cell coloration
            if (Convert.ToInt32(row.Cells[3].Value) > 300)
            {
                row.Cells[3].Style.BackColor = Color.LightGreen;
            }
            else if (Convert.ToInt32(row.Cells[3].Value) < 100)
            {
                row.Cells[3].Style.BackColor = Color.LightPink;
            }

            // Gravity cell coloration
            if (Convert.ToSingle(row.Cells[4].Value) > 30)
            {
                row.Cells[4].Style.BackColor = Color.LightGreen;
            }
            else if (Convert.ToSingle(row.Cells[4].Value) < 10)
            {
                row.Cells[4].Style.BackColor = Color.LightPink;
            }

            // Escape Velocity cell coloration
            if (Convert.ToSingle(row.Cells[5].Value) > 10)
            {
                row.Cells[5].Style.BackColor = Color.LightGreen;
            }
            else if (Convert.ToSingle(row.Cells[5].Value) < 5)
            {
                row.Cells[5].Style.BackColor = Color.LightPink;
            }
        }

        // Disable user defined data sorting (upon clicking rows/columns)
        foreach (DataGridViewColumn column in dataGridView1.Columns)
        {
            column.SortMode = DataGridViewColumnSortMode.NotSortable;
        }

        for (int i = 0; i < dataGridView1.Columns.Count; i++)
        {
            dataGridView1.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }
    }

}
