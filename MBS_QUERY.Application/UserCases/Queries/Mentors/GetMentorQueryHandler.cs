using AutoMapper;
using MBS_QUERY.Contract.Abstractions.Messages;
using MBS_QUERY.Contract.Abstractions.Shared;
using MBS_QUERY.Contract.Services.Mentors;
using MBS_QUERY.Domain.Abstractions.Repositories;
using MBS_QUERY.Domain.Documents;

namespace MBS_QUERY.Application.UserCases.Queries.Mentors;
public class GetMentorQueryHandler : IQueryHandler<Query.GetMentorQuery, Response.GetMentorResponse>
{
    private readonly IMapper _mapper;
    private readonly IMongoRepository<MentorProjection> _mentorRepository;

    public GetMentorQueryHandler(IMongoRepository<MentorProjection> mentorRepository, IMapper mapper)
    {
        _mentorRepository = mentorRepository;
        _mapper = mapper;
    }

    public async Task<Result<Response.GetMentorResponse>> Handle(Query.GetMentorQuery request,
        CancellationToken cancellationToken)
    {
        var mentor = await _mentorRepository.FindOneAsync(x => x.DocumentId.Equals(request.Id));

        if (mentor == null) return Result.Failure<Response.GetMentorResponse>(new Error("400", "Can Find Mentor !"));

        var result = _mapper.Map<Response.GetMentorResponse>(mentor);
        return Result.Success(result);
    }
}