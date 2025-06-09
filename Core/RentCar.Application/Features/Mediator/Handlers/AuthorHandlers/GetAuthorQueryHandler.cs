﻿using MediatR;
using RentCar.Application.Features.Mediator.Queries.AuthorQueries;
using RentCar.Application.Features.Mediator.Results.AuthorResults;
using RentCar.Application.Interfaces;
using RentCar.Domain.Entities;

namespace RentCar.Application.Features.Mediator.Handlers.AuthorHandlers
{
    public class GetAuthorQueryHandler : IRequestHandler<GetAuthorQuery, List<GetAuthorQueryResult>>
    {
        private readonly IRepository<Author> _repository;

        public GetAuthorQueryHandler(IRepository<Author> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetAuthorQueryResult>> Handle(GetAuthorQuery request, CancellationToken cancellationToken)
        {
            var values = _repository.GetAllAsync()
                .ContinueWith(task => task.Result.Select(x => new GetAuthorQueryResult
                {
                    AuthorId = x.AuthorId,
                    Name = x.Name,
                    ImageUrl = x.ImageUrl,
                    Description = x.Description
                }).ToList(),
                cancellationToken);
            return await values;
        }
    }
}
