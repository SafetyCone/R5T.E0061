using System;


namespace R5T.E0061.Construction
{
	public class Explorations : IExplorations
	{
		#region Infrastructure

	    public static IExplorations Instance { get; } = new Explorations();

	    private Explorations()
	    {
        }

	    #endregion
	}
}