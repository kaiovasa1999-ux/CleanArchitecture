using System.Diagnostics.Metrics;

namespace Gatherly.Domain.Entities;

public class Invitation
{
    internal Invitation(
         Guid id,
         Member member,
         Guid gatheringId
        )
    {
        Id = id;
        MemberId = member.Id;
        GatheringId = gatheringId;
        Status = InvitationStatus.Pending;
        CreatedOnUtc = DateTime.UtcNow;
    }
    public Guid Id { get; private set; }

    public Guid GatheringId { get; private set; }

    public Guid MemberId { get; set; }

    public InvitationStatus Status { get; private set; }

    public DateTime CreatedOnUtc { get; private set; }

    public DateTime? ModifiedOnUtc { get; private set; }

    internal Attendee Accepted()
    {
        Status = InvitationStatus.Accepted;
        ModifiedOnUtc = DateTime.UtcNow;
        var attendee = new Attendee(this.Id, this.MemberId);
        return attendee;

    }
    internal void Expired()
    {
        Status = InvitationStatus.Expired;
        ModifiedOnUtc = DateTime.UtcNow;
    }
}