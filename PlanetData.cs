using System;
using System.IO;
using System.Drawing;
using System.Windows.Forms;

public class PlanetData : Form
{
	private Planet[] planets;

	static public void Main()
	{
		Application.Run(new PlanetData());
	}

	public PlanetData()
	{
		Planet mercury = new Planet();
		Planet venus = new Planet();
		Planet earth = new Planet();
		Planet moon = new Planet();
		Planet mars = new Planet();
		Planet jupiter = new Planet();
		Planet saturn = new Planet();
		Planet uranus = new Planet();
		Planet neptune = new Planet();
		Planet pluto = new Planet(); // Pluto isn't a planet anymore! Still keeping it.
		
		// TODO: Parse planet data from text file
		try
		{
			using (StreamReader sr = new StreamReader("planet_data.txt"))
			{
				String line = sr.ReadToEnd();
				Console.WriteLine(line);
			}
		}
		catch (Exception e)
		{
			Console.WriteLine("Planet data could not be read from file!");
			Console.WriteLine(e.Message);
		}
	}
}
