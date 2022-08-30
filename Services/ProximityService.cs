using Grpc.Core;
using geohash_proximity;

namespace geohash_proximity.Services;

public class ProximityService : GeoHashProximity.GeoHashProximityBase
{
    private readonly ILogger<ProximityService> _logger;
    public ProximityService(ILogger<ProximityService> logger)
    {
        _logger = logger;
    }

    public override Task<StringResult> AddHash(HashRequest request, ServerCallContext context)
    {
        return Task.FromResult(new StringResult{
            Message=request.Hash,
        });
    }

    public override Task<HashesListResult> GetCloseHashes(HashDistanceRequest request, ServerCallContext context)
    {
        return base.GetCloseHashes(request, context);
    }


    public override Task<StringResult> RemoveHash(HashRequest request, ServerCallContext context)
    {
        return Task.FromResult(new StringResult{
            Message=request.Hash,
        });
    }

}
