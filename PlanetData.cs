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
		
		// TODO: Parse planet data from text file
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
						Console.WriteLine(line);

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
									planets[planetIndex].setDiameter(32);//int.Parse(line));
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
	}
}
