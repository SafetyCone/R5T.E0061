using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using NuGet.Common;
using NuGet.Protocol;
using NuGet.Protocol.Core.Types;
using NuGet.Versioning;

using R5T.T0141;


namespace R5T.E0061.Construction
{
	/// <summary>
	/// See examples here: <see href="https://learn.microsoft.com/en-us/nuget/reference/nuget-client-sdk"/>.
	/// </summary>
	[ExplorationsMarker]
	public partial interface IExplorations : IExplorationsMarker
	{
		/// <summary>
		/// Try to find if an exact package ID/version exists in a local file repository.
		/// Result: Success!
		/// </summary>
		public async Task TryTestIfNuGetPackageExists_Local02()
		{
			ILogger logger = NullLogger.Instance;
			CancellationToken cancellationToken = CancellationToken.None;

			SourceCacheContext cacheContext = new();
			SourceRepository repository = Repository.Factory.GetCoreV3(@"C:\Users\David\Dropbox\Organizations\Rivet\Shared\Packages");
			FindPackageByIdResource resource = await repository.GetResourceAsync<FindPackageByIdResource>();

			string packageID = "R5T.F0028";
			NuGetVersion version = new(1, 0, 2);

			var exists = await resource.DoesPackageExistAsync(
				packageID,
				version,
				cacheContext,
				logger,
				cancellationToken);

			Console.WriteLine($"{exists}: {packageID}/{version} exists?");
			// Produces:
			// True: R5T.F0028/1.0.1 exists?
		}

		/// <summary>
		/// Try to find if a version exists in a local file repository.
		/// Result: Success!
		/// </summary>
		public async Task TryTestIfNuGetPackageExists_Local01()
        {
			ILogger logger = NullLogger.Instance;
			CancellationToken cancellationToken = CancellationToken.None;

			SourceCacheContext cacheContext = new();
			SourceRepository repository = Repository.Factory.GetCoreV3(@"C:\Users\David\Dropbox\Organizations\Rivet\Shared\Packages");
			FindPackageByIdResource resource = await repository.GetResourceAsync<FindPackageByIdResource>();

			IEnumerable<NuGetVersion> versions = await resource.GetAllVersionsAsync(
				"R5T.F0028",
				cacheContext,
				logger,
				cancellationToken);

			foreach (var version in versions)
            {
				Console.WriteLine(version);
            }
			// Produces:
			// 1.0.0
			// 1.0.1
        }
	}
}