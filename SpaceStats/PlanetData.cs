using System;
using System.IO;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;

public class PlanetData : Form
{
    private DataGridView dataGridView1;
    private BindingSource planetBindingSource;
    private System.ComponentModel.IContainer components;
    private Label label1;
    private BindingSource planetBindingSource1;
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

            // Make sure to call this in constructor!
            InitializeComponent();
		}
		catch (Exception e)
		{
			Console.WriteLine("Planet data could not be read from file!");
			Console.WriteLine(e.Message);
		}

        /*
		// Display planet informatino to console as a test
		for (int i = 0; i < planets.Length; i++)
		{
			Console.WriteLine("Name: " + planets[i].getName());
			Console.WriteLine("Mass: " + planets[i].getMass());
			Console.WriteLine("Diameter: " + planets[i].getDiameter());
			Console.WriteLine("Density: " + planets[i].getDensity());
			Console.WriteLine("Gravity: " + planets[i].getGravity());
			Console.WriteLine("Escape Velocity: " + planets[i].getEscapeVelocity() + "\n");
		}
         * */
	}

    private void InitializeComponent()
    {
            this.components = new System.ComponentModel.Container();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.planetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.planetBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.planetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.planetBindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(69, 161);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(463, 260);
            this.dataGridView1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(259, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "Space Stats";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // planetBindingSource
            // 
            this.planetBindingSource.DataSource = typeof(Planet);
            // 
            // planetBindingSource1
            // 
            this.planetBindingSource1.DataSource = typeof(Planet);
            // 
            // PlanetData
            // 
            this.ClientSize = new System.Drawing.Size(625, 579);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "PlanetData";
            this.Load += new System.EventHandler(this.PlanetData_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.planetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.planetBindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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
