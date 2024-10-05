using MBS_QUERY.Domain.Abstractions.Repositories;
using MBS_QUERY.Domain.Documents;
using MBS_QUERY.Infrastructure.Consumer.Abstractions.Messages;
using MediatR;
using DomainEventShared = MBS_CONTRACT.SHARE.Services.MentorSkills.DomainEvent;

namespace MBS_QUERY.Infrastructure.Consumer.MessageBus.Consumers.Events;

public class MentorSkillConsumer
{
    public class MentorSkillsCreatedConsumer(ISender sender, IMongoRepository<EventProjection> repository)
        : Consumer<DomainEventShared.MentorSkillsCreated>(sender, repository);
}