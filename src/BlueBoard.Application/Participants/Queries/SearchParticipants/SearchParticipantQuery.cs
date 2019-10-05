using BlueBoard.Application.Users.Models;
using MediatR;
using System.Collections.Generic;

namespace BlueBoard.Application.Participants.Queries.SearchParticipants
{
    public class SearchParticipantQuery : IRequest<IList<SlimUserModel>>
    {
        public string Query { get; set; }
    }
}
