public class Planet
{
	// Planet information
	private float mass; // 10^21 tons
	private int diameter; // miles
	private int density; // lbs/(ft^3)
	private float gravity; // ft/(s^2)
	private float escapeVelocity; // miles/s

	public float getMass()
	{
		return mass;
	}

	public void setMass(float inputMass)
	{
		mass = inputMass;
	}

	public int getDiameter()
	{
		return diameter;
	}

	public void setDiameter(int inputDiameter)
	{
		diameter = inputDiameter;
	}

	public int getDensity()
	{
		return density;
	}

	public void setDensity(int inputDensity)
	{
		density = inputDensity;
	}

	public float getGravity()
	{
		return gravity;
	}

	public void setGravity(float inputGravity)
	{
		gravity = inputGravity;
	}

	public float getEscapeVelocity()
	{
		return escapeVelocity;
	}

	public void setEscapeVelocity(float inputEscapeVelocity)
	{
		escapeVelocity = inputEscapeVelocity;
	}
}
