using Gatherly.Domain.Repositories;
using System.Threading;

namespace Gatherly.Domain.Entities;

public class Gathering
{
    private readonly List<Invitation> _invitations = new();
    private readonly List<Attendee> _attendees = new();
    private Gathering(
        Guid id,
        Member creator,
        GatheringType type,
        DateTime scheduledAtUtc,
        string name,
        string? location
        )
    {
        Id = id;
        Creator = creator;
        Type = type;
        Name = name;
        location = location;

    }
    public Guid Id { get; private set; }

    public Member Creator { get; private set; }

    public GatheringType Type { get; private set; }

    public string Name { get; private set; }

    public DateTime ScheduledAtUtc { get; private set; }

    public string? Location { get; private set; }

    public int? MaximumNumberOfAttendees { get; set; }

    public DateTime? InvitationsExpireAtUtc { get; set; }

    public int NumberOfAttendees { get; set; }

    public IReadOnlyCollection<Attendee> Attendees => _attendees;

    public IReadOnlyCollection<Invitation> Invitations => _invitations;
    public static Gathering Create(
        Guid id,
        Member creator,
        GatheringType type,
        DateTime scheduledAtUtc,
        string name,
        string? location,
        int? maxNumberOfAttendiees,
        int? invitationsValidBefourHours)
    {
        Gathering gathering = new Gathering(Guid.NewGuid(), creator, type, scheduledAtUtc, name, location);

        switch (gathering.Type)
        {
            case GatheringType.WithFixedNumberOfAttendees:
                if (maxNumberOfAttendiees is null)
                {
                    throw new Exception(
                        $"{nameof(maxNumberOfAttendiees)} can't be null.");
                }

                gathering.MaximumNumberOfAttendees = gathering.MaximumNumberOfAttendees;
                break;
            case GatheringType.WithExpirationForInvitations:
                if (invitationsValidBefourHours is null)
                {
                    throw new Exception(
                        $"{nameof(invitationsValidBefourHours)} can't be null.");
                }

                gathering.InvitationsExpireAtUtc =
                    gathering.ScheduledAtUtc.AddHours(-invitationsValidBefourHours.Value);
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(GatheringType));
        }

        return gathering;
    }

    public void AddAttendees(Attendee attendee)
    {
        _attendees.Add(attendee);
        NumberOfAttendees++;
    }

    public Invitation SendInivtation(Member member)
    {
        if (Creator.Id == member.Id)
        {
            throw new Exception("Can't send invitation to the gathering creator.");
        }

        if (ScheduledAtUtc < DateTime.UtcNow)
        {
            throw new Exception("Can't send invitation for gathering in the past.");
        }

        var invitation = new Invitation(new Guid(), member, this.Id);
        _invitations.Add(invitation);

        return invitation;
    }

    public Attendee AcceptIvnitation(Invitation invitation)
    {
        if (invitation is null)
        {
            throw new ArgumentNullException(nameof(invitation));
        }
        if (invitation.Status != InvitationStatus.Pending)
        {
            throw new Exception("Invitation is not pending.");
        }

        var attendee = invitation.Accepted();
        AddAttendees(attendee);
        return attendee;
    }
    public Attendee? AcceptInvitation(Invitation invitationId)
    {
        bool expired = (
                Type == GatheringType.WithFixedNumberOfAttendees && NumberOfAttendees < MaximumNumberOfAttendees)
            || (Type == GatheringType.WithExpirationForInvitations && InvitationsExpireAtUtc < DateTime.UtcNow);

        if (expired)
        {
            invitationId.Expired();
            return null;
        }
        Attendee attendee = invitationId.Accepted();

        if (attendee is null)
        {
            throw new Exception("Invitation is not accepted.");
        }

        AddAttendees(attendee);

        return attendee;
    }
}
